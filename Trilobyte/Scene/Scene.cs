namespace Trilobyte
{
	public class Scene : IScene
	{
		ITerrainManager _Terrain;
		public ITerrainManager Terrain
		{
			get
			{
				return _Terrain;
			}
			set
			{
				_Terrain = value;
				_Terrain.ParentScene = this;
			}
		}

		Camera _FieldCamera;
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
