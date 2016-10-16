namespace Outrage
{
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
