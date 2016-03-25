using System.Collections.Generic;

namespace Trilobyte
{
	public class TerrainSpot : IWriteable
	{
		public List<Entity> Occupants { get; set; }

		public TerrainSpot()
		{
			Occupants = new List<Entity>();
		}

		public TerrainSpot(Entity first)
		{
			Occupants = new List<Entity>();
			Occupants.Add(first);
		}

		public string Write()
		{
			return Occupants[Occupants.Count - 1].Display.ToString();
		}
	}
}
