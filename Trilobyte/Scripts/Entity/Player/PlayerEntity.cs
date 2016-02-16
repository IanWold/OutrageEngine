using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trilobyte
{
	class PlayerEntity : Entity
	{
		public PlayerEntity(int x, int y) : base('0', x, y) { }

		public override void Update(string[] args)
		{
			if (args.Length > 0)
			{
				switch (args[0].ToLower())
				{
					case "w":
						Environment.MoveEntity(this, X, Y - 1);
						break;
					case "s":
						Environment.MoveEntity(this, X, Y + 1);
						break;
					case "a":
						Environment.MoveEntity(this, X - 1, Y);
						break;
					case "d":
						Environment.MoveEntity(this, X + 1, Y);
						break;
				}
			}
		}
	}
}
