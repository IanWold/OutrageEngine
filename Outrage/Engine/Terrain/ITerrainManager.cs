namespace OutrageEngine.Engine.Terrain
{
    using OutrageEngine.Engine.Entity;
    using OutrageEngine.Engine.Scene;
    using OutrageEngine.Interfaces;
    using OutrageEngine.Vector;

    /// <summary>
    /// A terrain manager keeps track of entities in a field (terrain).
    /// </summary>
    public interface ITerrainManager : IUpdatable
    {
        TerrainSpot this[int x, int y] { get; }

        IScene ParentScene { get; set; }

        void Add(IEntity toAdd, Vector location);

        void Move(IEntity toMove, Vector location);

        void Remove(IEntity toRemove);

        void Clear();
    }
}
