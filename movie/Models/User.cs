using System;
using System.ComponentModel.DataAnnotations;

namespace movie.Models
{
    public class User
    {
        public Guid ID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        
    }
}