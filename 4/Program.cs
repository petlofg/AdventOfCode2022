

string[] lines = File.ReadAllLines(@".\input.txt");

PartOne(lines);
PartTwo(lines);

static void PartOne(string[] lines)
{
	int fullyContainedCount = 0;
	foreach (string line in lines)
	{
		string[] ranges = line.Split(",");
		HashSet<int> left = new(ExpandRange(ranges[0]));
		HashSet<int> right = new(ExpandRange(ranges[1]));

		if (left.Except(right).Count() == 0 || 
			right.Except(left).Count() == 0)
		{
			fullyContainedCount++;
		}
	}

	Console.WriteLine(fullyContainedCount);
}

static void PartTwo(string[] lines)
{
	int anyContainedCount = 0;
	foreach (string line in lines)
	{
		string[] ranges = line.Split(",");
		HashSet<int> left = new(ExpandRange(ranges[0]));
		HashSet<int> right = new(ExpandRange(ranges[1]));

		if (left.Intersect(right).Count() > 0)
		{
			anyContainedCount++;
		}
	}

	Console.WriteLine(anyContainedCount);
}

static List<int> ExpandRange(string range)
{
	string[] rangeParts = range.Split("-");

	int start = int.Parse(rangeParts[0]);
	int end = int.Parse(rangeParts[1]);

	List<int> expanded = new();

	for (int i = start; i <= end; i++)
	{
		expanded.Add(i);
	}

	return expanded;
}