using History.Api.Enum;
using Microsoft.AspNetCore.Mvc;

namespace History.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HistoryController : ControllerBase
    {

        [HttpGet]
        [Route("trips")]
        public async Task<IActionResult> GetUserHistory(int userId, UserType userType)
        {
            return Ok("");
        }
    }
}
