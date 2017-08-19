using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Authentication;
// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace movie.Controllers
{
    public class AccountController : Controller
    {
		public string Index()
		{
			return "index";
		}

        public string welcome(){
            return "welcome";
        }

        public string test(string name, int age){
            return HtmlEncoder.Default.Encode($"Hello {name}, age: {age}"); 
        }

        public string login(){
            return "login";
        }

        public string Forbidden(){
            return "Forbidden";
        }

        public async Task<String> login2(){
            
            var identity = new ClaimsIdentity(new[] {
                                new Claim(ClaimTypes.Name, "lol")
                            }, "ApplicationCookie");
            var pp = new ClaimsPrincipal (identity);
            await HttpContext.SignInAsync("MyCookieAuthenticationScheme",pp);
        
            return "ok";
        }


    }
}
