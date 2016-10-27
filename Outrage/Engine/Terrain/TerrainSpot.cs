using System.Collections.Generic;

namespace Outrage
{
	/// <summary>
	/// A single character on the screen.
	/// Used by DictionaryTerrainManager.
	/// </summary>
	public class TerrainSpot : IWriteable
	{
		public List<SingleEntity> Occupants { get; set; }

		public TerrainSpot()
		{
			Occupants = new List<SingleEntity>();
		}

		public TerrainSpot(SingleEntity first)
		{
			Occupants = new List<SingleEntity>();
			Occupants.Add(first);
		}

		public string Write()
		{
			return Occupants[Occupants.Count - 1].Display.ToString();
		}
	}
}
