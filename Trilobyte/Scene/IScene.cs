namespace Trilobyte
{
	public interface IScene : IUpdatable, IWriteable, INamed
	{
		Camera FieldCamera { get; set; }

		Level ParentLevel { get; set; }

		ITerrainManager Terrain { get; set; }
	}
}
