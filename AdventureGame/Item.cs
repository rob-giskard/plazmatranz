using System;
using System.Collections.Generic;

namespace AdventureGame
{
	public class Item
	{
		public string name { get; set; }
		public List<String> stuffInside = new();
		public bool isInBackack;

		public static void putInside(Item container, Item item)
		{
			container.stuffInside.Add(item.name);
		}

		public static void ShowContents(Item container)
		{
			Console.WriteLine("\n{0} contains the following:\n", container.name);

			if (container.stuffInside.Count > 0)
			{
				foreach (String item in container.stuffInside)
				{
					Console.WriteLine("- {0}\n", item);
				}
			}
            else
            {
				Console.WriteLine("\n Dis' empty, dawg...\n");
            }
		}
	}
}
