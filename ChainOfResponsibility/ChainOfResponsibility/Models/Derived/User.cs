using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsibility.Models.Derived
{
    public class User : Human
    {
        public User(string username, string email, string pass) : base(username, pass, email) { }
    }
}
