using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using phantom.Interfaces;
using phantom.Models;

namespace phantom.Services
{
    public class UserServices : IUserServices
    {
        private readonly MyDbContext _dbContext;
        private UserInfo _userInfo=null;
        private readonly string _userName;
        private readonly ClaimsPrincipal _user;

        public UserServices(MyDbContext dbContext,IHttpContextAccessor context)
        {
            _dbContext = dbContext;
            _userName = context.HttpContext.User.Identity.Name;
            _user = context.HttpContext.User;
        }

        public bool isLogin()
        {
            return _user.Identity.IsAuthenticated;
        }

        public UserInfo GetUserInfo()
        {
            if (null==_userInfo)
            {
                _userInfo= _dbContext.UserInfo.FirstOrDefault(t => t.User.Username == _userName);
            }
            return _userInfo;
        }
    }
}