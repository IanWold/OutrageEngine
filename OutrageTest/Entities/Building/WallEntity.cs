namespace OutrageTest.Entities.Building
{
    using OutrageEngine.Engine.Entity;
    using OutrageEngine.EventHandlers;

    internal sealed class WallEntity : SingleEntity
    {
        public WallEntity()
        {
            Display = '■';
            OnCollidedWith += WallEntity_OnCollidedWith;
        }

        private void WallEntity_OnCollidedWith(object sender, CollisionEventArgs e)
        {
            e.Cancel = true;
        }
    }
}
