using System;
using System.Collections.Generic;
using System.Linq;

public class LargestSeriesProduct
{
	private List<int> digits = new List<int>();
	public LargestSeriesProduct (string digits)
	{
		this.digits = digits.Select(x => int.Parse(x.ToString())).ToList();
	}
	public int GetLargestProduct(int length) 
	{
		if (length > digits.Count) throw new ArgumentException();
		if (length == 0) return 1;

		int largestProduct = 0;
		for (int i = 0; i <= digits.Count - length; i++)
		{
			int product = digits[i];
			for (int j = 1; j < length; j++)
			{
				product *= digits [i + j]; 
			}
			if (product > largestProduct) largestProduct = product;
		}
		return largestProduct;
	}
}
