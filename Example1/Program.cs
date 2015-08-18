using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Example1
{
    public class Program
    {
        public void Main(string[] args)
        {
            //  Console.WriteLine("Hello World");
            var test1 = new DecoratorComponent(new ConcreteComponent());
            var test2 = new DecoratorComponent(new ConcreteComponent2()); 
            test1.HelloWorld();
            test2.HelloWorld();
        }
    }
}