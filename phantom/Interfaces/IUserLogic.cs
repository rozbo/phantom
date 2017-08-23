using phantom.Models;

namespace phantom.Interfaces
{
    public interface IUserLogic
    {
        bool isLogin();
        UserInfo GetUserInfo();
    }
}