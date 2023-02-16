using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903M_A01_2223
{
    class Pack
    {
        List<Card> pack = new List<Card>();

        public Pack()
        {
            string[] S = { "Clubs", "Diamonds", "Hearts", "Spades" };
            List<string> Suits = new List<string>(S);

            string[] V = { "Ace", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Jack", "Queen", "King" };
            List<string> Values = new List<string>(V);

            //Initialise the card pack here
            for (int a = 0; a < 4; a++) // suit
            {
                for (int b = 0; b < 13; b++) // value
                {
                    Card newcard = new Card
                    {
                        Value = b + 1,
                        Suit = a + 1
                    };
                    pack.Add(newcard);
                    
                }
            }

            foreach (var card in pack)
            {
                Console.WriteLine("Suit:" + card.Suit + "Value:" + card.Value);
            }
            
            Console.ReadLine();
        }

        /*
        public static bool ShuffleCardPack(int typeOfShuffle)
        {
            //Shuffles the pack based on the type of shuffle
            
        }
        public static Card Deal()
        {
            //Deals one card
            
        }
        public static List<Card> DealCard(int amount)
        {
            //Deals the number of cards specified by 'amount'
            
        } */
    }
}
