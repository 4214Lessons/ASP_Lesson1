using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsibility.Models.Derived
{
    public class PasswordChecker : BaseChecker
    {
        public override bool Check(object request)
        {
            if(request is Human human)
                if(!string.IsNullOrWhiteSpace(human.Password) && human.Password.Length >= 8)
                    return Next.Check(request);
            return false;
        }
    }
}
