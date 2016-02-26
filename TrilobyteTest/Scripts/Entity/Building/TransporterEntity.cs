using Trilobyte;

namespace TrilobyteTest
{
	class TransporterEntity : Entity
	{
		string toTransport;

		public TransporterEntity(string toTrans)
		{
			Display = '@';
			toTransport = toTrans;

			OnCollidedWith += TransporterEntity_OnCollidedWith;
		}

		private void TransporterEntity_OnCollidedWith(object sender, CollisionEventArgs e)
		{
			if (e.Caller.GetType() == typeof(PlayerEntity))
			{
				ParentScene.ParentLevel.Get(toTransport).Terrain.Add(e.Caller, new Vector(12, 12));
				ParentScene.ParentLevel.ChangeScene(toTransport);
				ParentScene.Terrain.Remove(e.Caller);
			}
		}
	}
}
