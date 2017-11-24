using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PwnedProfiler.Logic.Models;

namespace PwnedProfiler.Logic
{
    public class PwnedProfiler
    {

        /// <summary>
        /// Base url for logos
        /// </summary>
        private const string LogoBaseUrl = "https://haveibeenpwned.com/Content/Images/PwnedLogos/";

        /// <summary>
        /// Client used for handling Json requests
        /// </summary>
        private readonly JsonClient _client;

        /// <summary>
        /// Create a new instance of the profiler
        /// </summary>
        public PwnedProfiler()
        {
            _client = new JsonClient(new Uri("https://haveibeenpwned.com/api/v2/"));
        }

        /// <summary>
        /// Profile a specific account for breaches
        /// </summary>
        /// <param name="accountName"></param>
        /// <returns></returns>
        public async Task<Dictionary<string, List<Breach>>> ProfileAccount(string accountName)
        {
            var result = _client.PerformRequest(new Uri($"breachedaccount/{accountName}", UriKind.Relative));
            if (string.IsNullOrEmpty(result))
            {
                return  new Dictionary<string, List<Breach>>();
            }

            var breaches = JsonConvert.DeserializeObject<IEnumerable<Breach>>(result);

            var breachProfile = new Dictionary<string, List<Breach>>();

            foreach (var breach in breaches)
            {
                foreach (var breachDataClass in breach.DataClasses)
                {
                    if (breachProfile.ContainsKey(breachDataClass))
                    {
                        breachProfile[breachDataClass].Add(breach);
                    }
                    else
                    {
                        breachProfile.Add(breachDataClass,new List<Breach>{breach});
                    }
                }
            }
            return breachProfile;
        }
    }
}
