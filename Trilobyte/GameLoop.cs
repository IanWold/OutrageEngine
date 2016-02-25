using System;

namespace Trilobyte
{
	public static class GameLoop
	{
		static IScene CurrentScene;

		public static void Begin(IScene startingScene)
		{
			CurrentScene = startingScene;

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

		public static void ChangeScene(IScene newScene)
		{
			CurrentScene = newScene;
		}
	}
}
