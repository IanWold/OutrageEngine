namespace Outrage
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

		public string Name { get; }

		public delegate void OnUpdateEventHandler(object sender, UpdateEventArgs e);
		public event OnUpdateEventHandler OnUpdate;

		public Scene(string name, ITerrainManager terrain, Camera fieldCamera)
		{
			Name = name;
			Terrain = terrain;
			FieldCamera = fieldCamera;
		}

		public void InsertString(string toWrite, Vector location)
		{
			foreach (var w in toWrite.Split('\n'))
			{
				var charArr = w.ToCharArray();
				for (int i = 0; i < charArr.Length; i++)
				{
					Terrain.Add(new Entity() { Display = charArr[i] }, new Vector(location.X + i, location.Y));
				}

				location.Y++;
			}
		}

		public string Write()
		{
			return FieldCamera.Write();
		}

		public void Update(UpdateEventArgs e)
		{
			Terrain.Update(e);
			if (OnUpdate != null) OnUpdate(this, e);
		}
	}
}
