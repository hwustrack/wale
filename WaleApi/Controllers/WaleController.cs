using Library.Clients;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace WaleApi.Controllers
{
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
    }
}
