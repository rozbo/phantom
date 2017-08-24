using phantom.Models;

namespace phantom.Services
{
    public interface IUserServices
    {
        bool isLogin();
        UserInfo GetUserInfo();
    }
}