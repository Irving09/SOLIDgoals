using System.Collections.Generic;

public class OnlineCart {
	private IDictionary<string, IPaymentStrategy> paymentStrategies;
	
	public OnlineCart() {
		paymentStrategies = new Dictionary<string, IPaymentStrategy>();
		paymentStrategies.Add(PaymentType.CreditCard, new CreditCardPaymentStrategy());
		paymentStrategies.Add(PaymentType.Paypal, new PaypalPaymentStrategy());
		paymentStrategies.Add(PaymentType.AmazonPayments, new AmazonPaymentStrategy());
		paymentStrategies.Add(PaymentType.GoogleCheckout, new GooglePaymentStrategy());
	}
	
	public void Checkout(PaymentType type) {
		paymentStrategies[type.GetPaymentType()].ProcessPayment();
	}
}