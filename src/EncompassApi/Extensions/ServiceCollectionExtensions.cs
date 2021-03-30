﻿using EncompassApi.Clients;
using EncompassApi.Configuration;
using EncompassApi.MessageHandlers;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

using Polly;
using Polly.Extensions.Http;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace EncompassApi.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddEncompassTokenHandlerWithRetry(this IServiceCollection services, EncompassTokenClientOptions encompassTokenClientOptions)
        {
            var clientParameters = new ClientParameters
            {
                ApiClientId = encompassTokenClientOptions.ClientId,
                ApiClientSecret = encompassTokenClientOptions.ClientSecret
            };

            clientParameters.CustomFieldsCacheInitialization = EncompassApi.CacheInitialization.Never;
            services.AddSingleton(clientParameters);

            IOptions<EncompassTokenClientOptions> options = Options.Create(encompassTokenClientOptions);

            var retryPolicy = HttpPolicyExtensions.HandleTransientHttpError().RetryAsync(encompassTokenClientOptions.RetryCount);
            var timeoutPolicy = Policy.TimeoutAsync<HttpResponseMessage>(encompassTokenClientOptions.TimeoutInSeconds);

            services.AddSingleton(options);
            services.AddHttpClient(encompassTokenClientOptions.ClientName, c => {
                c.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic",
                    Convert.ToBase64String(
                        Encoding.UTF8.GetBytes(
                            $"{WebUtility.UrlEncode(encompassTokenClientOptions.ClientId)}:{WebUtility.UrlEncode(encompassTokenClientOptions.ClientSecret)}")));
            })
                .AddPolicyHandler(retryPolicy)
                .AddPolicyHandler(timeoutPolicy);

            services.AddScoped<ITokenClient>(sp =>
                new EncompassTokenClient(sp.GetService<IHttpClientFactory>().CreateClient(encompassTokenClientOptions.ClientName), options));

            services.AddHttpClient("EncompassClient", c =>
            {
                c.BaseAddress = new Uri(encompassTokenClientOptions.BaseUrl);
            })
                .AddHttpMessageHandler(sp => new TokenHandler(sp.GetService<ITokenClient>()))
                .AddPolicyHandler(retryPolicy)
                .AddPolicyHandler(timeoutPolicy);

            services.AddTransient<IEncompassApiClient>(sp => new EncompassApiService(sp.GetService<IHttpClientFactory>().CreateClient("EncompassClient"), clientParameters));

            return services;
        }

        public static IServiceCollection AddFairwayTokenHandlerWithRetry(this IServiceCollection services, FairwayTokenClientOptions fairwayTokenClientOptions)
        {
            var clientParameters = new ClientParameters
            {
                ApiClientId = fairwayTokenClientOptions.ClientId,
                ApiClientSecret = fairwayTokenClientOptions.ClientSecret
            };

            clientParameters.CustomFieldsCacheInitialization = EncompassApi.CacheInitialization.Never;
            services.AddSingleton(clientParameters);

            IOptions<FairwayTokenClientOptions> tokenClientIOptions = Options.Create(fairwayTokenClientOptions);

            var retryPolicy = HttpPolicyExtensions.HandleTransientHttpError().RetryAsync(fairwayTokenClientOptions.RetryCount);
            var timeoutPolicy = Policy.TimeoutAsync<HttpResponseMessage>(fairwayTokenClientOptions.TimeoutInSeconds);

            services.AddSingleton(tokenClientIOptions);
            services.AddHttpClient(fairwayTokenClientOptions.ClientName)
                .AddPolicyHandler(retryPolicy)
                .AddPolicyHandler(timeoutPolicy);

            services.AddScoped<ITokenClient>(sp =>
                new FairwayTokenClient(sp.GetService<IHttpClientFactory>().CreateClient(fairwayTokenClientOptions.ClientName), tokenClientIOptions));

            services.AddHttpClient("EncompassClient")                
                .AddHttpMessageHandler(sp => new TokenHandler(sp.GetService<ITokenClient>()))
                .AddPolicyHandler(retryPolicy)
                .AddPolicyHandler(timeoutPolicy);

            services.AddTransient<IEncompassApiClient>(sp => new EncompassApiService(sp.GetService<IHttpClientFactory>().CreateClient("EncompassClient"), clientParameters));

            return services;
        }

        public static EncompassHttpClientBuilder AddEncompassHttpClient(this IServiceCollection services, Action<HttpClient> config)
        {
            services.Configure(config);
            var httpClient = services.AddHttpClient("EncompassClient", config);

            return new EncompassHttpClientBuilder(httpClient, services);
        }

        public static EncompassHttpClientBuilder AddEncompassHttpClient(this IServiceCollection services , Action<HttpClientOptions> config)
        {
            services._addHttpClientOptions(config);

            var httpClient = services.AddHttpClient("EncompassClient", (s, c) =>
             {
                 var options = s.GetRequiredService<IOptions<HttpClientOptions>>();
                 if (options != null)
                 {
                     
                     foreach (var encoding in options.Value.CompressionOptions.DecompressionMethods)
                     {
                         c.DefaultRequestHeaders.Add(name: "Accept-Encoding", value: encoding.ToString());
                     }
                 }

             }).ConfigurPrimaryHttpClientHandler(services.BuildServiceProvider());

            return new EncompassHttpClientBuilder(httpClient, services);
        }

        public static EncompassHttpClientBuilder AddEncompassHttpClient(this IServiceCollection services, Action<HttpClientOptions> config, Action<HttpClient> configureClient)
        {
            services._addHttpClientOptions(config);
      
            var httpClient = services.AddHttpClient("EncompassClient", (s, c) =>
            {
                var options = s.GetRequiredService<IOptions<HttpClientOptions>>();
                if (options != null && options.Value.CompressionOptions.DecompressionMethods != null)
                {
                    foreach (var encoding in options.Value.CompressionOptions.DecompressionMethods)
                    {
                        c.DefaultRequestHeaders.Add(name: "Accept-Encoding", value: encoding.ToString());
                    }
                }

            }).ConfigurPrimaryHttpClientHandler(services.BuildServiceProvider());

            httpClient.ConfigureHttpClient(configureClient);
            
            return new EncompassHttpClientBuilder(httpClient, services);

        }

        static void _addHttpClientOptions(this IServiceCollection services, Action<HttpClientOptions> config)
        {
            HttpClientOptions httpClientOptions = new HttpClientOptions();
            config(httpClientOptions);
            services.PostConfigure(config);
        }
    }


    public class EncompassHttpClientBuilder
    {
        private readonly IHttpClientBuilder _builder;
        private readonly HttpClientOptions _options;

        public EncompassHttpClientBuilder(IHttpClientBuilder builder, IServiceCollection services)
        {
            var options = services.BuildServiceProvider().GetRequiredService<IOptions<HttpClientOptions>>();
            if (options == null) throw new NullReferenceException("Options cannot be null!");
            _builder = builder;
            _options = options.Value;
        }

        public  EncompassHttpClientBuilder AddEncompassTokenMessageHandler()
        {
            _builder.AddHttpMessageHandler(sp => new TokenHandler(sp.GetService<ITokenClient>()));
            return this;
        }

        public EncompassHttpClientBuilder AddEncompassMessageHandler (Func<IServiceProvider, DelegatingHandler> func)
        {
            _builder.AddHttpMessageHandler(func);
            return this;
        }

        public EncompassHttpClientBuilder AddEncompassRetryPolicyHandler()
        {
            var retryPolicy = HttpPolicyExtensions.HandleTransientHttpError().RetryAsync(_options.TokenClientOptions.RetryCount);
            _builder.AddPolicyHandler(retryPolicy);
            return this;
        }

        public EncompassHttpClientBuilder AddEncompassTimeoutPolicyHandler()
        {
            var timeoutPolicy = Policy.TimeoutAsync<HttpResponseMessage>(_options.TokenClientOptions.TimeoutInSeconds);
            _builder.AddPolicyHandler(timeoutPolicy);
            return this;
        }

        public EncompassHttpClientBuilder AddEncompassPolicyHandler(IAsyncPolicy<HttpResponseMessage> policy)
        {
            _builder.AddPolicyHandler(policy);
            return this;
        }

        public void Build(IServiceCollection service)
        {
            service.AddTransient<IEncompassApiClient>(sp => new EncompassApiService(sp.GetService<IHttpClientFactory>().CreateClient("EncompassClient"), _options.ClientParameters));

        }

    }

}