namespace Outrage
{
	/// <summary>
	/// A terrain manager keeps track of entities in a field (terrain).
	/// </summary>
	public interface ITerrainManager : IUpdatable
	{
		void Add(IEntity toAdd, Vector location);

		void Move(IEntity toMove, Vector location);

		void Remove(IEntity toRemove);

		void Clear();

		TerrainSpot this[int x, int y] { get; }

		IScene ParentScene { get; set; }
	}
}
