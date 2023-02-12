namespace OutrageEngine.Engine.Scene
{
    using OutrageEngine.Engine.Camera;
    using OutrageEngine.Engine.Entity;
    using OutrageEngine.Engine.Terrain;
    using OutrageEngine.EventHandlers;
    using OutrageEngine.Vector;

    /// <summary>
    /// A generic scene can use any terrain manager and uses a camera to output the view of the scene to the console.
    /// </summary>
    public class Scene : IScene
    {
        public delegate void OnUpdateEventHandler(object sender, UpdateEventArgs e);

        Camera _FieldCamera;

        ITerrainManager _Terrain;

        public Scene(string name, ITerrainManager terrain, Camera fieldCamera)
        {
            Name = name;
            Terrain = terrain;
            FieldCamera = fieldCamera;
        }

        public string Name { get; }

        public ITerrainManager Terrain
        {
            get { return _Terrain; }
            set
            {
                _Terrain = value;
                _Terrain.ParentScene = this;
            }
        }

        public Camera FieldCamera
        {
            get { return _FieldCamera; }
            set
            {
                _FieldCamera = value;
                _FieldCamera.Parent = this;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>The view of the scene for the loop</returns>
        public string Write()
        {
            return FieldCamera.Write();
        }

        /// <summary>
        /// Called once per 'frame'
        /// </summary>
        /// <param name="e">The state of the update</param>
        public void Update(UpdateEventArgs e)
        {
            Terrain.Update(e);
            if (OnUpdate != null) OnUpdate(this, e);
        }

        public event OnUpdateEventHandler OnUpdate;

        /// <summary>
        /// Writes a string on top of the scene
        /// </summary>
        /// <param name="toWrite">The text to write on the scene</param>
        /// <param name="location">The location to write the text</param>
        public void InsertString(string toWrite, Vector location)
        {
            foreach (var w in toWrite.Split('\n'))
            {
                var charArr = w.ToCharArray();

                for (var i = 0; i < charArr.Length; i++)
                {
                    Terrain.Add(new SingleEntity { Display = charArr[i], }, new Vector(location.X + i, location.Y));
                }

                location.Y++;
            }
        }
    }
}
