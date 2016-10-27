using System;
using Outrage;

namespace OutrageTest
{
	class PlayerEntity : SingleEntity
	{
		public PlayerEntity()
		{
			Display = '☺';
			OnUpdate += PlayerEntity_OnUpdate;
		}

		private void PlayerEntity_OnUpdate(UpdateEventArgs e)
		{
			switch (e.Key)
			{
				case ConsoleKey.W:
					ParentScene.Terrain.Move(this, new Vector(Position.X, Position.Y - 1));
					break;

				case ConsoleKey.S:
					ParentScene.Terrain.Move(this, new Vector(Position.X, Position.Y + 1));
					break;

				case ConsoleKey.A:
					ParentScene.Terrain.Move(this, new Vector(Position.X - 1, Position.Y));
					break;

				case ConsoleKey.D:
					ParentScene.Terrain.Move(this, new Vector(Position.X + 1, Position.Y));
					break;

				case ConsoleKey.E:
					if (MainPlayer.Inventory.Count == 0) break;

					foreach (var i in MainPlayer.Inventory)
					{
						ParentScene.Terrain.Add(i, new Vector(Position.X + 1, Position.Y));
					}

					MainPlayer.Inventory.Clear();
					break;
			}
		}
	}
}
