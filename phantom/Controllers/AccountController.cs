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
using Microsoft.AspNetCore.Authentication.Cookies;
using phantom.Models;
// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace phantom.Controllers
{
    public class AccountController : Controller
    {
        private readonly MyDbContext _context;

        public AccountController(MyDbContext context)
        {
            _context = context;
        }
		public string Index()
		{
			return "index";
		}

        public IActionResult info()
        {
            return View();
        }

        public string welcome()
        {
            var a=HttpContext.User.Claims.Count();
            var b = HttpContext.User.Identity.Name;
            return $"{a}welcome,{b}";
        }

        public string test(string name, int age){
            return HtmlEncoder.Default.Encode($"Hello {name}, age: {age}"); 
        }

        public IActionResult login(){
            return View();
        }

        public string Forbidden(){
            return "Forbidden";
        }

        [HttpPost]
        public async Task<IActionResult> login(Login l)
        {
            var user=this._context.User.FirstOrDefault(w=>w.Username==l.Username);
            if(user==null){
                ViewBag.Info="用户名不存在";
                return View(l);
            }
            if(user!=null &&
            user.Password.Equals(l.Password)){
                var identity = new ClaimsIdentity(new[] {
                    new Claim(ClaimTypes.Name, "lol"),
                    new Claim(ClaimTypes.Role,"Manage")
                }, CookieAuthenticationDefaults.AuthenticationScheme);
                var pp = new ClaimsPrincipal (identity);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,pp,new AuthenticationProperties
                {
                    IsPersistent = true
                });
                return RedirectToAction("Index", "Home");
            }else{
                ViewBag.Info="用户名或密码错误";
            }
            return View(l);
        }

        public async Task<IActionResult> logout(){
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }


        public IActionResult register(){
            return View();
        }
    }
}
