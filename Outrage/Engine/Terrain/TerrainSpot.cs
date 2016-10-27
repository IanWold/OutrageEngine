using System.Collections.Generic;

namespace Outrage
{
	/// <summary>
	/// A single character on the screen.
	/// Used by DictionaryTerrainManager.
	/// </summary>
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
