using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace MvcMovie.Controllers
{
    public class HelloWorldController : Controller
    {

        //Get: /HellWorld/
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult MyPage()
        {
            return View();
        }

        //Get /HelloWorld/Welcome/
        public IActionResult Welcome(string name)
        {
            return View();
        }
    }
}
