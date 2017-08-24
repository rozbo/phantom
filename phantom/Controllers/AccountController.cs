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
using phantom.ViewModels;

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
                    new Claim(ClaimTypes.Name, user.Username),
                    new Claim(ClaimTypes.Role,user.Role)
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

        [HttpPost]
        public async Task<IActionResult>  register(Register r){
            try
            {
                if(!ModelState.IsValid){
                    return View(r);
                }

                if (!r.Agree)
                {
                    ModelState.AddModelError("Agree", "你必须同意注册协议！");
                    return View(r);
                }
                if (_context.User.Any(t => t.Email == r.Email))
                {
                    ModelState.AddModelError("Email", "该邮箱已经注册过了！");
                    return View(r);
                }
                var user=await _context.User.AddAsync(new User
                    {
                        Username = r.Email.Split("@")[0],
                        Password = r.Password,
                        Email = r.Email,
                        Role = "Normal"
                    }
                );
                var info=await _context.UserInfo.AddAsync(new UserInfo
                {
                    LastDate = DateTime.Now,
                    RegDate = DateTime.Now,
                    Sex = 0,
                    Age = 0,
                    Nickname = user.Entity.Username,
                    UserId = user.Entity.ID
                });
                await _context.SaveChangesAsync();
                var identity = new ClaimsIdentity(new[] {
                    new Claim(ClaimTypes.Name, user.Entity.Username),
                    new Claim(ClaimTypes.Role,user.Entity.Role)
                }, CookieAuthenticationDefaults.AuthenticationScheme);
                var pp = new ClaimsPrincipal (identity);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,pp);
                return RedirectToAction("Index", "Home");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }
    }
}
