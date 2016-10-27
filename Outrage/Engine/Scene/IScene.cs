namespace Outrage
{
	/// <summary>
	///  A 'scene' has a terrain (with entities) and a camera
	/// </summary>
	public interface IScene : IViewable
	{
		Camera FieldCamera { get; set; }

		ITerrainManager Terrain { get; set; }
	}
}
