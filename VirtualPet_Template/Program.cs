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
            //This program is a virtual pet program.  The user practices taking care of a virtual pet.
            //The program tracks the status of the pet and gives the user a score which represents their
            //skill at taking care of their pet.

            //Future improvements planned:  update user score in random events
            //                              prevent a random event from occuring twice
            //                              add more random events
            //                              allow a random event to terminate the program


            string input = "";                           // user input
            string userName;                             // user's name
            string petName;                              // pet's name
            string[] menu = new string[10];              // stores menu choices

            int selectedOption = -1;                     // menu choice (parsed from input)
            int counter = 0;                             // counter
            int randomNumber = -1;                       // random number
            double score = 0;                            // user's score
            double number;                               // dummy variable to hold temporary information
            double time, newTime, elapsedTime;           // time variables to determine elapsed time
            double rndTime, newRndTime;                  // elapsed time for random function


            bool quit;                                   // tests whether to quit the program

            VirtualPet myPet = new VirtualPet();         //instantiate a new Virtual Pet             
            Random rnd = new Random();                   // setup random number generator

            userName = Greet();                          // Greet the user and get their name
            petName = GetPetName(userName);              // Select pet name
            if(petName != "")myPet.Name = petName;       // Set pet name based on user input (unless it is blank)
            petName = myPet.Name;                        // set petName to myPet.Name which will be either default or user input


            //personalize menu choices with name of pet
            //this was setup this way in case I wanted to add more pet options in the future and vary the menu
            //for each different type of pet.  It is not necessary for the program as it is now.
            menu[1] = "  1. Feed " + myPet.Name + ".";
            menu[2] = "  2. Give " + myPet.Name + " water.";
            menu[3] = "  3. Take " + myPet.Name + " out to use the bathroom.";
            menu[4] = "  4. Take " + myPet.Name + "to the park to play.";
            menu[5] = "  5. " + myPet.Name + " isn't feeling well.  Take him to the vet.";
            menu[6] = "  6. Quit";


            time = DateTime.Now.Hour * 3600 + DateTime.Now.Minute * 60 + DateTime.Now.Second;  //get current time
            rndTime = time;
            do
            {
                counter++;
                if (counter > 4)                            //automatic changes to pet attributes based on time don't start until the 5th loop
                                                            //this gives the user a chance to get used to the program before it gets more difficult.
                {
                    score = myPet.Warnings(userName, score);                    // print warnings if pet is in danger and adjust user score
                    newTime = DateTime.Now.Hour * 3600 + DateTime.Now.Minute * 60 + DateTime.Now.Second;
                    elapsedTime = newTime - time;                               // calculate elapsed time since last menu entry
                    if (elapsedTime < 0) elapsedTime = 0;
                    if (elapsedTime > 20) elapsedTime = 20;                     //caps the elapsed time so that changes are not too great
                    myPet.HungerChange(elapsedTime * 0.2);                     //increase hunger as time goes by
                    myPet.ThirstChange(elapsedTime * 0.2);                     //increase thirst as time goes by
                    myPet.WasteChange(elapsedTime * 0.2);                      //increase waste as time goes by
                    myPet.BoredomChange(elapsedTime * 0.2);                    //increase boredom as time goes by
                    time = newTime;
                }
                quit = myPet.Terminate;                                    // get current terminate status

                if (!quit)
                {
                    myPet.MyPetStatus(userName, score);                       // print pet's current status

                    //set random events
                    randomNumber = rnd.Next(1, 50);                           // pick random number between 1 and 100
                    newRndTime = DateTime.Now.Hour * 3600 + DateTime.Now.Minute * 60 + DateTime.Now.Second;
                    if ((newRndTime - rndTime) > 15)                          // set minimum frequency of random events in seconds
                    {
                        rndTime = myPet.RandomEvent(randomNumber, newRndTime, userName, myPet.Name, score, rndTime); // get random event
                    }
                    Console.WriteLine();
                    Console.WriteLine("\r\n  Please select an option:\r\n");  // prompt user for menu choice
                    for (int i = 0; i < 7; i++)
                    {
                        Console.WriteLine(menu[i]);                               // print menu choices for user
                    }


                    input = Console.ReadLine().Trim().ToLower();                  // read user input
                    selectedOption = GetInput(input);                             // call method GetInput to validate user input
                }
                else
                {
                    selectedOption = 6;                                          // terminate program if terimate=true
                }


                switch (selectedOption)                                       // perform action based on user input
                {
                    case 1:                                                   // feed the pet

                        myPet.HungerChange(-1);
                        Console.Clear();
                        Console.WriteLine("\r\n\t\tThank you for feeding {0}!", myPet.Name);
                        break;

                    case 2:                                                   // give pet water

                        myPet.ThirstChange(-1);
                        Console.Clear();
                        Console.WriteLine("\r\n\t\tThank you for giving {0} water!", myPet.Name);
                        break;

                    case 3:                                                   // bathroom break!

                        myPet.WasteChange(-0.7);
                        Console.Clear();
                        Console.WriteLine("\r\n\tThank you for letting {0} outside to go potty!", myPet.Name);
                        break;

                    case 4:                                                  // play with pet

                        myPet.BoredomChange(-1);
                        myPet.HungerChange(0.2);
                        myPet.ThirstChange(0.4);
                        myPet.SickChange(-0.2);
                        myPet.WasteChange(-0.5);
                        Console.Clear();
                        Console.WriteLine("\r\n\t\t{0} had a wonderful time with you!", myPet.Name);
                        break;

                    case 5:                                                 // take pet to vet

                        myPet.SickChange(-2);
                        Console.Clear();
                        number = myPet.Sick;
                        if (number < 5) Console.WriteLine("\r\n\t{0} feels so much better now.  Thank you!", myPet.Name);
                        if (number < 8 && number >= 5) Console.WriteLine("\r\n\t{0} feels much better, but you should propbably\r\n\tkeep a close eye on him.", petName);
                        if (number >= 8) Console.WriteLine("\r\n\tThank you for taking {0} to the vet. He is still not feeling well\r\n\tand may need another visit.", petName);
                        break;

                    case 6:                                                 // quit

                        Console.WriteLine("\r\n\tThank you for playing, {0}.  Your final score is:  {1}", userName, score);
                        Console.WriteLine("\r\n\r\n\r\n\r\nPress return to exit...");
                        Console.ReadLine();
                        break;

                    default:

                        Console.WriteLine("*** Invalid option selected.\r\n\r\nPress any key to continue...");
                        Console.ReadKey();
                        break;
                }

            } while (selectedOption != 6);

        }
        static int GetInput(string input) // parses input string to return a valid user-selected menu option
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
        static string Greet()  // Greets the user, gets their name, and teaches how the program works.
        {
            string userName;

            Console.Write("\r\n\r\n\t\t\tWelcome to Adopt-A-Pet!\r\n\r\n\r\nPlease enter your name:  ");
            userName = Console.ReadLine().Trim();

            Console.Clear();
            Console.WriteLine("\r\n\r\n\r\n\r\n\t\t {0}, it is so nice to meet a fellow animal lover!", userName);
            Console.WriteLine("\r\n\tSince you are here, I probably don't need to tell you what a privilege");
            Console.WriteLine("\tit is to be a pet owner.  But, it is also a big responsibility!");
            Console.WriteLine("\tOur goal here at Adopt-A-Pet is to help you become more prepared");
            Console.WriteLine("\tto be a responsible pet owner.  So, let's get started!", userName);
            Console.WriteLine("\r\n\r\nPress any key to continue...");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("How it works:\r\n");
            Console.WriteLine("Your goal is to keep your pet healthy and happy. You will do this by");
            Console.WriteLine("by feeding him, playing with him, etc...  We will regularly show you");
            Console.WriteLine("how your pet is doing by displaying his status (see example below):");
            Console.WriteLine("\r\n\tYour Pet's status: \t\t\t{0}'s score: 100", userName);
            Console.WriteLine("\t\t\tHunger:  6.0");
            Console.WriteLine("\t\t\tBoredom: 7.8");
            Console.WriteLine("\t\t\tSickness: 9.5");
            Console.WriteLine("\r\nYou should try to keep the values between 2.0 and 8.0.  If they fall");
            Console.WriteLine("below 0.0 or above 10.0, you will be at danger of losing your pet!");
            Console.WriteLine("In the example above, you would need to get your pet to the vet since");
            Console.WriteLine("it's sickness status is close to 10.  You also would need to play with");
            Console.WriteLine("your pet as you can see he is getting bored.  We also evaluate your skills");
            Console.WriteLine("and give you a score based on how you are doing as an owner.  The higher");
            Console.WriteLine("the score the better!\r\n\t\t\t\t\tHave Fun!");
            Console.WriteLine("\r\n\r\nPress any key to start the game...");
            Console.ReadKey();
            Console.Clear();

            return userName;
        }
        static string GetPetName(string userName)  //Asks the user for the pet name
        {
            string petName;

            Console.Write("\r\n\r\n\r\n\t{0}, What would you like to call your pet?\r\n\t(if you hit return, we will pick a name for you):  ", userName);
            petName = Console.ReadLine().Trim();

            if (petName == "") Console.WriteLine("\r\n\r\n\tYour pet's name is George, and he is lucky to have such a \r\n\tconscientious owner.", petName);
            Console.WriteLine("\r\n\r\n\r\nPress any key to continue...");
            Console.ReadKey();
            Console.Clear();

            return petName;
        }

    }
}
