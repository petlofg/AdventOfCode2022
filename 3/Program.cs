string[] lines = File.ReadAllLines(@".\input.txt");

PartOne(lines);
PartTwo(lines);

static void PartOne(string[] lines)
{
	int sum = 0;
	foreach (string line in lines)
	{
		string comp1 = line[..(line.Length / 2)];
		string comp2 = line[(line.Length / 2)..];

		HashSet<char> comp1Set = new(comp1);
		HashSet<char> comp2Set = new(comp2);
		char common = comp1Set.Intersect(comp2Set).First();

		sum += GetPrio(common);
	}

	Console.WriteLine(sum);
}

static void PartTwo(string[] lines)
{
	HashSet<char>[] rucksacks = { new(), new(), new() };
	int sum = 0;

	for (int i = 1; i <= lines.Length; i++)
	{
		rucksacks[(i - 1) % 3] = new(lines[i - 1]);

		if (i % 3 == 0)
		{
			char badge = rucksacks[0].Intersect(rucksacks[1]).Intersect(rucksacks[2]).First();
			sum += GetPrio(badge);
			rucksacks = new HashSet<char>[] { new(), new(), new() };
		}

	}

	Console.WriteLine(sum);
}

static int GetPrio(char x)
{
	if ((int)x >= 65 && (int)x <= 90)
		return (int)x - 38;
	else
		return (int)x - 96;
}