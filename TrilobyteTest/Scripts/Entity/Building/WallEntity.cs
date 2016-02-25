using Trilobyte;

namespace TrilobyteTest
{
	class WallEntity : Entity
	{
		public WallEntity(int x, int y)
		{
			Display = '■';
			X = x;
			Y = y;

			OnCollidedWith += WallEntity_OnCollidedWith;
		}

		private void WallEntity_OnCollidedWith(object sender, CollisionEventArgs e)
		{
			e.Cancel = true;
		}
	}
}
