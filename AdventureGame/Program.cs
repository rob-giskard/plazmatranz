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

            /*
            Lifeform[] enemyRoster = new Lifeform[]
            {
            new Lifeform() { name = Generator.PickEnemy(), AC = 3, maxHP = 10, currHP = 10, damage = 2, equippedWeapon = "Putrid claws" },
            new Lifeform() { name = Generator.PickEnemy(), AC = 2, maxHP = 20, currHP = 20, damage = 1, equippedWeapon = "Plazma saber" },
            new Lifeform() { name = Generator.PickEnemy(), AC = 5, maxHP = 7, currHP = 7, damage = 3, equippedWeapon = "Rusty kukri" },
            new Lifeform() { name = Generator.PickEnemy(), AC = 5, maxHP = 7, currHP = 7, damage = 3, equippedWeapon = "Psi-link" },
            new Lifeform() { name = Generator.PickEnemy(), AC = 5, maxHP = 7, currHP = 7, damage = 3, equippedWeapon = "Omniknife" }
            };

            foreach (Lifeform enemy in enemyRoster)
                {
                Console.WriteLine(enemy.name);
                }
            */

            player.name = Game.NameCharacter();
            (player.equippedWeapon, player.attackRange) = Game.PickWeapon();
            int firstLevelLength = Game.StartLevel;

            Room atrium = new Room() { name = "atrium" };
            Room lab = new Room() { name = "Decrepit lab", row = 1, column = 2 };

            player.EnterRoom(lab);
            Console.WriteLine(lab.ShowRoomExits());
            
            Game.Reset();

            while (player.encountersDone < firstLevelLength)
            {
                //Lifeform creature1 = enemyRoster[Generator.Roll(enemyRoster.Length)];
                Lifeform creature1 = new Lifeform() { name = Generator.PickEnemy(0), AC = 3, maxHP = 10, currHP = 10, damage = 2, equippedWeapon = Generator.PickEnemyWeapon() };

                Console.WriteLine(String.Format(" \n\n ****\nIn the flickering light before you, a skulking {0} starts moving.\n ****\n", creature1.name));
                Console.ReadKey();

                if (!player.DoEngage())
                {
                    Game.OfferAgency(player, backpack);
                    // player hides
                    if (!player.isHidden)
                    {
                        Console.WriteLine(" \n ####\n You hesitated too long. The enemy closes the distance and engages you.\n ####\n");
                        Game.ResolveRound(player, creature1, true);
                        player.ShowHP();
                        creature1.ShowHP();

                        Game.GiveLoot(backpack, Generator.PickLoot());
                        player.exp += 1;
                    }
                }
                else
                {
                    Game.ResolveRound(player, creature1, false);
                    player.ShowHP();
                    creature1.ShowHP();

                    Game.GiveLoot(backpack, Generator.PickLoot());
                    player.exp += 1;
                }

                // Game.OfferAgency(player, backpack);
                Game.AfterActionReview(player, creature1);
            }

           
            Game.EndGame(player);



            /*
             * 
             * class for a room - args all sides def as "wall", loot, enemy all def to 0; spawn rooms next to each othr by erasing walls, make functions to travel on grid, lifeform has a field for room IDs
             * */

        }
    }
}
