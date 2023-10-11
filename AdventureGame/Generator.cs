using System;

namespace AdventureGame
{
    //handle random generation of entities and dice rolls 
    public static class Generator
    {
        public static int Roll(int sidesNo)
        {
            Random random = new();
            return random.Next(sidesNo);
        }

        public static string PickEnemy(int difficulty = 0)
        //pool of enemies, choose at random for now
        //TODO separate enemies by difficulty, first roll for that
        //could be a 2 dimensonal array,
        { 
            //string[,] enemyByDifficulty = new string[3, 8];

            string [,] enemyByDifficulty = { { "hulkbat", "crazed surgeon", "infected guard", "shambling cadaver", "nightmare nurse", "screamrat", "shriekdog", "horror spider"},
                                  { "greater hulkbat", "greater crazed surgeon", "greater infected guard", "greater shambling cadaver", "greater nightmare nurse", "greater screamrat", "greater shriekdog", "greater horror spider"},
                                  { "alpha hulkbat", "alpha crazed surgeon", "alpha infected guard", "alpha shambling cadaver", "alpha nightmare nurse", "alpha screamrat", "alpha shriekdog", "alpha horror spider"}
            };

            string currEnemy = enemyByDifficulty[difficulty, Roll(8)];
        
            //String[] bestiary = { "hulkbat", "crazed surgeon", "infected guard", "shambling cadaver", "nightmare nurse", "screamrat", "shriekdog", "horror spider" };
            //int pick = Roll(bestiary.Length);
            //string currEnemy = bestiary.GetValue(pick).ToString();

          return currEnemy;
        }

        public static string NegativeAnswer()
        {
            String[] negAnswers = { "No", "     Nope", " Not possible", "   Invalid", "    Wrong", "  Try again", " Negative", "        Does not compute", " Nada", "   I don't understand" };
            int pick = Roll(negAnswers.Length);
            return negAnswers.GetValue(pick).ToString();
        }

        public static string PickLoot()
        {
            String[] lootables = { "Gold coin", "Piece of jerky", "Marble", "Rope", "Candle", "Shovel", "Nail", "Ligament", "Plazma powder", "Metal thingy", "Silver ring", "Ruby", "Prince jewel", "Platinum chip"};
            int pick = Roll(lootables.Length);
            return lootables.GetValue(pick).ToString();
        }
        public static string PickEnemyWeapon()
        {
            String[] arsenal = { "Putrid claws", "Plazma saber", "Rusty kukri", "Psi-link", "Omniknife", "Frigid breath", "Psyshred", "Death touch", "Plazma whip", "Neurorod", "Curse", "Firebolt" };
            int pick = Roll(arsenal.Length);
            return arsenal.GetValue(pick).ToString();
        }
    }
}
