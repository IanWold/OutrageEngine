namespace OutrageTest
{
    using System.Collections.Generic;
    using System.Linq;
    using OutrageEngine.Engine.Entity;
    using OutrageTest.Entities.Inventory;

    public static class MainPlayer
    {
        public static readonly List<SingleEntity> Inventory = new();

        public static bool InventoryHasKey => Inventory.OfType<KeyItem>().Any();
    }
}
