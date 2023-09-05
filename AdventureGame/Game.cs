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
            String attackRange = "Very close";

            Console.Title = "Equipment hub";
            Console.WriteLine("Choose from the available weapons:" +
                " 1. Plasma blade" +
                " 2. Blaster" +
                " 3. Psi-console");
            chosenWeapon = Console.ReadLine();

            switch (chosenWeapon)
            {
                case "1":
                    equippedWeapon = " Plasma blade, throbbing with energy";
                    // Lifeform.damage = Generator.Roll(6);
                    Console.WriteLine(String.Format(" You picked up the {0}. Well done! You can attack at a {1} range. That's useful.", equippedWeapon, attackRange));
                    break;
                case "2":
                    equippedWeapon = " Blaster, fully charged";
                    //Lifeform.damage = Generator.Roll(8);
                    Console.WriteLine(String.Format (" You picked up the {0}. Well done! You can attack at a {1} range. That's useful.", equippedWeapon, attackRange));
                    break;
            // TODO number 3 
            // handle case when no option is picked as using fists
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

        public static void OfferAgency()
        {
            Console.WriteLine("\n Time passes.\n .\n ..\n ...\nOk, what would you like to do now?");
            // time delay here
            Console.WriteLine(" Huh?\n1. What can I do?");


            string choice = Console.ReadKey().ToString();

            // backpack, wristwatch (broken), comlog, hide
        }
    }
}
