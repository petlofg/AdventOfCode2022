
string[] lines = File.ReadAllLines(@".\input.txt");
int width = lines[0].Length;
int height = lines.Length;

int[,] trees = new int[width, height];

for (int y = 0; y < height; y++)
{
	string line = lines[y];
	for (int x = 0; x < width; x++)
	{
		trees[x, y] = int.Parse(line[x].ToString());
	}
}

PartOne(trees, width, height);
PartTwo(trees, width, height);

static void PartOne(int[,] trees, int width, int height)
{
	int borderTrees = width * 2 + height * 2 - 4;
	int sumVisible = borderTrees;
	for (int x = 1; x < width - 1; x++)
	{
		for (int y = 1; y < height - 1; y++)
		{
			if (IsVisible(trees, width, height, x, y))
			{
				sumVisible++;
			}
		}
	}

	Console.WriteLine(sumVisible);
}

static void PartTwo(int[,] trees, int width, int height)
{
	int maxScore = 0;
	for (int x = 0; x < width; x++)
	{
		for (int y = 0; y < height; y++)
		{
			int score = CalcScore(trees, width, height, x, y);
			if (score > maxScore)
				maxScore = score;
		}
	}

	Console.WriteLine(maxScore);
}

static int CalcScore(int[,] trees, int width, int height, int x, int y)
{
	int scoreLeft = 0;
	int scoreRight = 0;
	int scoreTop = 0;
	int scoreBottom = 0;

	int treeHeight = trees[x, y];

	// Left
	for (int i = x - 1; i >= 0; i--)
	{
		if (trees[i, y] < treeHeight)
			scoreLeft++;
		else
		{
			scoreLeft++;
			break;
		}
	}

	// Right
	for (int i = x + 1; i < width; i++)
	{
		if (trees[i, y] < treeHeight)
			scoreRight++;
		else
		{
			scoreRight++;
			break;
		}
	}

	// Top
	for (int i = y - 1; i >= 0; i--)
	{
		if (trees[x, i] < treeHeight)
			scoreTop++;
		else
		{
			scoreTop++;
			break;
		}
	}

	// Bottom
	for (int i = y + 1; i < height; i++)
	{
		if (trees[x, i] < treeHeight)
			scoreBottom++;
		else
		{
			scoreBottom++;
			break;
		}
	}

	return scoreLeft * scoreRight * scoreTop * scoreBottom;
}


static bool IsVisible(int[,] trees, int width, int height, int x, int y)
{
	bool isVisibleLeft = true;
	bool isVisibleRight = true;
	bool isVisibleTop = true;
	bool isVisibleBottom = true;
	int treeHeight = trees[x, y];
	
	// Row
	for (int i = 0; i < width; i++)
	{
		int currHeight = trees[i, y];
		if (currHeight >= treeHeight && i < x)
		{
			isVisibleLeft = false;
		}
		else if (currHeight >= treeHeight && i > x)
		{
			isVisibleRight = false;
			break;
		}
	}

	// Column
	for (int i = 0; i < height; i++)
	{
		int currHeight = trees[x, i];
		if (currHeight >= treeHeight && i < y)
		{
			isVisibleTop = false;
		}
		else if (currHeight >= treeHeight && i > y)
		{
			isVisibleBottom = false;
			break;
		}
	}

	return isVisibleLeft || isVisibleRight || isVisibleTop || isVisibleBottom;
}