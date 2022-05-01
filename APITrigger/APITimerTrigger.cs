using System;
using System.Net.Http;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace APITrigger
{
    public class APITimerTrigger
    {
        private IConfiguration _configuration;

        public APITimerTrigger(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [FunctionName("APITimerTrigger")]
        public void Run([TimerTrigger("*/3 * * * * *")]TimerInfo myTimer, ILogger log)
        {
            log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");
            string api = _configuration["API"];
            if (!string.IsNullOrEmpty(api))
            {
                HttpClient client = new HttpClient();
                client.GetAsync(api);
            }
        }
    }
}
