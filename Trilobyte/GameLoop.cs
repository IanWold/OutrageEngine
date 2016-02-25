using System;

namespace Trilobyte
{
	public static class GameLoop
	{
		public static void Begin(Terrain CurrentTerrain)
		{
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
}
