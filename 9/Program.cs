using _9;

string[] lines = File.ReadAllLines(@".\input.txt");

PartOne(lines);
PartTwo(lines);

static void PartOne(string[] lines)
{
	Coordinate head = new(0, 0);
	Coordinate tail = new(0, 0);

	HashSet<Coordinate> tailCoordinates = new();
	tailCoordinates.Add(tail.Clone());

	foreach (string line in lines)
	{
		string[] lineParts = line.Split(" ");
		string direction = lineParts[0];
		int stepCount = int.Parse(lineParts[1]);

		MoveHead(head, direction, stepCount);
		MoveTail(tail, head, tailCoordinates);
	}

	int uniquePositions = tailCoordinates.Count;

	Console.WriteLine(uniquePositions);
}

static void PartTwo(string[] lines)
{
	Coordinate startPos = new(0, 0);
	HashSet<Coordinate> tailCoordinates = new();
	tailCoordinates.Add(startPos.Clone());

	List<Knot> knots = new()
	{
		new Knot(startPos.Clone())  // Head
	};

	for (int i = 1; i < 10; i++)
	{
		Knot head = knots[i - 1];
		Knot knot = new(startPos.Clone(), head);
		knots.Add(knot);
	}

	foreach (string line in lines)
	{
		string[] lineParts = line.Split(" ");
		string direction = lineParts[0];
		int stepCount = int.Parse(lineParts[1]);

		for (int s = 0; s < stepCount; s++)					// Move 1 step at a time instead of all at once
		{ 
			for (int i = 0; i < knots.Count; i++)
			{
				Knot knot = knots[i];

				if (i == 0)
				{ 
					MoveHead(knot.Self, direction, 1);		// Move 1 step at a time to update the tails correctly
				}
				else if (knot.Head != null && i < knots.Count - 1)
				{
					MoveTail(knot.Self, knot.Head.Self, null);
				}
				else if (knot.Head != null && i == knots.Count - 1)	// Only keep track of last tail coordinates
				{
					MoveTail(knot.Self, knot.Head.Self, tailCoordinates);
				}
			}
		}
	}

	int uniquePositions = tailCoordinates.Count;

	Console.WriteLine(uniquePositions);
}

static void MoveHead(Coordinate head, string direction, int steps)
{
	// Up increases Y coordinate
	if (direction == "U")
		head.Y += steps;
	else if (direction == "D")
		head.Y -= steps;
	else if (direction == "R")
		head.X += steps;
	else if (direction == "L")
		head.X -= steps;
}

static void MoveTail(Coordinate tail, Coordinate head, HashSet<Coordinate>? tailCoordinates)
{
	if (tail.GetDistance(head) > 1)
	{
		if (head.X > tail.X && head.Y > tail.Y)
		{
			tail.X++;
			tail.Y++;
		}
		else if (head.X < tail.X && head.Y > tail.Y)
		{
			tail.X--;
			tail.Y++;
		}
		else if (head.X > tail.X && head.Y < tail.Y)
		{
			tail.X++;
			tail.Y--;
		}
		else if (head.X < tail.X && head.Y < tail.Y)
		{
			tail.X--;
			tail.Y--;
		}
		else if (head.X > tail.X)
			tail.X++;
		else if (head.X < tail.X)
			tail.X--;
		else if (head.Y > tail.Y)
			tail.Y++;
		else if (head.Y < tail.Y)
			tail.Y--;

		if (tailCoordinates != null)
			tailCoordinates.Add(tail.Clone());

		// Keep moving until within 1
		MoveTail(tail, head, tailCoordinates);
	}
}
