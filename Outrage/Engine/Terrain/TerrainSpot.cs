namespace OutrageEngine.Engine.Terrain
{
    using System.Collections.Generic;
    using OutrageEngine.Engine.Entity;
    using OutrageEngine.Interfaces;

    /// <summary>
    /// A single character on the screen.
    /// Used by DictionaryTerrainManager.
    /// </summary>
    public sealed class TerrainSpot : IWriteable
    {
        public TerrainSpot()
        {
            Occupants = new List<SingleEntity>();
        }

        public TerrainSpot(SingleEntity first)
        {
            Occupants = new List<SingleEntity>();
            Occupants.Add(first);
        }

        public List<SingleEntity> Occupants { get; set; }

        public string Write()
        {
            return Occupants[Occupants.Count - 1].Display.ToString();
        }
    }
}
