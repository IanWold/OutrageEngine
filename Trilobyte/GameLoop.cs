using System;

namespace Trilobyte
{
	public static class GameLoop
	{
		public static void Begin(IScene CurrentScene)
		{
			while (true)
			{
				Console.Clear();
				//Console.WriteLine(CurrentScene.Write());
				Console.WriteLine(CurrentScene.Write());

				Console.Write(">:{{{)");
				var input = Console.ReadKey().Key;

				CurrentScene.Update(new UpdateEventArgs(input));
			}
		}
	}
}
