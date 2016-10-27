using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Outrage
{
	/// <summary>
	/// Custom Vector allows control of characteristics
	/// </summary>
	public struct Vector
	{
		public int X { get; set; }
		public int Y { get; set; }

		public Vector(int x, int y)
		{
			X = x;
			Y = y;
		}
		//Good thing we've got that control, surely the standard .NET implementation doesn't have this level of sophistication!
	}
}
