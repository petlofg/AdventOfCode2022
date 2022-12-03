string[] lines = File.ReadAllLines(@".\input.txt");
List<int> sums = new();
int sum = 0;

foreach (string line in lines)
{
	if (line.Equals(string.Empty))
	{
		sums.Add(sum);
		sum = 0;
	}
	else
	{
		sum += Int32.Parse(line);
	}
}

sums.Add(sum);

List<int> top3 = sums.OrderByDescending(x => x).Take(3).ToList();

Console.WriteLine(top3[0]); 
Console.WriteLine(top3.Sum());
