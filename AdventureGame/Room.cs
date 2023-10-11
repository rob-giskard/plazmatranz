using System;

namespace AdventureGame
{
	public class Room
	{
		public string name;
		public bool hasEnemy;
		public int row = 1;
		public int column = 1;
		// string[,] map = new string[4, 4];
		public string westDir;
		public string eastDir;
		public string northDir;
		public string southDir;

		public string[,] plan = 
		{
			{"roof", "balcony", " 4 ", " 5 "},
			{"attic", " 8 ", "Decrepit lab", " 6 "},
			{"kitchen", "atrium", "library", " 7 "},
			{"guest room", "anteroom", "corridor", " 111 "}
		};
		// have a group of containers to be opened and looted
		// public Item[] hasFurniture = new{5};



		public string ShowRoomExits()
        {
		
			if (column - 1 >= 0)
            {
				westDir = plan[row, column - 1];
			}
            else
            {
				westDir = "NO WAY";
            }

			if (column + 1 <= plan.GetLength(1))
			{
				eastDir = plan[row, column + 1];
			}
			else
			{
				eastDir = "NO WAY";
			}

			if (row - 1 >= 0)
			{
				northDir = plan[row - 1, column];
			}
			else
			{
				northDir = "NO WAY";
			}

			if (row + 1 <= plan.GetLength(0))
			{
				southDir = plan[row + 1, column];
			}
			else
			{
				southDir = "NO WAY";
			}


			try
			{	
				return $" **** You are on coords {row}, {column} in the {plan[row, column]} ****\n {name} -->> ROOM EXITS:\n    WEST - {westDir}\n    NORTH - {northDir}\n    EAST - {eastDir}\n    SOUTH - {southDir}";
			}
			catch (IndexOutOfRangeException ex)
			{
				Console.WriteLine($"An error occurred: {ex.Message}");
				return $" {row}, {column} there is a wall or something";
			}
							
        }
	}
}
