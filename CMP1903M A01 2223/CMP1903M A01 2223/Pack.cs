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
                Console.WriteLine("\nYou have chosen the Fisher-Yates Shuffle.\n");

                for (int a = 0; a < 52; a++) // Iterates from 0 - 51 (the amount of cards) and increments by one for each iteration
                {
                    int Num = Rand.Next(0, a); // Randomly generates a number between 0 and a
                    Card Temp = pack[a]; // Temporarily stores the Card in the pack with the index of a in this variable
                    pack[a] = pack[Num]; // Replaces the Card with index a with the Card with the index of the randomly generated number
                    pack[Num] = Temp; // Replaces the Card with the index of the randomly generated number with the card temporarily stored earlier
                }

                return true; // Returns true as the shuffle was successful
            }


            else if (TypeOfShuffle == 2) // Riffle Shuffle
            {
                Console.WriteLine("\nYou have chosen the Riffle Shuffle\n");

                int n = 1; // Counter for the while loop
                int Choice; // User input variable

                if (Program.TestActive == true)
                {
                    Choice = 7;
                }
                else
                {
                    while (true) // Infinite loop
                    {
                        Console.WriteLine("____________________________________________________________________________________");
                        Console.WriteLine("\nHow many times would you like to perform the Riffle Shuffle? (7 times is considered to be random.)\n");

                        try
                        {
                            Choice = Convert.ToInt32(Console.ReadLine()); // Reads user input as an integer

                            if (Choice <= 0 || Choice > 20) // If the user inputs a number less than 0 or one higher than 20, continue through the loop
                            {
                                Console.WriteLine("\nInvalid input. Please enter a number between 1 and 20.");
                                continue;
                            }
                            else // Otherwise, break out of the loop and begin the shuffle
                            {
                                break;
                            }

                        }
                        catch (System.FormatException) // Shows an error message if the user doesn't input a number.
                        {
                            Console.WriteLine("\nInvalid input. Please enter a number between 1 and 20.");
                        }

                    }
                }
                

                while (n <= Choice) // The while loop repeats as many times as the user has decided
                {
                    int b = Rand.Next(0, 52); // Randomly generates a number between 1 and 52 (upper exclusive) to be used as the "midpoint", where the deck would be split into two

                    Queue<Card> HalfA = new Queue<Card>(); // Creates two queues that store half of the pack of cards. The pack is split using the midpoint, b.
                    for (int a = 0; a < b; a++) // From the first card to the card before the midpoint (the condition is a < b because the upper bound is exclusive!)
                    {
                        HalfA.Enqueue(pack[a]);
                    }
                    Queue<Card> HalfB = new Queue<Card>();
                    for (int a = b; a < 52; a++) // From the midpoint card to the end of the pack
                    {
                        HalfB.Enqueue(pack[a]);
                    }

                    int WhichSide = Rand.Next(0, 2); // Generates which side of the new deck will be put on top
                    List<Card> NewPack = new List<Card>(); // A list is created to store the new, shuffled pack

                    if (WhichSide == 0) // First half first
                    {
                        for (int a = 0; a < 52; a++) // This loop will dequeue a card in the relevant half and then add it to the NewPack list, alternating between halves.
                        {
                            try // Exceptions are used here because as the midpoint is random, one half of the deck will be bigger. If one side has run out of cards, it will not cause the program to crash
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
                    }
                    else if (WhichSide == 1) // Second half first
                    {
                        for (int a = 0; a < 52; a++) // This loop will dequeue a card in the relevant half and then add it to the NewPack list, alternating between halves.
                        {
                            try // Exceptions are used here because as the midpoint is random, one half of the deck will be bigger. If one side has run out of cards, it will not cause the program to crash
                            {
                                Card temp = HalfB.Dequeue();
                                NewPack.Add(temp);
                            }
                            catch (System.InvalidOperationException) { }
                            try
                            {
                                Card temp = HalfA.Dequeue();
                                NewPack.Add(temp);
                            }
                            catch (System.InvalidOperationException) { }
                        }
                    }
                    

                    pack = NewPack; // The original pack of cards is replaced with the now shuffled NewPack list.

                    n++; // n is incremented so the shuffle occurs again until it has been done 7 times.

                }

                Menu.PackOfCards.pack = pack; // This line is required because for some reason the pack is only updated locally.
                if (Program.TestActive == true) // If testing is active, this line is required to update the pack in the testing class.
                {
                    Testing.TestingPack.pack = pack;
                }

                //ViewPack(pack); // For testing.

                Console.WriteLine("\nThe deck has been shuffled " + Choice + " times."); // Tells the user that the deck has been shuffled.
                return true; // Returns true as the shuffle was successful
           }


            else if (TypeOfShuffle == 3) // No shuffle
            {
                Console.WriteLine("\nYou have chosen to not shuffle the deck.\n");
                return true; // Returns true as the "shuffle" was successful
            }


            else
            {
                return false; // Returns false as the input was invalid.
            }

       }


       public static Card Deal(List<Card> pack)
       {
            //Deals one card

            try // Exceptions are used as if the deck is empty, no more cards can be dealt
            {
                Card DealtCard = pack.Last(); // Deals and stores the last card in the pack, to simulate taking a card off of the top of the deck
                pack.Remove(DealtCard); // Removes the card from the pack

                return DealtCard; // Returns the card that was dealt.
            }
            catch (System.InvalidOperationException) 
            {
                return null; // If no cards are left in the deck, null is returned
            }
        }

        public static List<Card> DealCard(int amount, List<Card> pack)
        {
            //Deals the number of cards specified by 'amount'

            List<Card> DealtCards = new List<Card>();

            for (int a = 0; a < amount; a++)
            {
                try // Exceptions are used as if the deck is empty, no more cards can be dealt
                {
                    Card DealtCard = pack.Last(); // Deals and stores the last card in the pack, to simulate taking a card off of the top of the deck
                    pack.Remove(DealtCard); // Removes the card from the pack

                    DealtCards.Add(DealtCard); // Adds the dealt card to the list
                }
                catch (System.InvalidOperationException) { }
            }

            return DealtCards; // Returns the cards that were dealt.

        }

        // READ ME! Additional method created to testing purposes to print out all of the card after being shuffled.
        public static void ViewPack(List<Card> pack)
        {
            // For testing purposes. Prints out all the cards and the total number of cards

            foreach (var card in pack)
            {
                Console.WriteLine("Suit:" + card.Suit + "Value:" + card.Value);
            }
            Console.WriteLine("Number of cards: " + pack.Count);
            Console.ReadLine();
        }

    }
}
            
