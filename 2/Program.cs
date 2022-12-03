// Rock		= 1
// Paper	= 2
// Scissors = 3

// Lose = 0
// Draw = 3
// Win  = 6

string[] lines = File.ReadAllLines(@".\input.txt");

PartOne(lines);
PartTwo(lines);

static void PartOne(string[] lines)
{
	// X = Rock		= A
	// Y = Paper	= B
	// Z = Scissors	= C

	// X beats C beats Y
	// Y beats A beats Z
	// Z beats B beats X

	int[][] outcomes =
	{
				 // X  Y  Z
		new int[] { 3, 6, 0 }, // A
		new int[] { 0, 3, 6 }, // B
		new int[] { 6, 0, 3 }  // C
	};

	int sum = 0;
	foreach (string line in lines)
	{
		char opp = line.ToCharArray()[0];
		char me = line.ToCharArray()[2];
		int choiceScore = (int)(me) - 88 + 1;   // Subtract ASCII for 'X' + 1
		int outcome = outcomes[(int)opp - 65][(int)me - 88];

		sum += choiceScore + outcome;
	}

	Console.WriteLine(sum);
}

static void PartTwo(string[] lines)
{
	// X = Lose
	// Y = Draw
	// Z = Win

	int[][] choiceScores =
	{
				 // X  Y  Z
		new int[] { 3, 1, 2 }, // A
		new int[] { 1, 2, 3 }, // B
		new int[] { 2, 3, 1 }  // C
	};

	int sum = 0;
	foreach (string line in lines)
	{
		char opp = line.ToCharArray()[0];
		char desiredOutcome = line.ToCharArray()[2];

		int outcomeScore = ((int)desiredOutcome - 88) * 3;
		int choiceScore = choiceScores[(int)opp - 65][(int)desiredOutcome - 88];

		sum += outcomeScore + choiceScore;
	}

	Console.WriteLine(sum);
}