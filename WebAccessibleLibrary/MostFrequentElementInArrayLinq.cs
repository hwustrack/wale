using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Linq;

namespace WebAccessibleLibrary
{
    public static class MostFrequentElementInArrayLinq
    {
        [FunctionName("MostFrequentElementInArrayLinq")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest httpRequest,
            ILogger logger)
        {
            logger.LogInformation($"C# HTTP trigger function processed a request to MostFrequentElementInArrayLinq.");

            int[] nums = null;
            try
            {
                string requestBody = await new StreamReader(httpRequest.Body).ReadToEndAsync();
                nums = JsonConvert.DeserializeObject<int[]>(requestBody);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Failed to parse body in function MostFrequentElementInArrayLinq.");
                return new BadRequestObjectResult($"Please pass a list of integers in the request body.\r\n{ex.Message}");
            }

            int mostFrequent = nums.GroupBy(n => n)
                .OrderByDescending(g => g.Count())
                .First()
                .Key;

            return (ActionResult)new OkObjectResult(mostFrequent);
        }
    }
}
