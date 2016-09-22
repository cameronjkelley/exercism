class HelloWorld
{
	public static string Hello(string input)
	{
		return input == null ? "Hello, World!" : $"Hello, {input}!";
	}
}
