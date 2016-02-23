using Trilobyte;

namespace TrilobyteTest
{
	class PlayerEntity : Entity
	{
		bool HasKey
		{
			get
			{
				foreach (var i in MainPlayer.Inventory)
				{
					if (i.GetType() == typeof(KeyItem)) return true;
				}
				return false;
			}
		}

		public PlayerEntity(int x, int y) : base('☺', x, y) { }

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
					case "e":
						if (MainPlayer.Inventory.Count == 0) break;

						foreach (var i in MainPlayer.Inventory)
						{
							i.X = X;
							i.Y = Y;
							Environment.Add(i);
						}

						MainPlayer.Inventory.Clear();
						break;
				}
			}
		}

		public override bool OnCollidedWith(Entity other)
		{
			if (other.GetType() == typeof(KeyItem))
			{
				MainPlayer.Inventory.Add(other);
				Environment.RemoveEntity(other);
			}
			if (other.GetType() == typeof(DoorEntity) && HasKey)
			{
				(other as DoorEntity).IsLocked = !(other as DoorEntity).IsLocked;
			}

			return true;
		}
	}
}
