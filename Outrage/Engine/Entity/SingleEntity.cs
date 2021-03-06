﻿using System;

namespace Outrage
{
	/// <summary>
	/// Represents something tangible in the game
	/// </summary>
	public class SingleEntity : IEntity
	{
		public char Display { get; set; }

		public IScene ParentScene { get; set; }

		public Vector Position { get; set; }

		public delegate void OnUpdateEventHandler(UpdateEventArgs e);
		public event OnUpdateEventHandler OnUpdate;

		public delegate void CollidedWithEventHandler(object sender, CollisionEventArgs e);
		public event CollidedWithEventHandler OnCollidedWith;

		public delegate void EntityAppearedEventHandler(object sender, CollisionEventArgs e);
		public event EntityAppearedEventHandler OnEntityAppeared;

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
	}
}
