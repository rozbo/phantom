using System;

namespace phantom.Models
{
    public class UserInfo
    {
        public Guid ID;
        public Guid UserId;
        public int Sex;
        public int Age;
        public DateTime RegDate;
        public DateTime LastDate;
        public string Bio;
        public User User;
    }
}