using Application_Contracts;
using EndPoint.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EndPoint.Controllers
{
    public class HomeController : Controller
    {

        private readonly IPersonApplication _personApplication;

        public HomeController(IPersonApplication personApplication)
        {
            _personApplication = personApplication;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            EditPerson createPerson = new()
            {
                Id = 1,
                Name = "Abas",
                BirthDate = DateTime.Now,
            };
            _personApplication.Edit(createPerson);
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
