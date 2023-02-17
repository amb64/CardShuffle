using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903M_A01_2223
{
    class Pack
    {
        // Creating a new list to store the Card objects. Public so it can be used by the Program file.
        public List<Card> pack = new List<Card>();

        public Pack()
        {
            // Creating a list that will store the names of Suits
            string[] S = { "Clubs", "Diamonds", "Hearts", "Spades" };
            List<string> Suits = new List<string>(S);

            // Creating a list that will store the names of the card Values
            string[] V = { "Ace", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Jack", "Queen", "King" };
            List<string> Values = new List<string>(V);

            //Initialise the card pack here
            for (int a = 0; a < 4; a++) // Iterating through the 4 suits
            {
                for (int b = 0; b < 13; b++) // Iterating through the 13 values
                {
                    Card Newcard = new Card // Creating a new card
                    {
                        Value = b + 1, // Setting the value and suit of this card. Need to plus one due to the offset with indexes
                        Suit = a + 1
                    };
                    pack.Add(Newcard); // Adds this card to the list of Cards (the pack of cards)
                    
                }
            }

            // Testing whether all cards where correctly created and added into the list
            /*foreach (var card in pack)
            {
                Console.WriteLine("Suit:" + card.Suit + "Value:" + card.Value);
            }
            
            Console.ReadLine();*/
            
        }


        public static bool ShuffleCardPack(int TypeOfShuffle, List<Card> pack)
        {
            //Shuffles the pack based on the type of shuffle. Is also passed the list of Card objects.

            Random Rand = new Random(); // Creating a new random object

            if (TypeOfShuffle == 1) // Fisher-Yates Shuffle
            {
                Console.WriteLine("Fisher-Yates Shuffle");

                for (int a = 0; a < 52; a++) // Iterates from 0 - 51 (the amount of cards) and increments by one for each iteration
                {
                    int Num = Rand.Next(0, a); // Randomly generates a number between 0 and a
                    Card Temp = pack[a]; // Temporarily stores the Card in the pack with the index of a in this variable
                    pack[a] = pack[Num]; // Replaces the Card with index a with the Card with the index of the randomly generated number
                    pack[Num] = Temp; // Replaces the Card with the index of the randomly generated number with the card temporarily stored earlier
                }

            
                //return true; // Returns true as the shuffle was successful
            }
            else if (TypeOfShuffle == 2) // Riffle Shuffle
            {
                Console.WriteLine("Riffle Shuffle");

                int n = 1; // Counter for the while loop
                while (n <= 7) // The while loop repeats 7 times as the deck must be shuffled 7 times for it to be random
                {
                    int b = Rand.Next(0, 52); // Randomly generates a number between 1 and 52 (upper exclusive) to be used as the "midpoint", where the deck would be split into two

                    Queue<Card> HalfA = new Queue<Card>();
                    for (int a = 0; a < (b - 1); a++)
                    {
                        HalfA.Enqueue(pack[a]);
                    }
                    Queue<Card> HalfB = new Queue<Card>();
                    for (int a = b; a < 52; a++)
                    {
                        HalfB.Enqueue(pack[a]);
                    }

                    /*Console.WriteLine("**HALF A**");
                    foreach (var card in HalfA)
                    {
                        Console.WriteLine("Suit:" + card.Suit + "Value:" + card.Value);
                    }
                    Console.WriteLine("**HALF B**");
                    foreach (var card in HalfB)
                    {
                        Console.WriteLine("Suit:" + card.Suit + "Value:" + card.Value);
                    }*/

                    /*int ALength = HalfA.Count();
                    int BLength = HalfB.Count();
                    int Length;

                    if (ALength > BLength)
                    {
                        Length = BLength;
                    }
                    else
                    {
                        Length = ALength;
                    }*/

                    List<Card> NewPack = new List<Card>();
                    for (int a = 0; a < 52; a++)
                    {
                        try
                        {
                            Card temp = HalfA.Dequeue();
                            NewPack.Add(temp);
                        }
                        catch (System.InvalidOperationException) { }
                        try
                        {
                            Card temp = HalfB.Dequeue();
                            NewPack.Add(temp);
                        }
                        catch (System.InvalidOperationException) { }
                        
                    }
                    

                    pack = NewPack;
                    n++; // n is incremented
               }

           }

           // For testing purposes. Prints out all the cards and the total number of cards
           foreach (var card in pack)
           {
               Console.WriteLine("Suit:" + card.Suit + "Value:" + card.Value);
           }
           Console.WriteLine("Number of cards: " + pack.Count);
           Console.ReadLine();
           return true;
       }

       /*public static Card Deal()
       {
           //Deals one card

       }

       public static List<Card> DealCard(int amount)
       {
           //Deals the number of cards specified by 'amount'

       } */
                }
            }
