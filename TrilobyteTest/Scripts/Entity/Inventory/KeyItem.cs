using Trilobyte;

namespace TrilobyteTest
{
	class KeyItem : Entity
	{
		public KeyItem(int x, int y)
		{
			Display = '.';
			X = x;
			Y = y;

			OnCollidedWith += KeyItem_OnCollidedWith;
		}

		private void KeyItem_OnCollidedWith(object sender, CollisionEventArgs e)
		{
			if (e.Caller.GetType() == typeof(PlayerEntity))
			{
				MainPlayer.Inventory.Add(this);
				Environment.RemoveEntity(this);
			}
		}
	}
}
