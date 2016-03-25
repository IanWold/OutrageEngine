namespace Trilobyte
{
	public interface IScene : IViewable
	{
		Camera FieldCamera { get; set; }

		ITerrainManager Terrain { get; set; }
	}
}
