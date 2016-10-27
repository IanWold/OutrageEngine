using System;

namespace Outrage
{
	//This event fires once per 'frame' when active components need to update.
	public class UpdateEventArgs
	{
		public ConsoleKey Key { get; set; }

		public UpdateEventArgs() { }

		public UpdateEventArgs(ConsoleKey key)
		{
			Key = key;
		}
	}
}
