using System;

namespace AdventureGame
{
	public class Room
	{
		public string name;


		public void EnterRoom()
		{
			Console.WriteLine(" \nYou entered the {0}", name);
		}
	}
}
