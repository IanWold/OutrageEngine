namespace OutrageEngine.EventHandlers
{
    using System;

    //This event fires once per 'frame' when active components need to update.
    public sealed class UpdateEventArgs
    {
        public UpdateEventArgs()
        {
        }

        public UpdateEventArgs(ConsoleKey key)
        {
            Key = key;
        }

        public ConsoleKey Key { get; set; }
    }
}
