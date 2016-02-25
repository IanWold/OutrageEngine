using System;
using System.Collections.Generic;
using System.Linq;

namespace Trilobyte
{
	public class Terrain
	{
		Dictionary<Tuple<int, int>, TerrainSpot> Field { get; set; }

		public char EmptyDisplay { get; set; }

		public int Height { get; set; }

		public int Width { get; set; }

		public TerrainSpot this[int x, int y]
		{
			get
			{
				if (x > Width || x < 0 || y > Height || y < 0)
				{
					throw new ArgumentOutOfRangeException("Not cool.");
				}

				var key = new Tuple<int, int>(x, y);
				TerrainSpot outSpot;
				if (Field.TryGetValue(key, out outSpot))
				{
					return outSpot;
				}
				else return new TerrainSpot(new EmptyEntity(EmptyDisplay, x, y));
			}
			private set
			{
				if (x > Width || x < 0 || y > Height || y < 0)
				{
					throw new ArgumentOutOfRangeException("Not cool.");
				}

				var key = new Tuple<int, int>(x, y);

				if (Field.ContainsKey(key))
				{
					Field[key] = value;
				}
			}
		}

		public void RemoveEntity(Entity other)
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

		public Terrain(char emptyDisplay, int width, int height)
		{
			Field = new Dictionary<Tuple<int, int>, TerrainSpot>();

			EmptyDisplay = emptyDisplay;
			Width = width;
			Height = height;
		}

		public void Add(Entity toAdd)
		{
			toAdd.Environment = this;

			TerrainSpot outSpot;
			var key = new Tuple<int, int>(toAdd.X, toAdd.Y);

			if (Field.TryGetValue(key, out outSpot))
			{
				bool allowed = true;

				foreach (var o in outSpot.Occupants)
				{
					allowed &= !o.AppearEntity(new CollisionEventArgs(toAdd, toAdd.X, toAdd.Y));
				}

				if (allowed) outSpot.Occupants.Add(toAdd);
			}
			else
			{
				Field.Add(key, new TerrainSpot(toAdd));
			}
		}

		public void MoveEntity(Entity toMove, int x, int y)
		{
			try
			{
				if (x < 0 || y < 0 || x > Width || y > Height) return;

				toMove.Environment = this;

				TerrainSpot oldSpot;
				TerrainSpot newSpot;
				var key = new Tuple<int, int>(x, y);

				if (Field.TryGetValue(key, out newSpot))
				{
					bool allowed = true;

					foreach (var o in newSpot.Occupants)
					{
						var callee = o.CollideWith(new CollisionEventArgs(toMove, x, y));
						var caller = toMove.CollideWith(new CollisionEventArgs(o, x, y));
						allowed = !callee && !caller;
						if (!allowed) break;
					}

					if (allowed)
					{
						var oldKey = new Tuple<int, int>(toMove.X, toMove.Y);
						Field.TryGetValue(oldKey, out oldSpot);
						oldSpot.Occupants.Remove(toMove);

						if (oldSpot.Occupants.Count == 0)
						{
							Field.Remove(oldKey);
						}

						toMove.X = x;
						toMove.Y = y;
						newSpot.Occupants.Add(toMove);
					}
				}
				else
				{
					var oldKey = new Tuple<int, int>(toMove.X, toMove.Y);
					Field.TryGetValue(oldKey, out oldSpot);
					oldSpot.Occupants.Remove(toMove);

					if (oldSpot.Occupants.Count == 0)
					{
						Field.Remove(oldKey);
					}

					toMove.X = x;
					toMove.Y = y;
					Field.Add(key, new TerrainSpot(toMove));
				}
			}
			catch (Exception ex)
			{

			}
		}

		public void Update(UpdateEventArgs args)
		{
			List<Entity> entities = new List<Entity>();

			foreach (var s in Field)
				foreach (var e in s.Value.Occupants)
					entities.Add(e);

			foreach (var e in entities)
				e.Update(args);
		}

		public string WriteField(int width, int height, int _x, int _y)
		{
			var toReturn = "";

			for (int y = _y; y <= height; y++)
			{
				var row = "";

				for (int x = _x; x <= width; x++)
				{
					row += this[x, y].Display.ToString() + " ";
				}

				toReturn += row + "\r\n";
			}

			return toReturn;
		}
	}
}
