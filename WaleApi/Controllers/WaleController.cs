using Library.Clients;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace WaleApi.Controllers
{
    /// <summary>
    /// Controller that will call the web accessible library.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class WaleController : ControllerBase
    {
        private readonly IWebAccessibleLibraryClient _webAccessibleLibraryClient;

        public WaleController(IWebAccessibleLibraryClient webAccessibleLibraryClient)
        {
            _webAccessibleLibraryClient = webAccessibleLibraryClient ?? throw new ArgumentNullException(nameof(webAccessibleLibraryClient));
        }

        // GET api/wale
        [HttpGet]
        public async Task<ActionResult> Get(CancellationToken cancellationToken)
        {
            string response = await _webAccessibleLibraryClient.Function1(cancellationToken);
            return Ok(response);
        }

        // GET api/wale/MostFrequentElementInArrayLinq
        [HttpPost("MostFrequentElementInArrayLinq")]
        public async Task<ActionResult> FindMostFrequentElementInArrayLinq([FromBody] int[] nums, CancellationToken cancellationToken)
        {
            int response = await _webAccessibleLibraryClient.GetMostFrequentElementInArrayLinq(nums, cancellationToken);
            return Ok(response);
        }
    }
}
