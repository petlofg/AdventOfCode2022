string input = File.ReadAllText(@".\input.txt");

// Part 1
PrintPosition(input, 4);

// Part 2
PrintPosition(input, 14);

static void PrintPosition(string input, int windowLength)
{
	for (int i = 0; i < input.Length - windowLength; i++)
	{
		string window = input.Substring(i, windowLength);
		HashSet<char> distinct = new(window);

		if (distinct.Count == windowLength)
		{
			Console.WriteLine(i + windowLength);
			break;
		}
	}
}
