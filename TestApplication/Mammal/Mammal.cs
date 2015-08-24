using System;

public class Mammal : IMammal {
	public void walk() {
		Console.WriteLine("I am walking slowly");
	}
	
	public void run() {
		Console.WriteLine("I am running kind of fast");
	}
	
	public string getHairColor() {
		return "black";
	}
}