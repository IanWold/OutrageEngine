using System;
using System.Collections.Generic;
using System.Linq;

namespace Outrage
{
	/// <summary>
	/// A terrain manager that stores entities in a 2D dictionary.
	/// spots on the terrain can hold multiple entities, this manager keeps track of all of them
	/// </summary>
	public class DictionaryTerrainManager : ITerrainManager
	{
		Dictionary<Vector, TerrainSpot> Field { get; set; }

		IScene _ParentScene;
		public IScene ParentScene
		{
			get
			{
				return _ParentScene;
			}
			set
			{
				_ParentScene = value;
				foreach (var k in Field)
				{
					foreach (var o in k.Value.Occupants)
					{
						o.ParentScene = _ParentScene;
					}
				}
			}
		}

		public char EmptyDisplay { get; set; }

		public Vector Size { get; private set; }

		/// <summary>
		/// 
		/// </summary>
		/// <param name="x">The horizontal position</param>
		/// <param name="y">The vertical position</param>
		/// <returns>The TerrainSpot at x and y</returns>
		public TerrainSpot this[int x, int y]
		{
			get
			{
				if (x > Size.X || x < 0 || y > Size.Y || y < 0)
				{
					throw new ArgumentOutOfRangeException("Not cool.");
				}

				var key = new Vector(x, y);
				TerrainSpot outSpot;
				if (Field.TryGetValue(key, out outSpot))
				{
					return outSpot;
				}
				else return new TerrainSpot(new Entity(EmptyDisplay, new Vector(x, y)));
			}
			private set
			{
				if (x > Size.X || x < 0 || y > Size.Y || y < 0)
				{
					throw new ArgumentOutOfRangeException("Not cool.");
				}

				var key = new Vector(x, y);

				if (Field.ContainsKey(key))
				{
					Field[key] = value;
				}
			}
		}

		/// <summary>
		/// Removes an entity from the terrain.
		/// </summary>
		/// <param name="other">The entity to remove.</param>
		public void Remove(Entity other)
		{
			var toRemove = from spot in Field
						   from ent in spot.Value.Occupants
						   where ent == other
						   select spot;

			foreach (var s in toRemove)
			{
				s.Value.Occupants.Remove(other);

				if (s.Value.Occupants.Count == 0)
				{
					Field.Remove(s.Key);
				}
			}
		}

		public DictionaryTerrainManager(char emptyDisplay, Vector size)
		{
			Field = new Dictionary<Vector, TerrainSpot>();

			EmptyDisplay = emptyDisplay;
			Size = size;
		}

		/// <summary>
		/// Adds an entity to the terrain
		/// </summary>
		/// <param name="toAdd">The entity to add</param>
		/// <param name="location">The location to add at</param>
		public void Add(Entity toAdd, Vector location)
		{
			Insert(toAdd, location, false);
		}

		/// <summary>
		/// Moves one entity from one spot to another
		/// </summary>
		/// <param name="toMove">The entity to move</param>
		/// <param name="location">The location to move to</param>
		public void Move(Entity toMove, Vector location)
		{
			Insert(toMove, location, true);
		}

		/// <summary>
		/// Inserts an entity at a spot on the terrain. Used by Add and Move.
		/// </summary>
		/// <param name="toInsert">The entity to insert</param>
		/// <param name="location">The location to insert at</param>
		/// <param name="removeOldInstance">True if Insert should delete an existing occurrence of toInsert in the terrain</param>
		void Insert(Entity toInsert, Vector location, bool removeOldInstance)
		{
			try
			{
				if (location.X < 0 || location.Y < 0 || location.X > Size.X || location.Y > Size.Y) return;

				TerrainSpot oldSpot;
				TerrainSpot newSpot;

				if (Field.TryGetValue(location, out newSpot))
				{
					bool allowed = true;

					foreach (var o in newSpot.Occupants)
					{
						var callee = o.CollideWith(new CollisionEventArgs(toInsert, location));
						var caller = toInsert.CollideWith(new CollisionEventArgs(o, location));
						allowed = !callee && !caller;
						if (!allowed) break;
					}

					if (allowed)
					{
						if (removeOldInstance)
						{
							Field.TryGetValue(toInsert.Position, out oldSpot);
							oldSpot.Occupants.Remove(toInsert);

							if (oldSpot.Occupants.Count == 0)
							{
								Field.Remove(toInsert.Position);
							}
						}

						toInsert.Position = location;
						newSpot.Occupants.Add(toInsert);
					}
				}
				else
				{
					if (removeOldInstance)
					{
						Field.TryGetValue(toInsert.Position, out oldSpot);
						oldSpot.Occupants.Remove(toInsert);

						if (oldSpot.Occupants.Count == 0)
						{
							Field.Remove(toInsert.Position);
						}
					}

					toInsert.Position = location;
					Field.Add(location, new TerrainSpot(toInsert));
				}

				toInsert.ParentScene = ParentScene;
			}
			catch (Exception ex)
			{

			}
		}

		/// <summary>
		/// Deletes everything in the terrain.
		/// </summary>
		public void Clear()
		{
			Field.Clear();
		}

		/// <summary>
		/// Called once per 'frame'
		/// </summary>
		/// <param name="args">The state of the update</param>
		public void Update(UpdateEventArgs args)
		{
			List<Entity> entities = new List<Entity>();

			try
			{
				foreach (var s in Field)
					foreach (var e in s.Value.Occupants)
						entities.Add(e);
			}
			catch (Exception ex)
			{

			}

			foreach (var e in entities)
				e.Update(args);
		}
	}
}