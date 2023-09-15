using System;

namespace AdventureGame
{
    class Program
    {
        static void Main()
        {
            Game.StartGame();

            Item backpack = new() { name = "Backpack" };
            backpack.stuffInside.Add("Personal statblock");
            Lifeform player = new() { inventory = backpack };

            Lifeform[] enemyRoster = new Lifeform[]
            {
            new Lifeform() { name = Generator.PickEnemy(), AC = 3, maxHP = 10, currHP = 10, damage = 2, equippedWeapon = "Putrid claws" },
            new Lifeform() { name = Generator.PickEnemy(), AC = 2, maxHP = 20, currHP = 20, damage = 1, equippedWeapon = "You do not notice any" },
            new Lifeform() { name = Generator.PickEnemy(), AC = 5, maxHP = 7, currHP = 7, damage = 3, equippedWeapon = "Rusty kukri" }
            };

            player.name = Game.NameCharacter();
            player.equippedWeapon = Game.PickWeapon();
            // player.equippedWeapon, player.attackRange = Game.PickWeapon();

            

            while (player.encountersDone < 3)
            {
                Lifeform creature1 = enemyRoster[Generator.Roll(enemyRoster.Length)];
                if (!player.DoEngage())
                {
                    Game.OfferAgency(player, backpack);
                    if (!player.isHidden)
                    {
                        Console.WriteLine(" \nThe enemy closes the distance and engages you.\n");
                        Game.ResolveRound(player, creature1, true);
                        player.ShowHP();
                        creature1.ShowHP();

                        Game.GiveLoot(backpack, "A gold coin");
                        player.exp += 1;
                    }
                }
                else
                {
                    Game.ResolveRound(player, creature1, false);
                    player.ShowHP();
                    creature1.ShowHP();

                    Game.GiveLoot(backpack, "A gold coin");
                    player.exp += 1;
                }

                // Game.OfferAgency(player, backpack);
                Game.AfterActionReview(player, creature1);
            }

            // player can wait hidden or advance from corridor - offerAgencyAloof
            // player can use items or attack


            Game.EndGame(player);



            /*
             * 
             * class for a room - args all sides def as "wall", loot, enemy all def to 0; spawn rooms next to each othr by erasing walls, make functions to travel on grid, lifeform has a field for room IDs
             * */

        }
    }
}
