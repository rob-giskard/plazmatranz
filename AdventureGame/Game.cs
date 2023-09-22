using System;

namespace AdventureGame
{
    //handle introduction and character creation 
    public class Game
    {
        public static void StartGame() 
        {
            Console.Title = "Welcome screen";
            Console.WriteLine("====#### Adventure Game ####====");
            Console.WriteLine("Revamped classic");
            Console.WriteLine("Very programming");
            Console.WriteLine("Much wow\n\n\n\n\n\n\n\n");
            Console.ReadKey();
        }

        public static void EndGame(Lifeform forWhom)
        {
            Console.WriteLine(" \nGame is over, you achieved this:\n NAME: {0}\n GEAR: {1}\n DAMAGE BONUS: {2}\n EXP: {3}\n HIDE ATTEMPTS: {4}\n", forWhom.name, forWhom.equippedWeapon, forWhom.damage, forWhom.exp, forWhom.hideCounter);
            Item.ShowContents(forWhom.inventory);
            Console.ReadKey();
        }
        public static string NameCharacter()
        {
            String playerName;

            Console.Title = "Character creation";
            Console.WriteLine("Enter your name now.");
                      
            playerName = Console.ReadLine().ToString();

            Console.WriteLine(" Your chosen name is " + playerName);
            Console.ReadKey();
            return playerName;
        }

        public static (string weapon, string range) PickWeapon()
        {
            String chosenWeapon;
            String equippedWeapon = "Fists";
            bool choiceMadeInv = false;
            string attackRange = "Very close";

            Console.Title = "Equipment hub";
            Console.WriteLine("Choose from the available weapons:" +
                " 1. Plasma blade" +
                " 2. Blaster" +
                " 3. Psi-console");
                        
            while (!choiceMadeInv)
            {
                chosenWeapon = Console.ReadLine();
            
                switch (chosenWeapon)
                {
                    case "1":
                        equippedWeapon = "Plasma blade, throbbing with energy";
                        attackRange = "Close";
                        // Lifeform.damage = Generator.Roll(6);
                        Console.WriteLine(String.Format(" You picked up the {0}. Well done! You can attack at a {1} range. That's useful.", equippedWeapon, attackRange));
                        choiceMadeInv = true;
                        break;
                    case "2":
                        equippedWeapon = "Blaster, fully charged";
                        attackRange = "Long";
                        //Lifeform.damage = Generator.Roll(8);
                        Console.WriteLine(String.Format(" You picked up the {0}. Well done! You can attack at a {1} range. That's useful.", equippedWeapon, attackRange));
                        choiceMadeInv = true;
                        break;
                    case "3":
                        equippedWeapon = "Psi-console, seeing into minds of others";
                        attackRange = "Moderate";
                        //Lifeform.damage = Generator.Roll(8);
                        Console.WriteLine(String.Format(" You picked up the {0}. Well done! You can attack at a {1} range. That's useful.", equippedWeapon, attackRange));
                        choiceMadeInv = true;
                        break;
                    default:
                        Console.WriteLine(Generator.NegativeAnswer());
                        break;
                }
            }
            
            Console.ReadKey();
            return (equippedWeapon, attackRange); // attackRange;
                                   // make this return a tuple
        }

        public static void ResolveRound(Lifeform attacker, Lifeform defender, bool attackerSurprised)
        {
            if (attackerSurprised)
            {
                Console.WriteLine(" \nThe {0} attacks first.\n", defender.name);
                attacker.currHP = defender.ResolveTurnVs(attacker);
                Console.WriteLine(" \nOOPS\n");
                Console.ReadKey();
            }
            while (attacker.currHP >= 0 && defender.currHP >= 0)
            {
                Console.Title = "Combat";
                defender.currHP = attacker.ResolveTurnVs(defender);
                Console.ReadKey();

                // narrate hitting the enemy

                if (defender.currHP > 0)
                {
                    // narrate enemy retaliate
                    attacker.currHP = defender.ResolveTurnVs(attacker);
                    Console.ReadKey();
                    if (attacker.currHP <= 0)
                    {
                        Console.WriteLine("\n{0}, you died. Try again or go and do something useful.", attacker.name);
                        Game.EndGame(attacker);
                    }
                }
                else
                {
                    Console.WriteLine(" The {0} died.", defender.name);
                    
                }
            }

            Console.WriteLine(" The corridor is silent.");
        }

        public static void OfferAgency(Lifeform player, Item inventory)
        {
            Console.WriteLine("\n Time passes.\n\n .\n\n  ..\n\n   ...\n\n Ok, what would you like to do now?\n\n1. Hide\n2. Check backpack\n3. Check wristwatch\n");
            // time delay here
            // Console.WriteLine(" Huh?\n1. What can I do?");

            String choice;
            bool choiceMade = false;
            
            while (!choiceMade)
            {
                choice = Console.ReadLine();

                switch (choice)
                {
                    case ("1"):
                        Console.WriteLine(" \nYou hold your breath and try to avoid detection.\n");
                        choiceMade = true;
                        player.isHidden = true;
                        player.hideCounter += 1;
                        // Console.ReadKey();
                        break;
                    case ("2"):
                        Item.ShowContents(inventory);
                        choiceMade = true;
                        // Console.ReadKey();
                        break;
                    case ("3"):
                        player.ShowHP();
                        choiceMade = true;
                        // Console.ReadKey();
                        break;
                    default:
                        Console.WriteLine(Generator.NegativeAnswer());
                        break;
                }

                Console.ReadKey();
            }
            
        }
        // make this to return a list/array of items 
        // take more string args 
        public static void GiveLoot(Item toContainer, string loot)
        {
            toContainer.stuffInside.Add(loot);
            Console.WriteLine(" \n{0} was added to your backpack.\n", loot);

            Console.ReadKey();
        }

        public static void AfterActionReview(Lifeform player, Lifeform enemy)
        {
            if (player.isHidden)
            {
                Console.WriteLine(" \nThe {0} passes you obliviously. Luck is at your side.\n\nYou leave your hiding place and continue down the corridor.\n", enemy.name);
            }
            else
            {
                Console.WriteLine(" \nYou leave the {0}'s remains behind and continue down the corridor. Prepare for another encounter.\n", enemy.name);
                player.isHidden = false; 
            }
            player.encountersDone += 1; 
            Console.ReadKey();
        }

        public static int StartLevel()
        {
            string len;

            Console.WriteLine(" \nYou find yourself in a dank corridor.\n -> You can decide how many enemies you encounter. Type a number.");
            
            len = (Console.ReadLine());
            int number;
            bool success = int.TryParse(len, out number);

            while (!numberSet)
            {
                if (success)
                {
                    Console.WriteLine($"You chose {number}. Good.");
                }
                else
                {
                    Console.WriteLine($"What is taht?!");
                }
            }
        }
    }
}
