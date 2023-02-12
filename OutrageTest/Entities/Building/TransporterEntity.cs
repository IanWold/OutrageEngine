namespace OutrageTest.Entities.Building
{
    using OutrageEngine;
    using OutrageEngine.Engine.Entity;
    using OutrageEngine.Engine.Scene;
    using OutrageEngine.EventHandlers;
    using OutrageEngine.Vector;
    using OutrageTest.Entities.Player;

    internal sealed class TransporterEntity : SingleEntity
    {
        private readonly DoorEntity the_door;

        private readonly IScene toTransport;

        public TransporterEntity(IScene toTrans, DoorEntity door = null)
        {
            Display = '@';
            toTransport = toTrans;
            the_door = door;

            OnCollidedWith += TransporterEntity_OnCollidedWith;
        }

        private void TransporterEntity_OnCollidedWith(object sender, CollisionEventArgs e)
        {
            if (e.Caller is PlayerEntity)
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
