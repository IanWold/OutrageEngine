namespace Trilobyte
{
	public interface ITerrainManager
	{
		void Add(Entity toAdd);

		void Move(Entity toMove, int x, int y);

		void Remove(Entity toRemove);

		void Update(UpdateEventArgs e);

		TerrainSpot this[int x, int y] { get; }

		//REMOVE THIS SOMETIME SOON
		//string WriteField(int a, int b, int c, int d);
	}
}
