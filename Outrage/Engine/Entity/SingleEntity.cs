namespace OutrageEngine.Engine.Entity
{
    using OutrageEngine.Engine.Scene;
    using OutrageEngine.EventHandlers;
    using OutrageEngine.Vector;

    /// <summary>
    /// Represents something tangible in the game
    /// </summary>
    public class SingleEntity : IEntity
    {
        public delegate void CollidedWithEventHandler(object sender, CollisionEventArgs e);

        public delegate void EntityAppearedEventHandler(object sender, CollisionEventArgs e);

        public delegate void OnUpdateEventHandler(UpdateEventArgs e);

        public char Display { get; set; }

        public IScene ParentScene { get; set; }

        public Vector Position { get; set; }

        /// <summary>
        /// Called when two entities run into each other
        /// </summary>
        /// <param name="e">The state of the collision</param>
        /// <returns>True if the collision is canceled</returns>
        public bool CollideWith(CollisionEventArgs e)
        {
            if (OnCollidedWith == null) return false;

            OnCollidedWith(this, e);

            return e.Cancel;
        }

        /// <summary>
        /// Called when an entity appears atop this entity.
        /// Effectively a collision
        /// </summary>
        /// <param name="e">The state of the collision</param>
        /// <returns>True if the collision is canceled</returns>
        public bool AppearEntity(CollisionEventArgs e)
        {
            if (OnEntityAppeared == null) return false;

            OnEntityAppeared(this, e);

            return e.Cancel;
        }

        /// <summary>
        /// Updates once per 'frame'
        /// </summary>
        /// <param name="e">The state of the update.</param>
        public void Update(UpdateEventArgs e)
        {
            if (OnUpdate == null) return;
            OnUpdate(e);
        }

        public event OnUpdateEventHandler OnUpdate;

        public event CollidedWithEventHandler OnCollidedWith;

        public event EntityAppearedEventHandler OnEntityAppeared;
    }
}
