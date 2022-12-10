string[] lines = File.ReadAllLines(@".\input.txt");

List<string> cycleInstr = new();

// Pad the instructions to sync with cycle
foreach (string line in lines)
{
	if (line.StartsWith("addx"))
		cycleInstr.Add("");

	cycleInstr.Add(line);
}

PartOne(cycleInstr);
PartTwo(cycleInstr);

static void PartOne(List<string> cycleInstr)
{
	List<int> cycles = new() { 20, 60, 100, 140, 180, 220 };
	int x = 1;
	int signalStrSum = 0;

	for (int i = 1; i <= cycleInstr.Count; i++)
	{
		x += HandleInstruction(cycleInstr[i - 1]);

		if (cycles.Contains(i))
			signalStrSum += x * i;
	}

	Console.WriteLine(signalStrSum);
}

static void PartTwo(List<string> cycleInstr)
{
	int x = 1;
	for (int i = 1; i <= 240; i++)
	{
		int crtLinePos = (i - 1) % 40;

		if (crtLinePos == 0)
			Console.WriteLine();

		if (crtLinePos == x - 1 || crtLinePos == x || crtLinePos == x + 1)
			Console.Write("#");
		else
			Console.Write(".");

		x += HandleInstruction(cycleInstr[i - 1]);
	}
}

static int HandleInstruction(string instr)
{
	int v = 0;
	if (instr.StartsWith("addx"))
		v = int.Parse(instr.Split(" ")[1]);

	return v;
}