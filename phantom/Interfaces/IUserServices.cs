using phantom.Models;

namespace phantom.Interfaces
{
    public interface IUserServices
    {
        bool isLogin();
        UserInfo GetUserInfo();
    }
}