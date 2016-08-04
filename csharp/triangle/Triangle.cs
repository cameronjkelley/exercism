using System;

public enum TriangleKind
{
	Equilateral,
	Isosceles,
	Scalene
}

public class Triangle
{
	public static TriangleKind Kind(decimal a, decimal b, decimal c)
	{
		if (NotATriangle(a,b,c)) throw new TriangleException();

		if (IsEquilateral(a, b, c)) return TriangleKind.Equilateral;
		else if (IsIsosceles(a, b, c)) return TriangleKind.Isosceles;
		else return TriangleKind.Scalene;
	}

	private static bool NotATriangle(decimal a, decimal b, decimal c)
	{
		return a <= 0 || b <= 0 || c <= 0 || a + b <= c || b + c <= a || a + c <= b;
	}

	private static bool IsEquilateral(decimal a, decimal b, decimal c)
	{
		return a == b && b == c;
	}

	private static bool IsIsosceles(decimal a, decimal b, decimal c)
	{
		return (a == b && a != c) || (a == c && b != c) || (b == c && b != a);
	}
}

public class TriangleException : Exception { }
