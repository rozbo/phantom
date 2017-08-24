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
        private readonly IUserServices _user;
        public UserController(MyDbContext dbContext,IUserServices user)
        {
            _dbContext = dbContext;
            _user = user;
        }

        public string profile()
        {
//            IUserLogic userLogic=(IUserLogic)HttpContext.RequestServices.GetService(typeof(IUserLogic));
//            return userLogic.isLogin();
            return _user.GetUserInfo().UserId.ToString();
        }
    }
}