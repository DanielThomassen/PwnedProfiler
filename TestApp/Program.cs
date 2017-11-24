using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PwnedProfiler.Logic;

namespace TestApp
{
    class Program
    {
        static void Main(string[] args)
        {

            var tasks = new List<Task>();

            for (int i = 0; i < 100; i++)
            {
                tasks.Add(Task.Factory.StartNew(() =>
                {
                    var client = new JsonClient(new Uri("https://haveibeenpwned.com/api/v2/"));
                    var account = "dkthomassen@gmail.com";
                    var task = client.PerformRequest(new Uri($"breachedaccount/{account}", UriKind.Relative));
                    Console.WriteLine(task);
                }));
            }
            Task.WaitAll(tasks.ToArray());
        }
    }
}
