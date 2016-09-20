using System;

class Grains
{
	public static ulong Square(int num)
	{
		return (ulong)Math.Pow(2, num - 1);
	}
	public static ulong Total()
	{
		return Square(65) - 1;
	}
}
