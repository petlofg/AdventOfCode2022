using _7;

string[] lines = File.ReadAllLines(@".\input.txt").Skip(1).ToArray();

Node root = new("/");

Node currentNode = root;

foreach (string line in lines)
{
	string[] lineParts = line.Split(" ");

	if (lineParts[0] == "$" && lineParts[1] == "cd")
	{
		string dirName = lineParts[2];
		if (dirName == "..")
		{
			if (currentNode.Parent != null)
			{
				currentNode = currentNode.Parent;
			}
		}
		else
		{
			Node dest = currentNode.ChildNodes.Where(c => c.Name == dirName).First();
			currentNode = dest;
		}
	}
	else if (int.TryParse(lineParts[0], out int size))
	{
		currentNode.FileSizes.Add(size);
	}
	else if (lineParts[0] == "dir")
	{
		string name = line.Split(" ")[1];

		if (!currentNode.ChildNodes.Exists(c => c.Name == name))
		{
			Node child = new(name, currentNode);
			currentNode.AddNode(child);
		}
	}
}

// Part 1
TraverseAndSum(root);
Console.WriteLine(totalSum);

// Part 2
int freeSpace = 70000000 - root.GetTotalSize();
int neededSpace = 30000000 - freeSpace;

TraverseAndFindSmallest(root, neededSpace);
Console.WriteLine(deleteDirSize);

static void TraverseAndSum(Node node)
{
	foreach (Node childNode in node.ChildNodes)
	{
		int nodeSize = childNode.GetTotalSize();
		if (nodeSize < 100000)
		{
			totalSum += nodeSize;
		}
		TraverseAndSum(childNode);
	}
}

static void TraverseAndFindSmallest(Node node, int neededSpace)
{
	foreach (Node childNode in node.ChildNodes)
	{
		int nodeSize = childNode.GetTotalSize();
		if (nodeSize >= neededSpace && nodeSize < deleteDirSize)
		{
			deleteDirSize = nodeSize;
		}
		TraverseAndFindSmallest(childNode, neededSpace);
	}
}

public partial class Program
{
	internal static int totalSum = 0;
	internal static int deleteDirSize = int.MaxValue;
}