using System.Text.RegularExpressions;

string[] lines = File.ReadAllLines(@".\input.txt");

List<Stack<char>> stacks = BuildStacks(lines, out int instrStartPos);

// Move instructions
List<string> instructionLines = lines.Skip(instrStartPos).ToList();

PartOne(stacks, instructionLines);

// Reset stacks
stacks = BuildStacks(lines, out _);
PartTwo(stacks, instructionLines);

static void PartOne(List<Stack<char>> stacks, List<string> instructionLines)
{
	Regex moveRx = new(@"move (?<quantity>\d*) from (?<from>\d*) to (?<to>\d*)");

	foreach (string line in instructionLines)
	{
		
		Match m = moveRx.Match(line);
		int quantity = int.Parse(m.Groups["quantity"].Value);
		int fromIdx = int.Parse(m.Groups["from"].Value) - 1;
		int toIdx = int.Parse(m.Groups["to"].Value) - 1;

		for (int i = 0; i < quantity; i++)
		{
			char top = stacks[fromIdx].Pop();
			stacks[toIdx].Push(top);
		}
	}

	for (int i = 0; i < stacks.Count; i++)
	{
		Console.Write(stacks[i].Peek());
	}

	Console.WriteLine();
}

static void PartTwo(List<Stack<char>> stacks, List<string> instructionLines)
{
	Regex moveRx = new(@"move (?<quantity>\d*) from (?<from>\d*) to (?<to>\d*)");

	foreach (string line in instructionLines)
	{

		Match m = moveRx.Match(line);
		int quantity = int.Parse(m.Groups["quantity"].Value);
		int fromIdx = int.Parse(m.Groups["from"].Value) - 1;
		int toIdx = int.Parse(m.Groups["to"].Value) - 1;

		Stack<char> interm = new();

		for (int i = 0; i < quantity; i++)
		{
			char top = stacks[fromIdx].Pop();
			interm.Push(top);
		}

		for (int i = 0; i < quantity; i++)
		{
			char top = interm.Pop();
			stacks[toIdx].Push(top);
		}

	}

	for (int i = 0; i < stacks.Count; i++)
	{
		Console.Write(stacks[i].Peek());
	}

	Console.WriteLine();
}


static List<Stack<char>> BuildStacks(string[] lines, out int instrStartPos)
{
	List<Stack<char>> stacks = new();
	List<string> matrixLines = new();
	bool stacksBuilt = false;

	int x = 1;
	foreach (string line in lines)
	{
		if (!stacksBuilt)
		{
			matrixLines.Add(line);
			if (string.IsNullOrWhiteSpace(line))
			{
				stacksBuilt = true;
				break;
			}
		}
		x++;
	}

	List<List<char>> stackMx = BuildMatrix(matrixLines.Take(matrixLines.Count - 2).ToList());

	int stackCount = stackMx[0].Count;

	for (int i = 0; i < stackCount; i++)
		stacks.Add(new Stack<char>());

	for (int i = stackMx.Count - 1; i >= 0; i--)
	{
		for (int t = 0; t < stackMx[i].Count; t++)
		{
			if (stackMx[i][t] != ' ')
				stacks[t].Push(stackMx[i][t]);
		}
	}

	instrStartPos = x;
	return stacks;
}

static List<List<char>> BuildMatrix(List<string> lines)
{
	List<List<char>> stackMx = new();

	foreach (string line in lines)
	{
		List<char> currRow = new();
		for (int i = 0; i < line.Length; i++)
		{
			if (char.IsNumber(line[i]))
				break;
			if ((i - 1) % 4 == 0)
				currRow.Add(line[i]);
		}
		stackMx.Add(currRow);
	}

	return stackMx;
}
