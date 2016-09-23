using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reciprocity.Services
{
    public interface IGreeter
    {
        string GetGreeting();
    }
    public class Greeter : IGreeter
    {
        public string GetGreeting()
        {
            return "The Greeter Class Greets You";
        }
    }
}
