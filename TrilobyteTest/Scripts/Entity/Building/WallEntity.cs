using Trilobyte;

namespace TrilobyteTest
{
	class WallEntity : Entity
	{
		public WallEntity(int x, int y) : base('■', x, y) { }

		public override bool OnCollidedWith(Entity other)
		{
			return false;
		}
	}
}
