using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PredicateDecorator
{
    public class Program
    {
        public void Main(string[] args)
        {
            DateTester dt = new DateTester();
            PredicateComponent test1 = new PredicateComponent(new Component1(), new Predicate(dt));
            PredicateComponent test2 = new PredicateComponent(new Component2(), new Predicate(dt));
            test1.Execute();
            test2.Execute();
        }
    }
}
