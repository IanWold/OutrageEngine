namespace Trilobyte
{
	public interface ITerrainManager : IUpdatable
	{
		void Add(Entity toAdd, Vector location);

		void Move(Entity toMove, Vector location);

		void Remove(Entity toRemove);

		TerrainSpot this[int x, int y] { get; }

		IScene ParentScene { get; set; }
	}
}
