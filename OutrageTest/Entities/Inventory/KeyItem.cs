namespace OutrageTest.Entities.Inventory
{
    using OutrageEngine.Engine.Entity;
    using OutrageEngine.EventHandlers;
    using OutrageTest.Entities.Player;

    internal sealed class KeyItem : SingleEntity
    {
        public KeyItem()
        {
            Display = '.';
            OnCollidedWith += KeyItem_OnCollidedWith;
        }

        private void KeyItem_OnCollidedWith(object sender, CollisionEventArgs e)
        {
            if (e.Caller is not PlayerEntity)
            {
                return;
            }

            MainPlayer.Inventory.Add(this);
            ParentScene.Terrain.Remove(this);
        }
    }
}
