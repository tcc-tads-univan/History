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

        [HttpPost]
        [Route("finish-trip")]
        public async Task<IActionResult> FinishTrip(CompleteTripRequest request)
        {
            await _historyService.CompleteTrip(request.StudentId, request.DriverId);
            return Ok();
        }
    }
}
