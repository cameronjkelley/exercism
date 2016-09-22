class HelloWorld
{
	public static string Hello(string input)
	{
		return $"Hello, {input ?? "World"}!";
	}
}
