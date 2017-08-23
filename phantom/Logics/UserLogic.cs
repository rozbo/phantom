using System;
using System.Linq;
using System.Security.Claims;
using phantom.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using phantom.Interfaces;

namespace phantom.Logics
{


    public class UserLogic : IUserLogic
    {
        private readonly MyDbContext _dbContext;
        private UserInfo _userInfo=null;
        private readonly string _userName;
        private readonly ClaimsPrincipal _user;
        public UserLogic(MyDbContext dbContext,AuthorizationHandlerContext context)
        {
            _dbContext = dbContext;
            _userName = context.User.Identity.Name;
            _user = context.User;
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