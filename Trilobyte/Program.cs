using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trilobyte
{
	class Program
	{
		static void Main(string[] args)
		{
			var CurrentTerrain = new Terrain('.', 32, 32);

			CurrentTerrain.Add(new PlayerEntity(1, 1));
			CurrentTerrain.Add(new WallEntity(16, 16));

			while (true)
			{
				Console.Clear();
				Console.WriteLine(CurrentTerrain.WriteField(31, 31, 0, 0));

				var input = Console.ReadKey().KeyChar.ToString();

				CurrentTerrain.Update(new string[] { input });
			}
		}
	}

	class Terrain
	{
		Dictionary<Tuple<int, int>, TerrainSpot> Field = new Dictionary<Tuple<int, int>, TerrainSpot>();

		public char EmptyDisplay;

		public int Height;

		public int Width;

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
				else return new TerrainSpot(new Entity(EmptyDisplay, x, y));
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

		public Terrain(char emptyDisplay, int width, int height)
		{
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
					allowed = o.OnEntityAppeared(toAdd);
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
			toMove.Environment = this;

			TerrainSpot outSpot;
			var key = new Tuple<int, int>(x, y);

			if (Field.TryGetValue(key, out outSpot))
			{
				bool allowed = true;

				foreach (var o in outSpot.Occupants)
				{
					allowed = o.OnCollidedWith(toMove) && toMove.OnCollidedWith(o);
					if (!allowed) break;
				}

				if (allowed)
				{
					var oldKey = new Tuple<int, int>(toMove.X, toMove.Y);
					Field.TryGetValue(oldKey, out outSpot);
					outSpot.Occupants.Remove(toMove);

					if (outSpot.Occupants.Count == 0)
					{
						Field.Remove(oldKey);
					}

					toMove.X = x;
					toMove.Y = y;
					outSpot.Occupants.Add(toMove);
				}
			}
			else
			{
				var oldKey = new Tuple<int, int>(toMove.X, toMove.Y);
				Field.TryGetValue(oldKey, out outSpot);
				outSpot.Occupants.Remove(toMove);

				if (outSpot.Occupants.Count == 0)
				{
					Field.Remove(oldKey);
				}

				toMove.X = x;
				toMove.Y = y;
				Field.Add(key, new TerrainSpot(toMove));
			}
		}

		public void Update(string[] args)
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

	class TerrainSpot
	{
		public List<Entity> Occupants = new List<Entity>();

		public char Display
		{
			get
			{

				return Occupants[Occupants.Count - 1].Display;
			}
		}

		public TerrainSpot() { }

		public TerrainSpot(Entity first)
		{
			Occupants.Add(first);
		}
	}

	class Entity
	{
		public char Display { get; protected set; }

		public int X { get; set; }

		public int Y { get; set; }

		public Terrain Environment { get; set; }

		public Entity(char display, int x, int y)
		{
			Display = display;

			X = x;
			Y = y;
		}

		public virtual void Update(string[] args) { }
		public virtual bool OnCollidedWith(Entity other) { return true; }
		public virtual bool OnEntityAppeared(Entity other) { return true; }
	}

	class PlayerEntity : Entity
	{
		public PlayerEntity(int x, int y): base('0', x, y) { }

		public override void Update(string[] args)
		{
			if (args.Length > 0)
			{
				switch (args[0].ToLower())
				{
					case "w":
						Environment.MoveEntity(this, X, Y - 1);
						break;
					case "s":
						Environment.MoveEntity(this, X, Y + 1);
						break;
					case "a":
						Environment.MoveEntity(this, X - 1, Y);
						break;
					case "d":
						Environment.MoveEntity(this, X + 1, Y);
						break;
				}
			}
		}
	}

	class WallEntity : Entity
	{
		public WallEntity(int x, int y): base('X', x, y) { }

		public override bool OnCollidedWith(Entity other)
		{
			return false;
		}
	}
}
