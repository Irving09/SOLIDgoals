using System;
public class PaymentType {
	public static readonly string CreditCard = "CreditCard";
	public static readonly string Paypal = "Paypal";
	public static readonly string GoogleCheckout = "GoogleCheckout";
	public static readonly string AmazonPayments = "AmazonPayments";
	private readonly string[] _types;
	private string _type;
	public PaymentType(int type) {
		_types = new string[] {
			CreditCard,
			Paypal,
			GoogleCheckout,
			AmazonPayments
		};
		_type = _types[new Random().Next(-1, 4)]; //TODO
	}
	
	public string GetPaymentType() {
		return _type; 
	}
}