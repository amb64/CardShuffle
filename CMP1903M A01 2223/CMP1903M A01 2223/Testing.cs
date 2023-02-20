using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903M_A01_2223
{
    class Testing // READ ME! Testing class. While the testing commands are run, you will see messages when the deck is empty asking you to re-open the program. You can ignore these.
    {
        public static Pack TestingPack { get; set; }
        public Testing() // Testing class. Will perform all actions in the program
        {

            int Amount = 51; // Variable to store the amount of cards to be dealt. You can adjust this to confirm error messages are displayed correctly.

            for (int a = 0; a < 3; a++) // Repeats 3 times, one for each type of shuffle.
            {
                TestingPack = new Pack();
                int TypeOfShuffle = a + 1; // Adding one due to index offset.
                Pack.ShuffleCardPack(TypeOfShuffle, TestingPack.pack); // Shuffling which the type determined previously
                //Pack.ViewPack(TestingPack.pack); // Optional. Un-commenting this line will display the full pack of cards after it has been shuffled.

                Card CardDealt = Pack.Deal(TestingPack.pack); // Dealing a card, storing it, and calling Show Card
                Menu.ShowCard(CardDealt, TestingPack.pack);
                List<Card> CardsDealt = Pack.DealCard(Amount, TestingPack.pack); // The same but for the amount of cards in the Amount variable.
                Menu.ShowCards(CardsDealt, TestingPack.pack);
            }

            Program.TestActive = false;
            Console.WriteLine("END OF TEST COMMANDS");
            Console.ReadLine();
        }   
        
    }
}
