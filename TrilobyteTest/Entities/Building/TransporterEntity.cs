using Trilobyte;

namespace TrilobyteTest
{
	class TransporterEntity : Entity
	{
		IScene toTransport;

		public TransporterEntity(IScene toTrans)
		{
			Display = '@';
			toTransport = toTrans;

			OnCollidedWith += TransporterEntity_OnCollidedWith;
		}

		private void TransporterEntity_OnCollidedWith(object sender, CollisionEventArgs e)
		{
			if (e.Caller.GetType() == typeof(PlayerEntity))
			{
				toTransport.Terrain.Add(e.Caller, new Vector(12, 12));
				GameLoop.NavigateScene(toTransport);
				ParentScene.Terrain.Remove(e.Caller);
			}

			e.Cancel = true;
		}
	}
}
