using Outrage;

namespace OutrageTest
{
	class WallEntity : Entity
	{
		public WallEntity() : base('■')
		{
			OnCollidedWith += WallEntity_OnCollidedWith;
		}

		private void WallEntity_OnCollidedWith(object sender, CollisionEventArgs e)
		{
			e.Cancel = true;
		}
	}
}
