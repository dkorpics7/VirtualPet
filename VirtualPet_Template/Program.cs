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
            string[] menu = new string[10];              // stores menu choices
            string name;
            double hunger, thirst, waste, boredom, sick;

            //this is how we instantiate a new instance of our pet
            VirtualPet myPet = new VirtualPet("George", 5, 5, 5, 5, 5);


            //TODO add a greeting for the user. you can also let the user name the pet if you like
            //TODO let user select pet (add pictures if possible)
            //TODO add warnings and consequences when status levels get near 0 or 10 (add pictures if possible
            //TODO make states interact and effect each other
            //TODO add timer to automatically change attributes with time
            //TODO add scale to show current status levels

            menu[1] = "  1. Feed " + myPet.GetName() + ".";
            menu[2] = "  2. Give " + myPet.GetName() + " water.";
            menu[3] = "  3. Take " + myPet.GetName() + " out to use the bathroom.";
            menu[4] = "  4. Play with " + myPet.GetName() + ".";
            menu[5] = "  5. " + myPet.GetName() + " isn't feeling well.  A vet visit is in order.";
            menu[6] = "  6. Quit";
            

            do
            {
                myPet.MyPetStatus();                                         // print pet's current status


                Console.WriteLine();
                Console.WriteLine("\r\n\r\n  Please select an option:\r\n");
                for (int i = 0; i < 7; i++)                       
                {
                    Console.WriteLine(menu[i]);                               // print menu choices for user
                }

                
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
                        Console.WriteLine("\r\n\t\tThank you for giving your pet water!");
                        break;

                    case 3:

                        myPet.WasteChange(-3);
                        Console.Clear();
                        Console.WriteLine("\r\n\tThank you for taking your pet to the bathroom!");
                        break;

                    case 4:

                        myPet.BoredomChange(-3);
                        Console.Clear();
                        Console.WriteLine("\r\n\t\tYour pet appreciates your attention!");
                        break;

                    case 5:

                        myPet.SickChange(-4);
                        Console.Clear();
                        Console.WriteLine("\r\n\tYour pet feels so much better now.  Thank you!");
                        break;

                    case 6:

                        Console.WriteLine("\r\n\t\tThank you for playing.\r\n\r\n\r\n\r\nPress any key to continue...");
                        Console.ReadKey();
                        break;

                    default:

                        Console.WriteLine("***** Invalid option selected.\r\n\r\nPress any key to continue...");
                        Console.ReadKey();
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
