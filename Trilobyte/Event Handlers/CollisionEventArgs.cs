namespace Trilobyte
{
	public class CollisionEventArgs
	{
		public bool Cancel { get; set; }

		public Entity Caller { get; set; }

		public int X { get; set; }

		public int Y { get; set; }

		public CollisionEventArgs(Entity c, int x, int y)
		{
			Cancel = false;
			Caller = c;
			X = x;
			Y = y;
		}
	}
}
