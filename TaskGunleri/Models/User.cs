using System;
using System.Collections.Generic;
using System.Text;
using TaskGunleri.Interfaces;
using static Utils.Enums.Enums;

namespace TaskGunleri.Models
{
    class User : IEntity
    {
        private static int _id;
        public int Id { get; }

        public string Username { get; set; }
        public string Email { get; set; }
        public Role Role { get; set; }

        public User(string username,string email,Role role)
        {
            _id++;
            Id=_id;
            Username = username;
            Email = email;
            Role = role;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"Id: {Id}\nUsername: {Username}\nEmail: {Email}\nRole: {Role}");
        }



    }
}
