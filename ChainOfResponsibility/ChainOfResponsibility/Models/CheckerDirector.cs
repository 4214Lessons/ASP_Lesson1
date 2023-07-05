using ChainOfResponsibility.Handlers;
using ChainOfResponsibility.Models.Derived;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsibility.Models
{
    public class CheckerDirector
    {
        public ICheckerBuilder Builder { get; set; }

        public bool MakeHumanChecker(Human human)
        {
            UsernameChecker usernameChecker = new();
            PasswordChecker passwordChecker = new();
            EmailChecker emailChecker = new();
            usernameChecker.Next = passwordChecker;
            passwordChecker.Next = emailChecker;

            return usernameChecker.Check(human);
        }
    }
}
