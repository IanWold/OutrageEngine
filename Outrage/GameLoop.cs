using System;

namespace Outrage
{
	public static class GameLoop
	{
		static IViewable CurrentView;

		public static void Begin(IViewable theView)
		{
			CurrentView = theView;

			while (true)
			{
				Console.Clear();
				Console.WriteLine(CurrentView.Write());

				var input = Console.ReadKey().Key;
				CurrentView.Update(new UpdateEventArgs(input));
			}
		}

		public static void NavigateScene(IScene toNavigate)
		{
			CurrentView = toNavigate;
		}
	}
}
