using System;

namespace AdventureGame
{ 
    public class Lifeform
    {
        public string name;
        public int maxHP = 10;
        public int currHP = 10;
        public int AC = 5;
        public static int toHitBonus = 3; 
        public string equippedWeapon;
        public int damage = 5;
        public int exp = 0;
        public Item inventory;
        public bool isHidden = false;
        public int encountersDone = 0;
        public int hideCounter = 0;
        public string attackRange = "Very close";
        public string inRoom = "Corridor";

        public void ShowHP()
        {
            Console.WriteLine("Name: " + name +
                              "\n Hit points: " + currHP + "/" + maxHP);
            Console.ReadKey();
        }
        public int ResolveTurnVs(Lifeform opponent) 
        // returns HP of the defender after 1 attack
        {
            int toHit = (Generator.Roll(20) + toHitBonus);
            isHidden = false;

            if (toHit > opponent.AC)
            {
                Console.WriteLine("    *HIT!*\nDamage dealt: {0} to {1} with {2}.", damage, opponent.name, equippedWeapon);
                opponent.currHP -= damage;
                return opponent.currHP;
            }
            else
            {
                Console.WriteLine("    *MISS*");
                return opponent.currHP;
            }
        }

        public bool DoEngage()
        {
            string choice;

            Console.WriteLine($" \n{name}, do you want to engage in combat?\n\n          1. Yes              2. No");
            choice = Console.ReadLine();

            if (choice == "1")
            {
                isHidden = false;
                return true;
            }
            // secret reset button
            else if (choice == "k")
            {
                Game.Reset();
                return false;
            }
            else 
            {
                Console.WriteLine(" You wait and see what happens.");
                return false;
            }
            
        }

        public void EnterRoom(Room room)
        {
            Console.WriteLine(" \nYou entered the {0}", room.name);
            this.inRoom = room.name;
            Console.ReadKey();
            //

            Console.WriteLine($" \nYou are in {this.inRoom}");
            Console.ReadKey();
        }
    }
}
