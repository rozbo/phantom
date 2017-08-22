using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using movie.Interfaces;
using movie.Logics;
using movie.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace movie.Controllers
{
    //[Authorize]
    public class HelloController : Controller
    {
        private readonly IHello _hello;
        public HelloController(IHello hello)
        {
            this._hello = hello;
        }


        public IActionResult Index()
		{
            var s=HttpContext.User.Identity.Name;
            ViewBag.info=s;
			return View();
		}

        public string welcome()
        {
            var db=HttpContext.RequestServices.GetService<MyDbContext>();
            var la = db.User.FirstOrDefault(x => x.Username == "115115");
            var shello=this.HttpContext.RequestServices.GetService<IHello>();

            return la.Username+shello.Say()+this._hello.Say();
        }
        public bool isLogin(SignInManager<IUser> user)
        {
            return user.IsSignedIn(User);
        }

        public string test(string name, int age){
            return HtmlEncoder.Default.Encode($"Hello {name}, age: {age}"); 
        }
    }
}
