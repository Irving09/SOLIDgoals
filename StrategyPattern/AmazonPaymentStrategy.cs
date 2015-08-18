using System;

public class AmazonPaymentStrategy : IPaymentStrategy {
	public void ProcessPayment() {
		Console.WriteLine("Hello AmazonPayment!");
	}
}