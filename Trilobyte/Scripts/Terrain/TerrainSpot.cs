using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trilobyte
{
	class TerrainSpot
	{
		public List<Entity> Occupants = new List<Entity>();

		public char Display
		{
			get
			{

				return Occupants[Occupants.Count - 1].Display;
			}
		}

		public TerrainSpot() { }

		public TerrainSpot(Entity first)
		{
			Occupants.Add(first);
		}
	}
}
