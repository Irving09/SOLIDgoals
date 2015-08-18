using System;

public class PaypalPaymentStrategy : IPaymentStrategy {
	public void ProcessPayment() {
		Console.WriteLine("Hello Paypal!");
	}
}