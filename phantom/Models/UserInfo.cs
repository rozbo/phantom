using System;

namespace phantom.Models
{
    public class UserInfo
    {
        public Guid ID { get; set; }
        public Guid UserId { get; set; }
        public int Sex { get; set; }
        public int Age { get; set; }
        public DateTime RegDate { get; set; }
        public DateTime LastDate { get; set; }
        public string Bio { get; set; }
        public User User { get; set; }
    }
}