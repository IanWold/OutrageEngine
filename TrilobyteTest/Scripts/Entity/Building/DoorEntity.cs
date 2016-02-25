using Trilobyte;

namespace TrilobyteTest
{
	class DoorEntity : Entity
	{
		bool _IsLocked = true;
		public bool IsLocked
		{
			get
			{
				return _IsLocked;
			}
			set
			{
				_IsLocked = value;
				Display = value ? '_' : '/';
			}
		}

		public DoorEntity(int x, int y)
		{
			Display = '_';
			X = x;
			Y = y;

			OnCollidedWith += DoorEntity_OnCollidedWith;
		}


		private void DoorEntity_OnCollidedWith(object sender, CollisionEventArgs e)
		{
			if (e.Caller.GetType() == typeof(PlayerEntity) && MainPlayer.InventoryHasKey)
			{
				IsLocked = false;
			}

			e.Cancel = IsLocked;
		}
	}
}
