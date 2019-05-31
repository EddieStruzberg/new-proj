using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication4
{
    class RandomNums
    {
        public static void Randomise()
        {
            Random rnd = new Random();
            int month = rnd.Next(1, 13); // creates a number between 1 and 12
            int dice = rnd.Next(1, 7);   // creates a number between 1 and 6
            int card = rnd.Next(52);     // creates a number between 0 and 51
            Console.WriteLine();
        }
        static public void Shuffle(int[] deck)
        {
            Random rnd = new Random();
            for (int n = deck.Length - 1; n > 0; --n)
            {
                int k = rnd.Next(n + 1);
                SwapTwoNumbers(ref deck[n], ref deck[k]);
                Console.WriteLine();
                //int temp = deck[n];
                //deck[n] = deck[k];
                //deck[k] = temp;
            }
        }
        static public void GetNRandomCardsAndRemoveThemFromdeck()
        {
            //GetNRandomCardsAndRemoveThemFromdeck(cards, SelectedCards, 5);
            List<string> deckList = new List<string>() { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };
            List<string> selectedList = new List<string>();
            int N = 5;

            Random rnd = new Random();
            int Count = deckList.Count;
            for (int i = 0; i < N && i < Count; i++)
            {
                int k = rnd.Next(Count - i);
                selectedList.Add(deckList[k]);
                deckList.RemoveAt(k);
            }
        }
        static public void SwapTwoNumbers(ref int num1, ref int num2)
        {
            num1 = num1 + num2;
            num2 = num1 - num2;
            num1 = num1 - num2;
        }
    }
}
}
