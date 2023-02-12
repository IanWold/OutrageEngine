namespace OutrageEngine.Engine.Camera
{
    using OutrageEngine.Engine.Scene;
    using OutrageEngine.Vector;

    /// <summary>
    /// The camera 'views' a certain section of a terrain within a scene, maintaining a constant output size for the console.
    /// </summary>
    public class Camera
    {
        public Camera(Vector postition, Vector scope)
        {
            Position = postition;
            Scope = scope;
        }

        public IScene Parent { get; set; }

        public Vector Position { get; set; }

        public Vector Scope { get; private set; }

        /// <summary>
        ///
        /// </summary>
        /// <returns>The view of the scene for the loop</returns>
        public string Write()
        {
            var toReturn = "";

            for (var y = Position.Y; y <= Scope.Y; y++)
            {
                var row = "";

                for (var x = Position.X; x <= Scope.X; x++)
                {
                    row += Parent.Terrain[x, y].Write() + " ";
                }

                toReturn += row + "\r\n";
            }

            return toReturn;
        }
    }
}
