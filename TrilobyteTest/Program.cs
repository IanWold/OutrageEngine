using System;
using Trilobyte;

namespace TrilobyteTest
{
	partial class Program
	{
		public static Scene FirstScene;
		public static Scene SecondScene;

		public static Level FirstLevel;

		static void Main(string[] args)
		{
			InitializeGame();
			GameLoop.Begin(FirstLevel);
		}

		static void InitializeGame()
		{
			Console.Title = "Trilobyte Test Game";
			Console.WindowHeight = Console.BufferHeight = 35;
			Console.WindowWidth = Console.BufferWidth = 70;
			Console.BackgroundColor = ConsoleColor.DarkGreen;
			Console.ForegroundColor = ConsoleColor.White;
			
			FirstScene = new Scene(
				"FirstScene",
				new DictionaryTerrainManager(' ', new Vector(32, 32)),
				new Camera(new Vector(0, 0), new Vector(32, 32)));
			
			SecondScene = new Scene(
				"SecondScene",
				new DictionaryTerrainManager(' ', new Vector(32, 32)),
				new Camera(new Vector(0, 0), new Vector(32, 32)));

			PopulateFirstScene();
			PopulateSecondScene();

			FirstLevel = new Level("FirstLevel", FirstScene);
			FirstLevel.Add(SecondScene);
		}

		private static void PopulateSecondScene()
		{
			SecondScene.Terrain.Add(new WallEntity(), new Vector(10, 10));
			SecondScene.Terrain.Add(new WallEntity(), new Vector(11, 10));
			SecondScene.Terrain.Add(new DoorEntity(), new Vector(12, 10)); // <---
			SecondScene.Terrain.Add(new WallEntity(), new Vector(13, 10));
			SecondScene.Terrain.Add(new WallEntity(), new Vector(14, 10));

			SecondScene.Terrain.Add(new WallEntity(), new Vector(10, 14));
			SecondScene.Terrain.Add(new WallEntity(), new Vector(11, 14));
			SecondScene.Terrain.Add(new WallEntity(), new Vector(12, 14));
			SecondScene.Terrain.Add(new WallEntity(), new Vector(13, 14));
			SecondScene.Terrain.Add(new WallEntity(), new Vector(14, 14));

			SecondScene.Terrain.Add(new WallEntity(), new Vector(10, 11));
			SecondScene.Terrain.Add(new WallEntity(), new Vector(10, 12));
			SecondScene.Terrain.Add(new WallEntity(), new Vector(10, 13));
			SecondScene.Terrain.Add(new TransporterEntity(FirstScene.Name), new Vector(12, 13));
			SecondScene.Terrain.Add(new WallEntity(), new Vector(14, 11));
			SecondScene.Terrain.Add(new WallEntity(), new Vector(14, 12));
			SecondScene.Terrain.Add(new WallEntity(), new Vector(14, 13));
		}

		private static void PopulateFirstScene()
		{
			FirstScene.Terrain.Add(new PlayerEntity(), new Vector(1, 1));

			FirstScene.Terrain.Add(new WallEntity(), new Vector(16, 16));
			FirstScene.Terrain.Add(new WallEntity(), new Vector(17, 16));
			FirstScene.Terrain.Add(new WallEntity(), new Vector(18, 16));
			FirstScene.Terrain.Add(new WallEntity(), new Vector(19, 16));
			FirstScene.Terrain.Add(new WallEntity(), new Vector(20, 16));

			FirstScene.Terrain.Add(new WallEntity(), new Vector(16, 20));
			FirstScene.Terrain.Add(new WallEntity(), new Vector(17, 20));
			//FirstScene.Terrain.Add(new DoorEntity(), new Vector(18, 20)); // <---
			FirstScene.Terrain.Add(new WallEntity(), new Vector(19, 20));
			FirstScene.Terrain.Add(new WallEntity(), new Vector(20, 20));

			FirstScene.Terrain.Add(new WallEntity(), new Vector(16, 17));
			FirstScene.Terrain.Add(new WallEntity(), new Vector(16, 18));
			FirstScene.Terrain.Add(new WallEntity(), new Vector(16, 19));
			FirstScene.Terrain.Add(new TransporterEntity(SecondScene.Name), new Vector(18, 17));
			FirstScene.Terrain.Add(new WallEntity(), new Vector(20, 17));
			FirstScene.Terrain.Add(new WallEntity(), new Vector(20, 18));
			FirstScene.Terrain.Add(new WallEntity(), new Vector(20, 19));

			FirstScene.Terrain.Add(new KeyItem(), new Vector(21, 6));
		}
	}
}
