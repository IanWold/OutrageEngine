using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trilobyte
{
	class Entity
	{
		public char Display { get; protected set; }

		public int X { get; set; }

		public int Y { get; set; }

		public Terrain Environment { get; set; }

		public Entity(char display, int x, int y)
		{
			Display = display;

			X = x;
			Y = y;
		}

		public virtual void Update(string[] args) { }
		public virtual bool OnCollidedWith(Entity other) { return true; }
		public virtual bool OnEntityAppeared(Entity other) { return true; }
	}
}
