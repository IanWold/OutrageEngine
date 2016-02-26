using System;

namespace Trilobyte
{
	public static class GameLoop
	{
		static ILevel TheLevel;

		public static void Begin(ILevel theLevel)
		{
			TheLevel = theLevel;

			while (true)
			{
				Console.Clear();
				//Console.WriteLine(CurrentScene.Write());
				Console.WriteLine(TheLevel.Write());

				Console.Write(">:{{{)");
				var input = Console.ReadKey().Key;

				TheLevel.Update(new UpdateEventArgs(input));
			}
		}

		public static void ChangeLevel(ILevel newLevel)
		{
			TheLevel = newLevel;
		}
	}
}
