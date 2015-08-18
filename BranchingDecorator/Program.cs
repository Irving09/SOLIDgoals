using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BranchingDecorator
{
    public class Program
    {
        public void Main(string[] args)
        {
            IComponent c1 = new Component1();
            IComponent c2 = new Component2();
        }
    }
}