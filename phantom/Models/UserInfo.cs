using System;

namespace phantom.Models
{
    public class UserInfo
    {
        public int ID { get; set; }
        public int UserId { get; set; }
        public string Nickname { get; set; }
        public int Sex { get; set; }
        public int Age { get; set; }
        public DateTime RegDate { get; set; }
        public DateTime LastDate { get; set; }
        public string Bio { get; set; }
        public User User { get; set; }
        public string Education{ get; set; }
        public string Location{ get; set; }
        public string Skills{ get; set; }
        public string Notes{ get; set; }
    }
}