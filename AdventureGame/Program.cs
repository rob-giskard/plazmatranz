using System;

namespace AdventureGame
{
    class Program
    {
        static void Main()
        {
            Game.StartGame();

            Lifeform player = new();
           
            player.name = Game.NameCharacter();
            player.equippedWeapon = Game.PickWeapon();

            Lifeform creature1 = new() { name = Generator.PickEnemy(), AC = 2, maxHP = 20, currHP = 20, damage = 1, equippedWeapon = "You do not notice any" };
        
            if (!player.DoEngage())
            {
                Console.WriteLine("Time passes.");                 
            }
            else
            {
                Game.ResolveRound(player, creature1);
                player.ShowHP();
                creature1.ShowHP();
            }

            

        }
    }
}
