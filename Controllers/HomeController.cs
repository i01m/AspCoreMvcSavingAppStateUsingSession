using AspCoreMvcSavingAppStateUsingSession.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;


namespace AspCoreMvcSavingAppStateUsingSession.Controllers
{
    public class HomeController : Controller
    {
        //jan26_2022 the only feasuble way to display number of users(sessions)
        //is to save current user session ID in database, then add other users(browsers) IDs 
        //to the same collection, then read them and display count.
        //Now once a new browser accesses, it goes to Home controller and creates new instance of TestModel
        //Therefore it overwrittes the old value and shows Current User 1.

        private readonly ILogger<HomeController> _logger;
        private const string sessionKey = "mySessionKey";
        private TestModel modelInstance = new TestModel();
        
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {           
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public IActionResult Index(string value) 
        {
            HttpContext.Session.SetString(sessionKey, value);
            return View();
        }

        public IActionResult Test()
        {
            //var keys = HttpContext.Session.Keys;
            modelInstance.AddSessionToList(HttpContext.Session.GetString(sessionKey));
                        
            return View(modelInstance.UsersCount as object);
            
            //find solution how to display # of users (sessions)?
            //object numberOfUsers = HttpContext.Session.Keys;
            //return View(numberOfUsers);
        }      
    }
}
