using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualPet_Template
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = "";                           // user input
            bool valid = false;                          // tests validity of input from user
            int selectedOption = -1;                     // menu choice (parsed from input)

            //this is how we instantiate a new instance of our pet
            VirtualPet myPet = new VirtualPet();


            //TODO add a greeting for the user. you can also let the user name the pet if you like



            do
            {
                myPet.MyPetStatus();


                Console.WriteLine();
                Console.WriteLine("\r\n\r\n  Please select an option:\r\n");
                Console.WriteLine("  1. Feed the pet");
                Console.WriteLine("  2. Give your pet some water");
                Console.WriteLine("  3. Take your pet out to the bathroom");
                Console.WriteLine("  4. Play with your pet");
                Console.WriteLine("  5. Take your pet to the vet");
                Console.WriteLine("  6. Quit");


                input = Console.ReadLine().Trim().ToLower();                  // read user input
                selectedOption = GetInput(input);                             // call method GetInput to validate user input

 
                switch (selectedOption)
                {
                    //when the user selects option one we feed the pet
                    case 1:

                        myPet.HungerChange(-1);
                        Console.Clear();
                        Console.WriteLine("\t\tThank you for feeding the pet!");
                        break;

                    case 2:

                        myPet.ThirstChange(-2);
                        Console.Clear();
                        Console.WriteLine("\t\tThank you for giving your pet water!");
                        break;

                    case 3:

                        myPet.WasteChange(-3);
                        Console.Clear();
                        Console.WriteLine("\tThank you for taking your pet to the bathroom!");
                        break;

                    case 4:

                        myPet.BoredomChange(-3);
                        Console.Clear();
                        Console.WriteLine("\t\tYour pet appreciates your attention!");
                        break;

                    case 5:

                        myPet.SickChange(-4);
                        Console.Clear();
                        Console.WriteLine("\tYour pet feels so much better now.  Thank you!");
                        break;

                    case 6:

                        Console.WriteLine("\t\tThank you for playing.\r\n\r\n\r\n\r\nPress any key to continue...");
                        Console.ReadKey();
                        break;

                    default:

                        Console.WriteLine("***** Invalid option selected.");
                        break;
                }

                myPet.HungerChange(0.5);
                myPet.ThirstChange(0.5);
                myPet.WasteChange(0.5);
                myPet.BoredomChange(0.5);


            } while (selectedOption != 6);

        }
        static int GetInput(string input)
        {
            int selectedOption;
            double decimalNumber;
            bool validInt = false;
            bool validDouble = false;

            validInt = int.TryParse(input, out selectedOption);
            validDouble = double.TryParse(input, out decimalNumber);

            if (validInt)
            {
                return selectedOption;                       // a valid integer was entered
            }
            else if (validDouble)                             // a decimal number was entered
            {
                selectedOption = Convert.ToInt32(decimalNumber);  // convert to an integer
                return selectedOption;
            }
            else if (input == "quit" || input == "exit" || input == "q")
            {
                selectedOption = 6;
                return selectedOption;
            }
            else
            {
                selectedOption = -1;
                return selectedOption;
            }
        }

    }
}
