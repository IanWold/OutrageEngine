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
			
			var CurrentTerrain = new DictionaryTerrain(' ', 32, 32);

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

			Camera MainCam = new Camera(new Vector(0, 0), new Vector(32, 32));

			CurrentScene = new Scene(CurrentTerrain, MainCam);
		}
	}
}
