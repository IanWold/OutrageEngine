using System;
using Outrage;

namespace OutrageTest
{
	class TransporterEntity : SingleEntity
	{
		IScene toTransport;
		DoorEntity the_door;

		public TransporterEntity(IScene toTrans, DoorEntity door = null)
		{
			Display = '@';
			toTransport = toTrans;
			the_door = door;

			OnCollidedWith += TransporterEntity_OnCollidedWith;
		}

		private void TransporterEntity_OnCollidedWith(object sender, CollisionEventArgs e)
		{
			if (e.Caller.GetType() == typeof(PlayerEntity))
			{
				if (toTransport == Program.SecondScene)
					toTransport.Terrain.Add(e.Caller, new Vector(12, 12));
				else
				{
					toTransport.Terrain.Add(e.Caller, new Vector(18, 18));
					the_door.IsLocked = true;
				}
				GameLoop.NavigateScene(toTransport);
				ParentScene.Terrain.Remove(e.Caller);
			}

			e.Cancel = true;
		}
	}
}
