﻿using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EncompassRest.Utilities;

namespace EncompassRest.LoanPipeline
{
    public sealed class LoanPipelineCursor
    {
        public EncompassRestClient Client { get; }

        public string CursorId { get; }

        public int Count { get; }

        public IEnumerable<string> Fields { get; }

        internal LoanPipelineCursor(EncompassRestClient client, string cursorId, int count, IEnumerable<string> fields)
        {
            Client = client;
            CursorId = cursorId;
            Count = count;
            Fields = fields ?? Array<string>.Empty;
        }

        public Task<LoanPipelineData> GetItemAsync(int index) => GetItemAsync(index, CancellationToken.None);

        public async Task<LoanPipelineData> GetItemAsync(int index, CancellationToken cancellationToken)
        {
            Preconditions.GreaterThanOrEquals(index, nameof(index), 0);
            Preconditions.LessThan(index, nameof(index), Count, nameof(Count));

            var data = await GetItemsInternalAsync(index, 1, cancellationToken).ConfigureAwait(false);
            return data[0];
        }

        public Task<List<LoanPipelineData>> GetItemsAsync(int start, int count) => GetItemsAsync(start, count, CancellationToken.None);

        public Task<List<LoanPipelineData>> GetItemsAsync(int start, int count, CancellationToken cancellationToken)
        {
            Preconditions.GreaterThanOrEquals(start, nameof(start), 0);
            Preconditions.LessThan(start, nameof(start), Count, nameof(Count));
            Preconditions.GreaterThan(count, nameof(count), 0);
            Preconditions.LessThanOrEquals(start + count, $"{nameof(start)} + {nameof(count)}", Count, nameof(Count));

            return GetItemsInternalAsync(start, count, cancellationToken);
        }

        private async Task<List<LoanPipelineData>> GetItemsInternalAsync(int start, int count, CancellationToken cancellationToken)
        {
            List<LoanPipelineData> data = null;
            do
            {
                var retrievedCount = data?.Count ?? 0;

                var queryParameters = new QueryParameters(
                    new QueryParameter("cursor", CursorId),
                    new QueryParameter("start", (start + retrievedCount).ToString()),
                    new QueryParameter("limit", (count - retrievedCount).ToString()));

                var retrievedData = await Client.Pipeline.ViewPipelineInternalAsync(JsonStreamContent.Create(new { Fields }), queryParameters.ToString(), cancellationToken, nameof(GetItemsAsync), async response =>
                {
                    var list = await response.Content.ReadAsAsync<List<LoanPipelineData>>().ConfigureAwait(false);
                    if (list.Count == 0)
                    {
                        throw await RestException.CreateAsync("Failed to retrieve pipeline data", response).ConfigureAwait(false);
                    }
                    return list;
                }).ConfigureAwait(false);
                if (data == null)
                {
                    data = retrievedData;
                }
                else
                {
                    data.AddRange(retrievedData);
                }
            } while (data.Count < count);
            return data;
        }
    }
}