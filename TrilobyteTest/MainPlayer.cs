using System.Collections.Generic;
using Outrage;

namespace OutrageTest
{
	public static class MainPlayer
	{
		public static List<Entity> Inventory = new List<Entity>();

		public static bool InventoryHasKey
		{
			get
			{
				foreach (var i in Inventory)
				{
					if (i.GetType() == typeof(KeyItem)) return true;
				}
				return false;
			}
		}
	}
}
