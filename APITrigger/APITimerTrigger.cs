using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace APITrigger
{
    public class APITimerTrigger
    {
        [FunctionName("APITimerTrigger")]
        public void Run([TimerTrigger("*/3 * * * * *")]TimerInfo myTimer, ILogger log)
        {
            log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");
        }
    }
}
