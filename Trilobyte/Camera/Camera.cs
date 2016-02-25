using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Trilobyte
{
	public class Camera
	{
		public IScene Parent { get; set; }

		public Vector Position { get; set; }

		public Vector Scope { get; set; }

		public Camera(Vector postition, Vector scope)
		{
			Position = postition;
			Scope = scope;
		}

		public string Write()
		{
			var toReturn = "";

			for (int y = Position.Y; y <= Scope.Y; y++)
			{
				var row = "";

				for (int x = Position.X; x <= Scope.X; x++)
				{
					row += Parent.Terrain[x, y].Display.ToString() + " ";
				}

				toReturn += row + "\r\n";
			}

			return toReturn;
		}
	}
}
