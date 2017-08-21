using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace movie.Controllers
{
    [Authorize]
    public class HelloController : Controller
    {
		public IActionResult Index()
		{
            var s=HttpContext.User.Identity.Name;
            ViewBag.info=s;
			return View();
		}

        public string welcome(){
            return "welcome";
        }

        public string test(string name, int age){
            return HtmlEncoder.Default.Encode($"Hello {name}, age: {age}"); 
        }
    }
}
