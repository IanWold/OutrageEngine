namespace Outrage
{
	/// <summary>
	/// The camera 'views' a certain section of a terrain within a scene, maintaining a constant output size for the console.
	/// </summary>
	public class Camera
	{
		public IScene Parent { get; set; }

		public Vector Position { get; set; }

		public Vector Scope { get; private set; }

		public Camera(Vector postition, Vector scope)
		{
			Position = postition;
			Scope = scope;
		}
		
		/// <summary>
		/// 
		/// </summary>
		/// <returns>The view of the scene for the loop</returns>
		public string Write()
		{
			var toReturn = "";

			for (int y = Position.Y; y <= Scope.Y; y++)
			{
				var row = "";

				for (int x = Position.X; x <= Scope.X; x++)
				{
					row += Parent.Terrain[x, y].Write() + " ";
				}

				toReturn += row + "\r\n";
			}

			return toReturn;
		}
	}
}
