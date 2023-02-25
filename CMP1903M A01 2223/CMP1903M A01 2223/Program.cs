using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903M_A01_2223
{
    class Program // Actually runs the program.
    {
        public static bool TestActive { get; set; }
        static void Main(string[] args)
        {
            TestActive = true; // COMMENT THIS LINE TO REMOVE TESTING COMMANDS and play with the program yourself
            // Bool that tells the Menu that a test is active, and so therefore we don't need to gather user input.

            while (true)
            {
                Menu menu = new Menu();
            }
            Testing test = new Testing(); // COMMENT THIS LINE TO REMOVE TESTING COMMANDS and play with the program yourself
        }
    }
}
