using Trilobyte;

namespace TrilobyteTest
{
	class TransporterEntity : Entity
	{
		public TransporterEntity()
		{
			Display = '@';
			OnCollidedWith += TransporterEntity_OnCollidedWith;
		}

		private void TransporterEntity_OnCollidedWith(object sender, CollisionEventArgs e)
		{
			if (e.Caller.GetType() == typeof(PlayerEntity))
			{
				GameLoop.ChangeScene(Program.SecondScene);
			}
		}
	}
}
