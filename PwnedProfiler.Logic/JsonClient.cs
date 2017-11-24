using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace PwnedProfiler.Logic
{
    public class JsonClient
    {
        private const string UserAgent = "Pwned-Profiler-Web";
        private readonly HttpClient _client;
        private Queue<Task<HttpResponseMessage>> _queue = new Queue<Task<HttpResponseMessage>>();
        private static readonly Stopwatch Stopwatch = new Stopwatch();

        public JsonClient(Uri baseUrl)
        {
            _client = new HttpClient()
            {
                BaseAddress = baseUrl,
                DefaultRequestHeaders = { {"User-Agent","Pwned-Profiler-Web"} },
                Timeout = new TimeSpan(0,0,3)
            };
        }

        public string PerformRequest(Uri address)
        {
            lock (Stopwatch)
            {
                if (Stopwatch.IsRunning && Stopwatch.Elapsed < new TimeSpan(0, 0, 0, 0, 2000))
                {
                    Thread.Sleep(2000 - Stopwatch.Elapsed.Milliseconds);
                }
                Stopwatch.Restart();
                var result = _client.GetAsync(address).Result;
                if (result.StatusCode == (HttpStatusCode)429)
                {
                    throw new RateLimitException();
                }
                if (result.StatusCode != HttpStatusCode.OK)
                {
                    throw new HttpRequestException($"Invalid status code returned {result.StatusCode}");
                }
                var body = result.Content.ReadAsStringAsync().Result;
                return body;
            }
        }
    }
}
