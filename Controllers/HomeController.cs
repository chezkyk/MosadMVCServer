using Microsoft.AspNetCore.Mvc;
using MosadMVCServer.Models;
using System.Diagnostics;

namespace MosadMVCServer.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly HttpClient _httpClient;
        public HomeController(ILogger<HomeController> logger, HttpClient httpClient)
        {
            _logger = logger;
            _httpClient = httpClient;
        }

        public async Task<IActionResult> Index()
        {
            var active = await ReturnsSumOfActiveAgents();
            var notActive = await ReturnsSumOfNotActiveAgents();
            //
            var alive = await ReturnsSumOfAliveTargets();
            var dead = await ReturnsSumOfDeadTargets();
            //
            var offer = await ReturnsSumOfOfferMissions();
            var inMission = await ReturnsSumOfInMissionMissions();
            var finish = await ReturnsSumOfFinishMissions();
            //
            var goodActiveAgents = await ReturnsSumOfGoodActiveAgents();
            //
            var viewModel = new HomeView()
            {
                ActiveAgents = active,
                NotActiveAgents = notActive,
                AliveTarget = alive,
                DeadTarget = dead,
                OfferMission = offer,
                InMissionMission = inMission,
                FinishMission = finish,
                RelationOfAgentsToTargets = $"{(active + notActive)} :  {(alive + dead)}",
                GoodActiveAgents = $"{goodActiveAgents["goodActiveList"]} : {goodActiveAgents["goodTargetscount"]}"

            };
            return View(viewModel);
        }
        public async Task<int> ReturnsSumOfActiveAgents()
        {
            var sumOfActiveAgents = await _httpClient.GetFromJsonAsync<int>("http://localhost:5125/agents/sumofactiveagents");
            return sumOfActiveAgents;
        }
        public async Task<int> ReturnsSumOfNotActiveAgents()
        {
            var SumOfNotActiveAgents = await _httpClient.GetFromJsonAsync<int>("http://localhost:5125/agents/sumofnotActiveagents");
            return SumOfNotActiveAgents;
        }
        //
        public async Task<int> ReturnsSumOfAliveTargets()
        {
            var sumOfAliveTargets = await _httpClient.GetFromJsonAsync<int>("http://localhost:5125/targets/sumofalivetargets");
            return sumOfAliveTargets;
        }
        public async Task<int> ReturnsSumOfDeadTargets()
        {
            var sumOfDeadTargets = await _httpClient.GetFromJsonAsync<int>("http://localhost:5125/targets/sumofdeadtargets");
            return sumOfDeadTargets;
        }
        //
        public async Task<int> ReturnsSumOfOfferMissions()
        {
            var sumOfOfferMissions = await _httpClient.GetFromJsonAsync<int>("http://localhost:5125/missions/sumofoffermissions");
            return sumOfOfferMissions;
        }
        public async Task<int> ReturnsSumOfInMissionMissions()
        {
            var sumOfInMissionMissions = await _httpClient.GetFromJsonAsync<int>("http://localhost:5125/missions/sumofInmissionmissions");
            return sumOfInMissionMissions;
        }
        public async Task<int> ReturnsSumOfFinishMissions()
        {
            var sumOfFinishMissions = await _httpClient.GetFromJsonAsync<int>("http://localhost:5125/missions/sumoffinishmissions");
            return sumOfFinishMissions;
        }//SumOfGoodActiveAgents
        public async Task<Dictionary<string, int>> ReturnsSumOfGoodActiveAgents()
        {
            var sumOfGoodActiveAgents = await _httpClient.GetFromJsonAsync<Dictionary<string, int>>("http://localhost:5125/agents/sumofgoodactiveagents");
            return sumOfGoodActiveAgents;
        }//SumOfGoodActiveAgents
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
