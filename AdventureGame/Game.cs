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
            Console.WriteLine("Much wow");
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

        public static string PickWeapon()
        {
            String chosenWeapon;
            String equippedWeapon = "Fists";
            bool choiceMadeInv = false;
            string attackRange;

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
                        equippedWeapon = " Plasma blade, throbbing with energy";
                        attackRange = "Close";
                        // Lifeform.damage = Generator.Roll(6);
                        Console.WriteLine(String.Format(" You picked up the {0}. Well done! You can attack at a {1} range. That's useful.", equippedWeapon, attackRange));
                        choiceMadeInv = true;
                        break;
                    case "2":
                        equippedWeapon = " Blaster, fully charged";
                        attackRange = "Long";
                        //Lifeform.damage = Generator.Roll(8);
                        Console.WriteLine(String.Format(" You picked up the {0}. Well done! You can attack at a {1} range. That's useful.", equippedWeapon, attackRange));
                        choiceMadeInv = true;
                        break;
                    case "3":
                        equippedWeapon = " Psi-console, seeing into minds of others";
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
            return equippedWeapon;        
        }

        public static void ResolveRound(Lifeform attacker, Lifeform defender)
        {
            while (defender.currHP > 0)
            {
                defender.currHP = attacker.ResolveTurnVs(defender);

                // narrate hitting the enemy

                if (defender.currHP > 0)
                {
                    // narrate enemy retaliate
                    attacker.currHP = defender.ResolveTurnVs(attacker);
                }
                else
                {
                    Console.WriteLine(" The " + defender.name + " died.");
                }
            }

            Console.WriteLine(" The corridor is silent.");
        }

        public static void OfferAgency(Lifeform lifeform, Item inventory)
        {
            Console.WriteLine("\n Time passes.\n .\n ..\n ...\n Ok, what would you like to do now?\n\n1. Hide\n2. Check backpack\n3. Check wristwatch\n");
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
                        Console.WriteLine(" You hold your breath and try to avoid detection.");
                        choiceMade = true;
                        break;
                    case ("2"):
                        Item.ShowContents(inventory);
                        choiceMade = true;
                        break;
                    case ("3"):
                        lifeform.ShowHP();
                        choiceMade = true;
                        break;
                    default:
                        Console.WriteLine(Generator.NegativeAnswer());
                        break;
                }

                Console.ReadKey();
            }
            
        }
    }
}
