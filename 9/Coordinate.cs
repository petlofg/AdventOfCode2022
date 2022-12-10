namespace _9
{
	internal class Coordinate
	{
		public int X { get; set; }
		public int Y { get; set; }

		public Coordinate(int x, int y)
		{
			X = x;
			Y = y;
		}

		public int GetDistance(Coordinate other)
		{
			return Math.Max(Math.Abs(X - other.X), Math.Abs(Y - other.Y));
		}

		public Coordinate Clone()
		{
			return new Coordinate(X, Y);
		}

		public override bool Equals(object? obj)
		{
			return obj is Coordinate coordinate &&
				   X == coordinate.X &&
				   Y == coordinate.Y;
		}

		public override int GetHashCode()
		{
			return HashCode.Combine(X, Y);
		}

		public static bool operator ==(Coordinate? left, Coordinate? right)
		{
			return EqualityComparer<Coordinate>.Default.Equals(left, right);
		}

		public static bool operator !=(Coordinate? left, Coordinate? right)
		{
			return !(left == right);
		}
	}
}
