namespace OutrageEngine.EventHandlers
{
    using OutrageEngine.Engine.Entity;
    using OutrageEngine.Vector;

    /// <summary>
    /// This event fires when entities collide
    /// </summary>
    public sealed class CollisionEventArgs
    {
        public CollisionEventArgs(IEntity c, Vector position)
        {
            Cancel = false;
            Caller = c;
            Position = position;
        }

        public bool Cancel { get; set; }

        public IEntity Caller { get; set; }

        public Vector Position { get; set; }
    }
}
