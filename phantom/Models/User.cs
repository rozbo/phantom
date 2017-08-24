using System;
using System.ComponentModel.DataAnnotations;
using phantom.Interfaces;

namespace phantom.Models
{
    public class User : IUser
    {
        public int ID { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public string Role
        {
            get;
            set;
        }

    }

}