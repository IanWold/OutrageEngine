using System.Collections.Generic;

namespace Trilobyte
{
	public class TerrainSpot
	{
		public List<Entity> Occupants { get; set; }

		public char Display
		{
			get
			{
				return Occupants[Occupants.Count - 1].Display;
			}
		}

		public TerrainSpot()
		{
			Occupants = new List<Entity>();
		}

		public TerrainSpot(Entity first)
		{
			Occupants = new List<Entity>();
			Occupants.Add(first);
		}
	}
}
