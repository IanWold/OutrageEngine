namespace OutrageEngine
{
    using System;
    using OutrageEngine.Engine.Scene;
    using OutrageEngine.EventHandlers;
    using OutrageEngine.Interfaces;

    /// <summary>
    /// Central loop of the game.
    /// Controls all console I/O.
    /// </summary>
    public static class GameLoop
    {
        static IViewable CurrentView;

        /// <summary>
        /// Begins the loop, displaying the game.
        /// </summary>
        /// <param name="theView">The game's opening view</param>
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

        /// <summary>
        /// Changes the view to another, effectively navigates to a different scene.
        /// </summary>
        /// <param name="toNavigate">The scene to navigate to</param>
        public static void NavigateScene(IScene toNavigate)
        {
            CurrentView = toNavigate;
        }
    }
}
