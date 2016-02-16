using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trilobyte
{
	class WallEntity : Entity
	{
		public WallEntity(int x, int y) : base('X', x, y) { }

		public override bool OnCollidedWith(Entity other)
		{
			return false;
		}
	}
}
