using System;

namespace phantom.Interfaces
{
    public interface IUser
    {
        Guid ID { get; set; }
        string Username { get; set; }
        string Password { get; set; }
    }
}