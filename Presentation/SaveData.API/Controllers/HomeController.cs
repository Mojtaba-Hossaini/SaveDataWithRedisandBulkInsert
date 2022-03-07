using Microsoft.AspNetCore.Mvc;
using SaveData.Librarry.ApplicationService;
using SaveData.Librarry.Infrastructure.Contracts;

namespace SaveData.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICustomerRateHandler _handler;

        public HomeController(ILogger<HomeController> logger, ICustomerRateHandler handler)
        {
            _logger = logger;
            _handler = handler;
        }

        
        [HttpGet("HandleCustomer")]
        public async Task<IActionResult> HandleCustomer()
        {
            await _handler.Handle();
            return Ok();
        }
    }
}
