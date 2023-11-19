using History.Api.Contracts;
using History.Api.Enum;
using History.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace History.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HistoryController : ControllerBase
    {
        private readonly IHistoryService _historyService;

        public HistoryController(IHistoryService historyService)
        {
            _historyService = historyService;
        }

        [HttpGet]
        [Route("trips")]
        public async Task<IActionResult> GetUserHistory(int userId, UserType userType)
        {
            var result = await _historyService.GetUserHistory(userId, userType);
            return Ok(result);
        }

        [HttpGet]
        [Route("trip")]
        public async Task<IActionResult> GetHistoryByScheduleId(int scheduleId)
        {
            var result = await _historyService.GetHistory(scheduleId);
            return Ok(result);
        }
    }
}
