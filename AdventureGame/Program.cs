using System;

namespace AdventureGame
{
    class Program
    {
        static void Main()
        {
            Game.StartGame();

            Lifeform player = new();
            Item backpack = new() {name = "Backpack" };
            backpack.stuffInside.Add("Personal statblock");
           
            player.name = Game.NameCharacter();
            player.equippedWeapon = Game.PickWeapon();

            Lifeform creature1 = new() { name = Generator.PickEnemy(), AC = 2, maxHP = 20, currHP = 20, damage = 1, equippedWeapon = "You do not notice any" };
        
            if (!player.DoEngage())
            {
                Game.OfferAgency(player, backpack);                           
            }
            else
            {
                Game.ResolveRound(player, creature1);
                player.ShowHP();
                creature1.ShowHP();
            }

            /*
             * 
             * class for a room - args all sides def as "wall", loot, enemy all def to 0; spawn rooms next to each othr by erasing walls, make functions to travel on grid, lifeform has a field for room IDs
             * */

        }
    }
}
