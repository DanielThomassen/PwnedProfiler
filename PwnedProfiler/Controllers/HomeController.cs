using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PwnedProfiler.Models;

namespace PwnedProfiler.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string accountName)
        {
            var profiler = new Logic.PwnedProfiler();
            if (string.IsNullOrEmpty(accountName))
            {
                return View();
            }
            ViewBag.input = accountName;
            var result = profiler.ProfileAccount(accountName);
            return View(result.Result);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
