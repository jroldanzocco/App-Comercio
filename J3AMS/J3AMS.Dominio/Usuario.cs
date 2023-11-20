﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace J3AMS.Dominio
{
    public enum UserRole
    {
        ADMIN = 1,
        NORMAL = 2
    }
    public class Usuario
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public UserRole UserRole { get; set; }

        public Usuario(string userName, string password, bool admin)
        {
            UserName = userName;
            Password = password;
            UserRole = admin ? UserRole.ADMIN : UserRole.NORMAL;
        }

    }
}
