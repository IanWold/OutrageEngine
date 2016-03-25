using System;

namespace Trilobyte
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
				//Console.WriteLine(CurrentScene.Write());
				Console.WriteLine(CurrentView.Write());

				Console.Write(">:{{{)");
				var input = Console.ReadKey().Key;

				CurrentView.Update(new UpdateEventArgs(input));
			}
		}

		public static void NavigateView(IViewable toNavigate)
		{
			CurrentView = toNavigate;
		}

		public static void NavigateScene(IScene toNavigate)
		{
			if (CurrentView.GetType().GetInterface("IScene") != null)
			{
				CurrentView = toNavigate;
			}
			else if (CurrentView.GetType().GetInterface("ISceneWrapper") != null)
			{
				(CurrentView as ISceneWrapper).NavigateScene(toNavigate);
			}
			else
			{
				throw new ArgumentException("The current view can't navigate to a scene.");
			}
		}
	}
}
