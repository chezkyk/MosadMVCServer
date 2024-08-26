using Microsoft.AspNetCore.Mvc;
using MosadMVCServer.Models;
using System.Net.Http.Headers;
using System.Text.Json;

namespace MosadMVCServer.Controllers
{
    public class LoginController : Controller
    {
        //_httpClient.DefaultRequestHeaders.Add("login",$"Bearer  {Token}");
        private readonly ILogger<LoginController> _logger;
        private readonly HttpClient _httpClient;
        //public static string token;
        public LoginController(ILogger<LoginController> logger, HttpClient httpClient)
        {
            _logger = logger;
            _httpClient = httpClient;
        }
        public IActionResult Login()
        {
            ViewBag.LoginStatus = TempData["LoginStatus"];
            return View();
            
        }
        [HttpPost]
        public async Task<IActionResult> Login(UserDetails userDetails)
        {

            _httpClient.BaseAddress = new Uri("http://localhost:5125");

            HttpResponseMessage response = await _httpClient.PostAsJsonAsync("/auth/login", userDetails);

            if (response.IsSuccessStatusCode)
            {
                TempData["LoginStatus"] = "Login successful!";

                var result = await response.Content.ReadAsStringAsync();
                var jsonResult = JsonSerializer.Deserialize<Dictionary<string, string>>(result);
                string token = jsonResult["token"];
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                

            }
            else
            {

                TempData["LoginStatus"] = "Invalid login attempt. Please check your credentials.";
            }
            return RedirectToAction("Login");
           
        }
    }
}
