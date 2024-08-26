using Microsoft.AspNetCore.Mvc;
using MosadMVCServer.Models;
using System.Text.Json;

namespace MosadMVCServer.Controllers
{
    public class AgentsController : Controller
    {
        private readonly ILogger<AgentsController> _logger;
        private HttpClient _httpClient;
        public AgentsController(ILogger<AgentsController> logger, HttpClient httpClient)
        {
            _logger = logger;
            _httpClient = httpClient;
        }
        public async Task<IActionResult> Agents()
        {
            List<Agent> agents = await ReturnsListOfAgents();
            return View(agents);
        }
        public async Task<List<Agent>> ReturnsListOfAgents()
        {
            var agentsList = await _httpClient.GetFromJsonAsync<List<Agent>>("http://localhost:5125/agents");
            return agentsList;
        }
		public async Task<IActionResult> Details(int id)
		{
			var mission = await GetMissionById(id);
			return View(mission);
		}
		//
		public async Task<int> ReturnsAmountOfKills(int id)
		{
			var amountOfKills = await _httpClient.GetFromJsonAsync<int>($"http://localhost:5125/missions/amountofkills/{id}");
			return amountOfKills;
		}
		public async Task<double> ReturnsTimeLeft(int id)
		{
			var timeLeft = await _httpClient.GetFromJsonAsync<double>($"http://localhost:5125/timeleft/{id}");
			return timeLeft;
		}
		//
		public async Task<Mission> GetMissionById(int id)
		{
			Mission mission = await _httpClient.GetFromJsonAsync<Mission>($"http://localhost:5125/missions/get/{id}");
			return mission;
		}
	}
}
