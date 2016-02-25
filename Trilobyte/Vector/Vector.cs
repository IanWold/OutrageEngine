using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trilobyte
{
	public struct Vector
	{
		public int X { get; set; }
		public int Y { get; set; }

		public Vector(int x, int y)
		{
			X = x;
			Y = y;
		}
	}
}
