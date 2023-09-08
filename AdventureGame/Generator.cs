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

        public static string PickEnemy()
        //pool of enemies, choose at random for now
        //TODO separate enemies by difficulty, first roll for that
        {
            String[] bestiary = { "hulkbat", "crazed surgeon", "infected guard", "shambling cadaver", "nightmare nurse", "screamrat" };
            int pick = Roll(bestiary.Length);
            string currEnemy = bestiary.GetValue(pick).ToString();

            Console.WriteLine(String.Format("In the flickering light before you, a skulking {0} starts moving.", currEnemy));
            Console.ReadKey();

            return currEnemy;
        }

        public static string NegativeAnswer()
        {
            String[] negAnswers = { " No", " Nope", " Not possible", " Invalid", " Wrong", " Try again", " Negative" };
            int pick = Roll(negAnswers.Length);
            return negAnswers.GetValue(pick).ToString();
        }
    }
}
