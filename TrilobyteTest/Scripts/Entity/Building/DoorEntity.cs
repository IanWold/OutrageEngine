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
				if (value) Display = '_';
				else Display = '/';
			}
		}

		public DoorEntity(int x, int y)
		{
			Display = '_';
			X = x;
			Y = y;

			OnCollidedWith += DoorEntity_OnCollidedWith;
		}


		private void DoorEntity_OnCollidedWith(object sender, CollidedWithEventArgs e)
		{
			e.Cancel = IsLocked;
		}
	}
}
