using System.Linq;
using phantom.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using phantom.Interfaces;
using phantom.Logics;


namespace phantom.Controllers
{
    [Authorize]
    public class UserController : Controller
    {

        private readonly MyDbContext _dbContext;
        public UserController(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool profile()
        {
            IUserLogic userLogic=(IUserLogic)HttpContext.RequestServices.GetService(typeof(IUserLogic));
            return userLogic.isLogin();
        }
    }
}