using System;
using Trilobyte;

namespace TrilobyteTest
{
	class PlayerEntity : Entity
	{
		public PlayerEntity(int x, int y)
		{
			Display = '☺';
			X = x;
			Y = y;

			OnUpdate += PlayerEntity_OnUpdate;
		}

		private void PlayerEntity_OnUpdate(UpdateEventArgs e)
		{
			switch (e.Key)
			{
				case ConsoleKey.W:
					Environment.MoveEntity(this, X, Y - 1);
					break;

				case ConsoleKey.S:
					Environment.MoveEntity(this, X, Y + 1);
					break;

				case ConsoleKey.A:
					Environment.MoveEntity(this, X - 1, Y);
					break;

				case ConsoleKey.D:
					Environment.MoveEntity(this, X + 1, Y);
					break;

				case ConsoleKey.E:
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
}
