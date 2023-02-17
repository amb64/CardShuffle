using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903M_A01_2223
{
    class Program
    {
        static void Main(string[] args)
        {
            Pack PackOfCards = new Pack();

            Console.WriteLine("Please enter a number");
            int Choice = Convert.ToInt32(Console.ReadLine());
            Pack.ShuffleCardPack(Choice, PackOfCards.pack);
        }
    }
}
