using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.exceptions
{
    public class PolicyNumberNotFoundException : Exception
    {
        public PolicyNumberNotFoundException(string message) : base(message) { }
    }
}
