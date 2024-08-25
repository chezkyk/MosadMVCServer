using Microsoft.AspNetCore.Mvc;
using MosadMVCServer.Models;

namespace MosadMVCServer.Controllers
{
    public class TargetsController : Controller
    {
		private readonly ILogger<TargetsController> _logger;
		private HttpClient _httpClient;
		public TargetsController(ILogger<TargetsController> logger, HttpClient httpClient)
		{
			_logger = logger;
			_httpClient = httpClient;
		}
		public async Task<IActionResult> Targets()
		{
			List<Target> targets = await ReturnsListOfTargets();
			return View(targets);
		}
		public async Task<List<Target>> ReturnsListOfTargets()
		{
			var targetList = await _httpClient.GetFromJsonAsync<List<Target>>("http://localhost:5125/targets");
			return targetList;
		}
	}
}
