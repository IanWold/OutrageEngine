using System;

namespace Trilobyte
{
	public class Entity
	{
		public char Display { get; set; }
		public int X { get; set; }
		public int Y { get; set; }
		public Terrain Environment { get; set; }

		public virtual void Update(string[] args) { }

		public delegate void CollidedWithEventHandler(object sender, CollidedWithEventArgs e);
		public event CollidedWithEventHandler OnCollidedWith;

		public delegate void EntityAppearedEventHandler(object sender, EntityAppearedEventArgs e);
		public event EntityAppearedEventHandler OnEntityAppeared;

		public bool CollideWith(object sender, CollidedWithEventArgs e)
		{
			if (OnCollidedWith != null)
			{
				OnCollidedWith(sender, e);
			}

			return e.Cancel;
		}

		public bool AppearEntity(object sender, EntityAppearedEventArgs e)
		{
			if (OnEntityAppeared != null)
			{
				OnEntityAppeared(sender, e);
			}

			return e.Cancel;
		}
	}
}
