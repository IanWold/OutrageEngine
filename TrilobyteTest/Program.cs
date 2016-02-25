using System;
using Trilobyte;

namespace TrilobyteTest
{
	class Program
	{
		static Terrain CurrentTerrain;

		static void Main(string[] args)
		{
			InitializeGame();
			GameLoop.Begin(CurrentTerrain);
		}

		static void InitializeGame()
		{
			Console.WindowHeight = Console.BufferHeight = 35;
			Console.WindowWidth = Console.BufferWidth = 70;
			Console.BackgroundColor = ConsoleColor.DarkGreen;
			Console.ForegroundColor = ConsoleColor.White;
			Console.Title = "Trilobyte Test Game";

			CurrentTerrain = new Terrain(' ', 32, 32);

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
		}
	}
}
