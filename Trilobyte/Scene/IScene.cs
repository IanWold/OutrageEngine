namespace Trilobyte
{
	public interface IScene : IUpdatable, IWriteable
	{
		ITerrainManager Terrain { get; set; }
	}
}
