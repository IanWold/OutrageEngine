using Outrage;

namespace OutrageTest
{
	class KeyItem : Entity
	{
		public KeyItem() : base('.')
		{
			OnCollidedWith += KeyItem_OnCollidedWith;
		}

		private void KeyItem_OnCollidedWith(object sender, CollisionEventArgs e)
		{
			if (e.Caller.GetType() == typeof(PlayerEntity))
			{
				MainPlayer.Inventory.Add(this);
				ParentScene.Terrain.Remove(this);
			}
		}
	}
}
