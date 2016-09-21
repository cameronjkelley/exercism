class HelloWorld
{
	public static string Hello(string name)
	{
		return name == null ? "Hello, World!" : $"Hello, {name}!";
	}
}