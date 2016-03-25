using Trilobyte;

namespace TrilobyteTest
{
	class WallEntity : Entity
	{
		public WallEntity()
		{
			Display = '■';

			OnCollidedWith += WallEntity_OnCollidedWith;
		}

		private void WallEntity_OnCollidedWith(object sender, CollisionEventArgs e)
		{
			e.Cancel = true;
		}
	}
}
