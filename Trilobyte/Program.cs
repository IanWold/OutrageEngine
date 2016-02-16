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
			var CurrentTerrain = new Terrain(' ', 32, 32);

			CurrentTerrain.Add(new PlayerEntity(1, 1));
			CurrentTerrain.Add(new WallEntity(16, 16));
			CurrentTerrain.Add(new WallEntity(17, 16));
			CurrentTerrain.Add(new WallEntity(18, 16));
			CurrentTerrain.Add(new WallEntity(19, 16));
			CurrentTerrain.Add(new WallEntity(20, 16));

			CurrentTerrain.Add(new WallEntity(16, 20));
			CurrentTerrain.Add(new WallEntity(17, 20));
			//CurrentTerrain.Add(new DoorEntity(18, 20));
			CurrentTerrain.Add(new WallEntity(19, 20));
			CurrentTerrain.Add(new WallEntity(20, 20));

			CurrentTerrain.Add(new WallEntity(16, 17));
			CurrentTerrain.Add(new WallEntity(16, 18));
			CurrentTerrain.Add(new WallEntity(16, 19));
			CurrentTerrain.Add(new WallEntity(20, 17));
			CurrentTerrain.Add(new WallEntity(20, 18));
			CurrentTerrain.Add(new WallEntity(20, 19));

			Console.BackgroundColor = ConsoleColor.DarkCyan;
			Console.ForegroundColor = ConsoleColor.Black;

			while (true)
			{
				Console.Clear();
				Console.WriteLine(CurrentTerrain.WriteField(32, 32, 0, 0));

				var input = Console.ReadKey().KeyChar.ToString();

				CurrentTerrain.Update(new string[] { input });
			}
		}
	}




}
