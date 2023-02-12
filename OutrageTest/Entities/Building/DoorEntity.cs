namespace OutrageTest.Entities.Building
{
    using OutrageEngine.Engine.Entity;
    using OutrageEngine.EventHandlers;
    using OutrageTest.Entities.Player;

    internal sealed class DoorEntity : SingleEntity
    {
        private bool _IsLocked = true;

        public DoorEntity()
        {
            Display = '_';
            OnCollidedWith += DoorEntity_OnCollidedWith;
        }

        public bool IsLocked
        {
            get { return _IsLocked; }
            set
            {
                _IsLocked = value;
                Display = value ? '_' : '/';
            }
        }

        private void DoorEntity_OnCollidedWith(object sender, CollisionEventArgs e)
        {
            if (e.Caller is PlayerEntity && MainPlayer.InventoryHasKey)
            {
                IsLocked = false;
            }

            e.Cancel = IsLocked;
        }
    }
}
