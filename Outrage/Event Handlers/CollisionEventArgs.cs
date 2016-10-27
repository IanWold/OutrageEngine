namespace Outrage
{
	/// <summary>
	/// This event fires when entities collide
	/// </summary>
	public class CollisionEventArgs
	{
		public bool Cancel { get; set; }

		public Entity Caller { get; set; }

		public Vector Position { get; set; }

		public CollisionEventArgs(Entity c, Vector position)
		{
			Cancel = false;
			Caller = c;
			Position = position;
		}
	}
}
