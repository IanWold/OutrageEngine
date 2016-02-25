namespace Trilobyte
{
	public class Scene : IScene
	{
		public ITerrainManager Terrain { get; set; }

		private Camera _FieldCamera;
		public Camera FieldCamera
		{
			get
			{
				return _FieldCamera;
			}
			set
			{
				_FieldCamera = value;
				_FieldCamera.Parent = this;
			}
		}

		public Scene(ITerrainManager terrain, Camera fieldCamera)
		{
			Terrain = terrain;
			FieldCamera = fieldCamera;
		}

		public string Write()
		{
			return FieldCamera.Write();
		}

		public void Update(UpdateEventArgs e)
		{
			Terrain.Update(e);
		}
	}
}
