using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompositePattern
{
    public class Program
    {
        public void Main(string[] args)
        {
            CompositeComponent composite = new CompositeComponent();
            composite.AddComponent(new Leaf());
            composite.AddComponent(new Branch());
            composite.AddComponent(new Trunk());

            composite.Execute();
        }
    }
}