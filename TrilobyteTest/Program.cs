using System;
using System.Collections.Generic;
using Trilobyte;

namespace TrilobyteTest
{
	class Program
	{
		static void Main(string[] args)
		{
			var CurrentTerrain = new Terrain(' ', 32, 32);

			CurrentTerrain.Add(new PlayerEntity(1, 1));

			CurrentTerrain.Add(new WallEntity(16, 16));
			CurrentTerrain.Add(new WallEntity(17, 16));
			CurrentTerrain.Add(new WallEntity(18, 16));
			CurrentTerrain.Add(new WallEntity(19, 16));
			CurrentTerrain.Add(new WallEntity(20, 16));

			CurrentTerrain.Add(new WallEntity(16, 20));
			CurrentTerrain.Add(new WallEntity(17, 20));
			CurrentTerrain.Add(new DoorEntity(18, 20)); // <---
			CurrentTerrain.Add(new WallEntity(19, 20));
			CurrentTerrain.Add(new WallEntity(20, 20));

			CurrentTerrain.Add(new WallEntity(16, 17));
			CurrentTerrain.Add(new WallEntity(16, 18));
			CurrentTerrain.Add(new WallEntity(16, 19));
			CurrentTerrain.Add(new WallEntity(20, 17));
			CurrentTerrain.Add(new WallEntity(20, 18));
			CurrentTerrain.Add(new WallEntity(20, 19));

			CurrentTerrain.Add(new KeyItem(21, 6));

			Console.WindowHeight = 35;
			Console.BackgroundColor = ConsoleColor.DarkGreen;
			Console.ForegroundColor = ConsoleColor.White;
			Console.Title = "Trilobyte Test Game";

			while (true)
			{
				Console.Clear();
				Console.WriteLine(CurrentTerrain.WriteField(32, 32, 0, 0));

				Console.Write(">:{{{)");
				var input = Console.ReadKey().Key;

				CurrentTerrain.Update(new UpdateEventArgs(input));
			}
		}
	}

	public static class MainPlayer
	{
		public static List<Entity> Inventory = new List<Entity>();

		public static bool InventoryHasKey
		{
			get
			{
				foreach (var i in Inventory)
				{
					if (i.GetType() == typeof(KeyItem)) return true;
				}
				return false;
			}
		}
	}
}
