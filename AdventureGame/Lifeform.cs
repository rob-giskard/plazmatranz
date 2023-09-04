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

        public void ShowHP()
        {
            Console.WriteLine("Name: " + name + 
                              "\n Hit points: " + currHP + "/" + maxHP +
                              "\n Weapon: " + equippedWeapon);
            Console.ReadKey();
        }
        public int ResolveTurnVs(Lifeform opponent) 
        // returns HP of the defender after 1 attack
        {
            int toHit = (Generator.Roll(20) + toHitBonus);

            if (toHit > opponent.AC)
            {
                Console.WriteLine("    *HIT!*\nDamage dealt: " + damage);
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

            Console.WriteLine("Do you want to engage in combat?\n1. Yes\n2. No");
            choice = Console.ReadLine();

            if (choice == "1")
            {
                return true;
            }
            else
            {
                Console.WriteLine("You wait and see what happens.");
                return false;                     
            }
            
        }
    }
}
