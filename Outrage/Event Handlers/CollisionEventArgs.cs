namespace Outrage
{
	/// <summary>
	/// This event fires when entities collide
	/// </summary>
	public class CollisionEventArgs
	{
		public bool Cancel { get; set; }

		public IEntity Caller { get; set; }

		public Vector Position { get; set; }

		public CollisionEventArgs(IEntity c, Vector position)
		{
			Cancel = false;
			Caller = c;
			Position = position;
		}
	}
}
