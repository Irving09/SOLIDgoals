using System;

// you can use the Strategy pattern to simplify the client so that it delegates complexity to dependent interfaces

public class OnlineCartAntiPattern {
	//Note: Updating/Adding each behavior requires a change to this class,
	
	public void Checkout(PaymentType paymentType) {
		switch(paymentType.GetPaymentType()) {
			case "CreditCard":
				//some complicated logic
				ProcessCreditCardPayment();
			break;
			case "Paypal":
				//some complicated logic
				ProcessPaypalPayment();
			break;
			case "GoogleCheckout":
				//some complicated logic
				ProcessGooglePayment();
			break;
			case "AmazonPayments":
				//some complicated logic
				ProcessAmazonPayment();
			break;
		}
	}
	
	private void ProcessCreditCardPayment() {
		Console.WriteLine("Hello Credit Card!");
	}
	
	private void ProcessPaypalPayment() {
		Console.WriteLine("Hello Paypal!");
	}
	
	private void ProcessGooglePayment() {
		Console.WriteLine("Hello Google!");
	}
	
	private void ProcessAmazonPayment() {
		Console.WriteLine("Hello Amazon!");
	}
}