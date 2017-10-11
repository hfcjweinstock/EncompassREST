﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using EncompassRest.Loans;
using EncompassRest.Utilities;

namespace EncompassRest.Schema
{
    public sealed class Schema
    {
        private const string s_apiPath = "encompass/v1/schema";

        public EncompassRestClient Client { get; }

        internal Schema(EncompassRestClient client)
        {
            Client = client;
        }

        public Task<LoanSchema> GetLoanSchemaAsync() => GetLoanSchemaAsync(false, (IEnumerable<string>)null, CancellationToken.None);

        public Task<LoanSchema> GetLoanSchemaAsync(CancellationToken cancellationToken) => GetLoanSchemaAsync(false, (IEnumerable<string>)null, cancellationToken);

        public Task<LoanSchema> GetLoanSchemaAsync(bool includeFieldExtensions) => GetLoanSchemaAsync(includeFieldExtensions, (IEnumerable<string>)null, CancellationToken.None);

        public Task<LoanSchema> GetLoanSchemaAsync(bool includeFieldExtensions, CancellationToken cancellationToken) => GetLoanSchemaAsync(includeFieldExtensions, (IEnumerable<string>)null, cancellationToken);

        public Task<LoanSchema> GetLoanSchemaAsync(params LoanEntity[] entities) => GetLoanSchemaAsync(false, entities, CancellationToken.None);

        public Task<LoanSchema> GetLoanSchemaAsync(IEnumerable<LoanEntity> entities) => GetLoanSchemaAsync(false, entities, CancellationToken.None);

        public Task<LoanSchema> GetLoanSchemaAsync(IEnumerable<LoanEntity> entities, CancellationToken cancellationToken) => GetLoanSchemaAsync(false, entities, cancellationToken);

        public Task<LoanSchema> GetLoanSchemaAsync(bool includeFieldExtensions, params LoanEntity[] entities) => GetLoanSchemaAsync(includeFieldExtensions, entities, CancellationToken.None);

        public Task<LoanSchema> GetLoanSchemaAsync(bool includeFieldExtensions, IEnumerable<LoanEntity> entities) => GetLoanSchemaAsync(includeFieldExtensions, entities, CancellationToken.None);

        public Task<LoanSchema> GetLoanSchemaAsync(bool includeFieldExtensions, IEnumerable<LoanEntity> entities, CancellationToken cancellationToken) => GetLoanSchemaAsync(includeFieldExtensions, entities?.Select(entity => entity.ToJson().Unquote()), cancellationToken);

        public Task<LoanSchema> GetLoanSchemaAsync(params string[] entities) => GetLoanSchemaAsync(false, entities, CancellationToken.None);

        public Task<LoanSchema> GetLoanSchemaAsync(IEnumerable<string> entities) => GetLoanSchemaAsync(false, entities, CancellationToken.None);

        public Task<LoanSchema> GetLoanSchemaAsync(IEnumerable<string> entities, CancellationToken cancellationToken) => GetLoanSchemaAsync(false, entities, cancellationToken);

        public Task<LoanSchema> GetLoanSchemaAsync(bool includeFieldExtensions, params string[] entities) => GetLoanSchemaAsync(includeFieldExtensions, entities, CancellationToken.None);

        public Task<LoanSchema> GetLoanSchemaAsync(bool includeFieldExtensions, IEnumerable<string> entities) => GetLoanSchemaAsync(includeFieldExtensions, entities, CancellationToken.None);

        public Task<LoanSchema> GetLoanSchemaAsync(bool includeFieldExtensions, IEnumerable<string> entities, CancellationToken cancellationToken)
        {
            var queryParameters = new QueryParameters();
            if (entities?.Any() == true)
            {
                queryParameters.Add("entities", string.Join(",", entities));
            }
            queryParameters.Add("includeFieldExtensions", includeFieldExtensions.ToString().ToLower());

            return GetLoanSchemaInternalAsync(queryParameters.ToString(), cancellationToken, response => response.Content.ReadAsAsync<LoanSchema>());
        }

        public Task<string> GetLoanSchemaRawAsync() => GetLoanSchemaRawAsync(null, CancellationToken.None);

        public Task<string> GetLoanSchemaRawAsync(CancellationToken cancellationToken) => GetLoanSchemaRawAsync(null, cancellationToken);

        public Task<string> GetLoanSchemaRawAsync(string queryString) => GetLoanSchemaRawAsync(queryString, CancellationToken.None);

        public Task<string> GetLoanSchemaRawAsync(string queryString, CancellationToken cancellationToken) => GetLoanSchemaInternalAsync(queryString, cancellationToken, response => response.Content.ReadAsStringAsync());

        private async Task<T> GetLoanSchemaInternalAsync<T>(string queryString, CancellationToken cancellationToken, Func<HttpResponseMessage, Task<T>> func)
        {
            using (var response = await Client.HttpClient.GetAsync($"{s_apiPath}/loan{queryString}", cancellationToken).ConfigureAwait(false))
            {
                if (!response.IsSuccessStatusCode)
                {
                    throw await RestException.CreateAsync(nameof(GetLoanSchemaAsync), response).ConfigureAwait(false);
                }

                return await func(response).ConfigureAwait(false);
            }
        }

        public Task<LoanSchema> GetFieldSchemaAsync(string fieldId) => GetFieldSchemaAsync(fieldId, CancellationToken.None);

        public Task<LoanSchema> GetFieldSchemaAsync(string fieldId, CancellationToken cancellationToken)
        {
            Preconditions.NotNullOrEmpty(fieldId, nameof(fieldId));

            return GetFieldSchemaInternalAsync(fieldId, cancellationToken, response => response.Content.ReadAsAsync<LoanSchema>());
        }

        public Task<string> GetFieldSchemaRawAsync(string fieldId) => GetFieldSchemaRawAsync(fieldId, CancellationToken.None);

        public Task<string> GetFieldSchemaRawAsync(string fieldId, CancellationToken cancellationToken)
        {
            Preconditions.NotNullOrEmpty(fieldId, nameof(fieldId));

            return GetFieldSchemaInternalAsync(fieldId, cancellationToken, response => response.Content.ReadAsStringAsync());
        }

        private async Task<T> GetFieldSchemaInternalAsync<T>(string fieldId, CancellationToken cancellationToken, Func<HttpResponseMessage, Task<T>> func)
        {
            using (var response = await Client.HttpClient.GetAsync($"{s_apiPath}/loan/{fieldId}", cancellationToken).ConfigureAwait(false))
            {
                if (!response.IsSuccessStatusCode)
                {
                    throw await RestException.CreateAsync(nameof(GetFieldSchemaAsync), response).ConfigureAwait(false);
                }

                return await func(response).ConfigureAwait(false);
            }
        }
    }
}