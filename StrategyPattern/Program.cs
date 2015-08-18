using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StrategyPattern
{
    public class Program {
        public void Main(string[] args) {
            //  TestAntiPattern();
            TestStrategyPattern();
        }
        
        public static void TestAntiPattern() {
            PaymentType type = new PaymentType(new Random().Next(0, 10));
            OnlineCartAntiPattern test = new OnlineCartAntiPattern();
            test.Checkout(type);
        }
        
        public static void TestStrategyPattern() {
            PaymentType type = new PaymentType(new Random().Next(0, 10));
            OnlineCart test = new OnlineCart();
            test.Checkout(type); 
        }
    }
}