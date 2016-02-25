namespace Trilobyte
{
	public interface IScene
	{
		ITerrainManager Terrain { get; set; }

		void Update(UpdateEventArgs e);

		string Write();
	}
}
