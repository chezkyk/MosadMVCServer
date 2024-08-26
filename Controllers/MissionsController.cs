using Microsoft.AspNetCore.Mvc;
using MosadMVCServer.Models;

namespace MosadMVCServer.Controllers
{
    public class MissionsController : Controller
    {

        private readonly ILogger<MissionsController> _logger;
        private HttpClient _httpClient;
        public MissionsController(ILogger<MissionsController> logger, HttpClient httpClient)
        {
            _logger = logger;
            _httpClient = httpClient;
        }
        public async Task<IActionResult> Missions()
        {
            List<Mission> missions = await ReturnsListOfMissions();
            return View(missions);
        }
        public async Task<List<Mission>> ReturnsListOfMissions()
        {
            var missionList = await _httpClient.GetFromJsonAsync<List<Mission>>("http://localhost:5125/missions");
            return missionList;
        }
		public async Task<ActionResult> AssignToMission(int id)
		{
            await _httpClient.PutAsync($"http://localhost:5125/missions/{id}",null);
			return RedirectToAction("Missions");
		}

	}
}
