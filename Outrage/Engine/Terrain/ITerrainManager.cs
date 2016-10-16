namespace Outrage
{
	public interface ITerrainManager : IUpdatable
	{
		void Add(Entity toAdd, Vector location);

		void Move(Entity toMove, Vector location);

		void Remove(Entity toRemove);

		void Clear();

		TerrainSpot this[int x, int y] { get; }

		IScene ParentScene { get; set; }
	}
}
