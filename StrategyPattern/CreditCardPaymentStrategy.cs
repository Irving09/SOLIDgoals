using System;

public class CreditCardPaymentStrategy : IPaymentStrategy {
	public void ProcessPayment() {
		Console.WriteLine("Hello CreditCard!");
	}
}