using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9
{
	internal class Knot
	{
		public Knot? Head { get; set; }

		public Coordinate Self { get; set; }

		public Knot(Coordinate self)
		{
			Head = null;
			Self = self;
		}

		public Knot(Coordinate self, Knot head)
		{
			Self = self;
			Head = head;
		}
	}
}
