using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cost_Control.Models
{
    public class User
    {
        public int ID { get; }
        public string Login { get; }
        public string Password { get; }
        public string Email { get; }
        public string FIO { get; }
        public string Info { get; }

        public User(int ID, string Login, string Password, string Email, string FIO, string Info)
        {
            this.ID = ID;
            this.Login = Login;
            this.Password = Password;
            this.Email = Email;
            this.FIO = FIO;
            this.Info = Info;
        }
    }
}