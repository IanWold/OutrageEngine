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

		public DoorEntity(int x, int y) : base('_', x, y) { }
		
		
		public override bool OnCollidedWith(Entity other)
		{
			return !IsLocked;
		}
	}
}
