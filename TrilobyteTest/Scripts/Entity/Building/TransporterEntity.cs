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
				Program.SecondScene.Terrain.Add(e.Caller, new Vector(12, 12));
				GameLoop.ChangeScene(Program.SecondScene);
				ParentScene.Terrain.Remove(e.Caller);
			}
		}
	}
}
