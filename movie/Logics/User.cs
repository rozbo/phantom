using movie.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;

namespace movie.Logics
{
    public class User
    {
        private readonly MyDbContext _dbContext;
        public User(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool isLogin(CookieValidatePrincipalContext context)
        {
            return context.Principal.Identity.IsAuthenticated;
        }
    }
}