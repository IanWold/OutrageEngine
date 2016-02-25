using System;
using Trilobyte;

namespace TrilobyteTest
{
	class Program
	{
		static Scene CurrentScene;

		static void Main(string[] args)
		{
			InitializeGame();
			GameLoop.Begin(CurrentScene);
		}

		static void InitializeGame()
		{
			Console.Title = "Trilobyte Test Game";
			Console.WindowHeight = Console.BufferHeight = 35;
			Console.WindowWidth = Console.BufferWidth = 70;
			Console.BackgroundColor = ConsoleColor.DarkGreen;
			Console.ForegroundColor = ConsoleColor.White;
			
			var CurrentTerrain = new DictionaryTerrainManager(' ', 32, 32);

			CurrentTerrain.Add(new PlayerEntity(), new Vector(1, 1));

			CurrentTerrain.Add(new WallEntity(), new Vector(16, 16));
			CurrentTerrain.Add(new WallEntity(), new Vector(17, 16));
			CurrentTerrain.Add(new WallEntity(), new Vector(18, 16));
			CurrentTerrain.Add(new WallEntity(), new Vector(19, 16));
			CurrentTerrain.Add(new WallEntity(), new Vector(20, 16));

			CurrentTerrain.Add(new WallEntity(), new Vector(16, 20));
			CurrentTerrain.Add(new WallEntity(), new Vector(17, 20));
			CurrentTerrain.Add(new DoorEntity(), new Vector(18, 20)); // <---
			CurrentTerrain.Add(new WallEntity(), new Vector(19, 20));
			CurrentTerrain.Add(new WallEntity(), new Vector(20, 20));

			CurrentTerrain.Add(new WallEntity(), new Vector(16, 17));
			CurrentTerrain.Add(new WallEntity(), new Vector(16, 18));
			CurrentTerrain.Add(new WallEntity(), new Vector(16, 19));
			CurrentTerrain.Add(new WallEntity(), new Vector(20, 17));
			CurrentTerrain.Add(new WallEntity(), new Vector(20, 18));
			CurrentTerrain.Add(new WallEntity(), new Vector(20, 19));

			CurrentTerrain.Add(new KeyItem(), new Vector(21, 6));

			Camera MainCam = new Camera(new Vector(0, 0), new Vector(32, 32));

			CurrentScene = new Scene(CurrentTerrain, MainCam);
		}
	}
}
