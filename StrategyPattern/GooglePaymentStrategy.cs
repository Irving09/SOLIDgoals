using System;

public class GooglePaymentStrategy : IPaymentStrategy {
	public void ProcessPayment() {
		Console.WriteLine("Hello GoogleCheckout!");
	}
}