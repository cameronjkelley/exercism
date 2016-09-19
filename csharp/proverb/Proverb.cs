class Proverb
{
	private static string[] proverb = {
		"For want of a nail the shoe was lost.\n",
		"For want of a shoe the horse was lost.\n",
		"For want of a horse the rider was lost.\n",
		"For want of a rider the message was lost.\n",
		"For want of a message the battle was lost.\n",
		"For want of a battle the kingdom was lost.\n",
		"And all for the want of a horseshoe nail."
	};
	public static string Line(int num)
	{
		return proverb[num - 1].Trim('\n');
	}
	public static string AllLines()
	{
		return string.Join("", proverb);
	}
}
