using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903M_A01_2223
{
    class Menu // READ ME ! Additional class created to handle the interface between the program and the user. Handles all user input and output to the user.
    {
        // Creating the pack object variable
        public static Pack PackOfCards { get; set; }
        public static List<string> Suits { get; set; }
        public static List<string> Values { get; set; }

        public Menu()
        {
            PackOfCards = new Pack(); // Makes the pack object

            // Creating a list that will store the names of Suits
            string[] S = { "Clubs", "Diamonds", "Hearts", "Spades" };
            Suits = new List<string>(S);

            // Creating a list that will store the names of the card Values
            string[] V = { "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Jack", "Queen", "King", "Ace" };
            Values = new List<string>(V);


            Console.WriteLine("____________________________________________________________________________________");
            Console.WriteLine("\nCARD SHUFFLING PROGRAM");
            Console.WriteLine("\nA pack of cards has been created."); // Introductory lines of the program

            if (Program.TestActive == false) // Program will not proceed if the testing commands are being carried out
            {
                WhichShuffle(); // Calls which shuffle to ask user which shuffle they want to use
            }

            
        }

        public static void WhichShuffle() // Asks user what shuffle will be used
        {
            while (true) // Loop that will continue until broken out of
            {
                Console.WriteLine("____________________________________________________________________________________");
                Console.WriteLine("\nPlease select which shuffle you would like to perform on the cards:\n\n 1 - Fisher-Yates\n 2 - Riffle\n 3 - No shuffle\n");
                try // Exceptions used for handling erroneous input
                {
                    int Choice = Convert.ToInt32(Console.ReadLine()); // Getting input as an integer then shuffling the pack accordingly
                    bool Result = Pack.ShuffleCardPack(Choice, PackOfCards.pack);
                    if (Result == false) // If the user inputted a number over 3, a message is displays and the loop continues
                    {
                        Console.WriteLine("\nInvalid input. Please type the number of the shuffle and press enter.");
                        continue;
                    }
                    DealSomeCards(); // Calls this so the user can choose to deal cards.
                    break; // Breaks out of the loop
                }
                catch (System.FormatException)
                {
                    Console.WriteLine("\nInvalid input. Please type the number of the shuffle and press enter."); // Notifies the user that their input was invalid if they didn't enter a number
                }
                
            }
            
        }
        
        // Encapsulation
        private static void DealSomeCards() // Asking the user how many cards they want to deal
        {

            while (true) // Loop that continues until broken out of
            {
                Console.WriteLine("____________________________________________________________________________________");
                Console.WriteLine("\nPlease type how many cards you would like to deal from the deck.\n");
                try // Exceptions used for erroneous input
                {
                    int Choice = Convert.ToInt32(Console.ReadLine()); // Reads user input as an integer
                    if (Choice == 1) // Dealing one card
                    {
                        Card CardDealt = Pack.Deal(PackOfCards.pack); // Calls the method in pack to deal a card
                        bool Result = ShowCard(CardDealt, PackOfCards.pack); // Passes the card to this method so it is displayed to the user
                        if (Result == false) // If the method returns false, the deck is empty, and the loop ends once the user presses enter
                        {
                            Console.ReadLine();
                            break;
                        }
                    }
                    else if (Choice <= 52 && Choice > 1)
                    {
                        List<Card> CardsDealt = Pack.DealCard(Choice, PackOfCards.pack); // Calls the method in pack to deal the specified number of cards
                        bool Result = ShowCards(CardsDealt, PackOfCards.pack); // Passes the cards to this method so they are displayed to the user
                        if (Result == false) // If the method returns false, the deck is empty, and the loop ends once the user presses enter
                        {
                            Console.ReadLine();
                            break;
                        }
                    }
                    else // Shows an error message if the user inputs a number higher than the amount of cards in the deck, or one less than 1
                    {
                        Console.WriteLine("\nInvalid input. Please input a number between 1 and 52.");
                    }

              
                }
                catch (System.FormatException) // Shows an error message if the user doesn't input a number correctly
                {
                    Console.WriteLine("\nInvalid input. Please type the number of cards you want to deal and press enter.");
                }

            }
        }

        public static bool ShowCard(Card CardDealt, List<Card> pack) // Displays the card the user dealt
        {
            if (CardDealt == null) // Tells the user to reopen the program if the deck is empty
            {
                Console.WriteLine("____________________________________________________________________________________");
                Console.WriteLine("\nThe deck is empty.\nPress enter to make a new deck.");
                Console.ReadLine();
            }

            int Suit = CardDealt.Suit;
            int Value = CardDealt.Value; // Reads the suit and value of the card

            string s = Suits[Suit - 1]; // Grabs the word / string equivalent of these variables ( subracting 1 due to index offset )
            string v = Values[Value - 1];

            int Left = pack.Count(); // Gets the amount of cards left in the deck.

            Console.WriteLine("____________________________________________________________________________________\n");
            Console.WriteLine("Your card is the " + v + " of " + s); // Output

            if (Left == 0) // Will notify the user if there are no cards left in the deck.
            {
                Console.WriteLine("\nThe deck is now empty.\nPress enter to make a new deck.");
                return false;
            }
            else
            {
                Console.WriteLine("____________________________________________________________________________________");
                Console.WriteLine("\n1 card was dealt.\nThere are " + Left + " cards left in the deck."); // Tells the user that one card was dealt and the amount of cards left in the deck.
                return true;
            }
            
        }

        public static bool ShowCards(List<Card> CardsDealt, List<Card> pack)
        {
            Console.WriteLine("____________________________________________________________________________________");

            int Counter = 0;

            foreach (Card card in CardsDealt)
            {
                try
                {
                    int Suit = card.Suit;
                    int Value = card.Value; // Reads the suit and value of the card

                    string s = Suits[Suit - 1]; // Grabs the word / string equivalent of these variables ( subracting 1 due to index offset )
                    string v = Values[Value - 1];

                    Console.WriteLine("\nCard number " + (Counter + 1) + " is the " + v + " of " + s); // Output
                }
                catch (System.InvalidOperationException) // If the deck is empty, displays a message to the user
                {
                    Console.WriteLine("____________________________________________________________________________________");
                    Console.WriteLine("\nThe deck is empty.\nPress enter to make a new deck.");
                    Console.ReadLine();
                }

                Counter++; // Incremements the counter for this loop
            }

            int Left = pack.Count();

            if (Left == 0) // Will notify the user if there are no cards left in the deck. Will still tell them how many cards were dealt.
            {
                Console.WriteLine("____________________________________________________________________________________");
                Console.WriteLine("\n" + Counter + " cards were dealt.");
                Console.WriteLine("\nThe deck is now empty.\nPress enter to make a new deck.");
                return false;
            }
            else
            {
                Console.WriteLine("____________________________________________________________________________________");
                Console.WriteLine("\n" + Counter + " cards were dealt.\nThere are " + Left + " cards left in the deck."); // Tells the user how many cards were dealt and the amount of cards left in the deck.
                return true;
            }
            
            

        }

    }
}
