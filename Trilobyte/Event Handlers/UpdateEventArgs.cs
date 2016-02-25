using System;

namespace Trilobyte
{
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
