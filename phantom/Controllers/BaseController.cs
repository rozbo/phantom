using phantom.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using phantom.Logics;

namespace phantom.Controllers
{
    public class BaseController:Controller
    {
        protected readonly MyDbContext _context;
        protected readonly UserLogic _userLogic;
        protected readonly IServiceCollection _service;
        public BaseController(MyDbContext context,IServiceCollection services)
        {
            _service = services;
            //_userLogic=new User(_context,User);
            //_service.AddT
        }
    }
}