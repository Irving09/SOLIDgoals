using System;

public class Contracts {
	public decimal CalculateShippingCost(
       float packageWeightInKilograms, Size<float> packageDimensionsInInches)
	{
		if (packageWeightInKilograms <= 0f) {
			throw new ArgumentOutOfRangeException("packageWeightInKilograms",
				"Package weight must be positive and non-zero");
		}
		
		if (packageDimensionsInInches.X <= 0f || packageDimensionsInInches.Y <= 0f)
           throw new ArgumentOutOfRangeException("packageDimensionsInInches",
			   "Package dimensions must be positive and non-zero");
		var result = decimal.MinusOne;
		
		if(result <= decimal.Zero) {
			throw new ArgumentOutOfRangeException("return", "The return value is out of range");
		}
		return result;
   	}
	public class Size<T> {
		public T X { get; set; }
		public T Y { get; set; }
	} 
}