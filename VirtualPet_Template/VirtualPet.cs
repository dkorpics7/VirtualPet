using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualPet_Template
{

    class VirtualPet
    {

        private string name;
        private double hunger;
        private double thirst;
        private double waste;
        private double boredom;
        private double sick;
        private bool terminate;

        // defaut constructor
        public VirtualPet()
        {
            this.name = "George";
            this.hunger = 5;
            this.thirst = 5;
            this.waste = 5;
            this.boredom = 5;
            this.sick = 2;
            this.terminate = false;
        }
        
        public VirtualPet(string name)
        {
            this.name = name;
        }

        public VirtualPet(string name, double hunger, double thirst, double waste, double boredom, double sick, bool terminate)
        {
            this.name = name;
            this.hunger = hunger;
            this.thirst = thirst;
            this.waste = waste;
            this.boredom = boredom;
            this.sick = sick;
            this.terminate = terminate;
        }

        //this method can be called to change the pet name
        public void NameChange(string petName)
        {
            if(petName !="")this.name = petName;
        }

        //this method can be called to change the hunger
        public void HungerChange(double change)
        {
            this.hunger = hunger + change;
        }

        //this method can be called to change the thirst
        public void ThirstChange(double change)
        {
            this.thirst = thirst + change;
        }

        //this method can be called to change the waste
        public void WasteChange(double change)
        {
            this.waste = waste + change;
        }

        //this method can be called to change the boredom
        public void BoredomChange(double change)
        {
            this.boredom = boredom + change;
        }

        //this method can be called to change the sickness
        public void SickChange(double change)
        {
            this.sick = sick + change;
        }

        //method for stats of virtual pet
        public void MyPetStatus(string userName, double score)
        {
            Console.WriteLine("\r\n{0}'s status: \t\t\t{1}'s score: {2}",name,userName,score);
            Console.WriteLine("\t\t\tHunger:   " + hunger.ToString("#.0"));
            Console.WriteLine("\t\t\tThirst:   " + thirst.ToString("#.0"));
            Console.WriteLine("\t\t\tWaste :   " + waste.ToString("#.0"));
            Console.WriteLine("\t\t\tBoredom:  " + boredom.ToString("#.0"));
            Console.WriteLine("\t\t\tSickness: " + sick.ToString("#.0"));
        }

        //method to print warnings when pet is in danger and adjust user score appropriately
        public double Warnings(string userName, double score)
        {
            int counterBad = 0;
            int counterGood = 0;
            double tempHunger = 0;
            double tempThirst = 0;
            double tempWaste = 0;
            double tempBoredom = 0;
            double tempSick = 0;
            double maxChange = 0.7;

            Console.WriteLine();
            if (hunger <= -2)
            {
                score = score - 5;
                Console.Clear();
                Console.WriteLine("\r\n\r\n\t{0}, we are sorry to inform you that {1} had a mild heart attack", userName, name);
                Console.WriteLine("due to his obese condition.  We have taken him to the vet and he is");
                Console.WriteLine("being treated.  Unfortunately, he will not be able to return to your home.");
                Console.WriteLine("\r\n\r\n\tDon't worry!  The vet said he will be better in a few months. ");
                terminate = true;
            }
            else if (hunger <= 2)
            {
                counterBad++;
                Console.WriteLine("*** Warning!  Your pet is full!  If you overfeed him, he might get sick.");
                tempSick   += (2 - hunger)/4;
                tempThirst += (2 - hunger)/4;
                tempWaste  += (2 - hunger)/4;
            }

            else if (hunger >= 8 && hunger <= 10)
            {
                counterBad++;
                Console.WriteLine("*** Warning!  Your pet is hungry!  Poor {0}!", name);
                tempSick  += (hunger - 8)/4;
                tempWaste += (8 - hunger)/4;
                tempBoredom += -0.2;
            }
            else if (hunger > 10 && hunger <= 15)
            {
                counterBad++;
                Console.WriteLine("*** Warning!  {0} got so hungry that he got into the trash!", name);
                Console.WriteLine("              Now, he has an upset stomach!");
                score = score - 2;
                tempSick += 0.5;
            }
            else if (hunger > 15)
            {
                score = score - 5;
                Console.Clear();
                Console.WriteLine("\r\n\r\n\t{0}, we are sorry to inform you that {1} ran away from home.", userName, name);
                Console.WriteLine("\r\n\r\n\tDon't worry, though!  Rumor has it that {0} found a neighbor ", name);
                Console.WriteLine("\twho cooks wonderful homemade meals for him.");
                terminate = true;
            }
            else
            {
                counterGood++;
            }
            if (thirst <=-3 && !terminate)
            {
                score = score - 5;
                Console.Clear();
                Console.WriteLine("\r\n\r\n\tUnfortunately, the reason {0} was drinking so much water was", name);
                Console.WriteLine("\tbecause he has diabetes.  Although it is not common in animals, it");
                Console.WriteLine("\tdoes happen.  We have had to put him in a special foster home where");
                Console.WriteLine("\this new owner can give him his medication and nurse him back to health");
                Console.WriteLine("\r\n\tDon't worry!  We checked on him this morning, and he was doing well.");
            }
            else if(thirst<=0 && !terminate)
            {
                counterBad++;
                Console.WriteLine("*** Warning!  {0} is drinking too much water.", name);
                Console.WriteLine("              You may need to take him to the vet.");
                tempSick += 0.3;
            }
            else if (thirst <= 2 && waste >5 && !terminate)
            {
                counterBad++;
                Console.WriteLine("*** Warning!  {0} had too much water and peed on the carpet!", name);
                Console.WriteLine("              You will be docked 2 points for this unfortunate mishap.");
                score = score - 2;
            }
            else if (thirst >= 8 && thirst < 10 && !terminate)
            {
                counterBad++;
                Console.WriteLine("*** Warning! {0} is very thirsty! Please give him water or he may get sick.", name);
                tempSick += (thirst - 8)/4;
                tempWaste += -0.2;
            }
            else if (thirst >= 10 && thirst <=15 && !terminate)
            {
                counterBad++;
                Console.WriteLine("*** Poor {0} has developed a bladder infection from not getting", name);
                Console.WriteLine("    enough water.  You must take him to the vet!");
                tempSick += 0.5;
                tempWaste += 0.3;
                tempBoredom += -0.3;
            }
            else if (thirst > 15 && !terminate)
            {
                score = score - 5;
                Console.Clear();
                Console.WriteLine("\r\n\r\n\t{0}, we are sorry to inform you that {1} was so", userName, name);
                    Console.WriteLine("\tdehydrated that the vet decided to find {0} a new owner",name);
                Console.WriteLine("\tthat would remember to give him water regularly.");
                Console.WriteLine("\r\n\tDon't be upset, though!  We have visited {0} in his new home,", name);
                Console.WriteLine("\tand he is very happy!");
                terminate = true;
            }
            else
            { 
                counterGood++;
            }

            if (waste <= 2 && !terminate)
            {
                counterBad++;
                Console.WriteLine("*** Warning!  {0} does not need to go to the bathroom", name);
            }
            else if (waste >=8 && waste < 11 && !terminate)
            {
                counterBad++;
                Console.WriteLine("*** Warning! You need to take {0} out to go to the bathroom.", name);
            }
            else if (waste >= 11 && waste < 13  && !terminate)
            {
                Console.WriteLine("*** Warning!  {0} could not hold it any longer and pooped on the floor!", name);
                Console.WriteLine("              You will be docked 2 points for this unfortunate mishap.");
                score = score - 2;
                counterBad++;
            }
            else if (waste >= 13 && waste <= 15 && !terminate)
            {
                counterBad++;
                Console.WriteLine("*** Poor {0} is constipated from trying to hold it!",name);
                Console.WriteLine("    You must take him to the vet!");
                tempSick += 0.5;
            }
            else if (waste>15 && !terminate)
            {
                score = score - 5;
                Console.Clear();
                Console.WriteLine("\r\n\r\n\t{0}, we are sorry to inform you that {1} could not", userName, name);
                Console.WriteLine("\thold it any longer!  He defiled your house so many times ");
                Console.WriteLine("\tthat the neighbors reported you to the housing committee.");
                Console.WriteLine("\tYou are being evicted from your home and have to move");
                Console.WriteLine("\tto an apartment where pets are not allowed.");
                Console.WriteLine("\r\n\tDon't worry about {0}!  We have already placed him", name);
                Console.WriteLine("\twith a new owner and he is doing well!");
                terminate = true;
            }
            else
            {
                counterGood++;
            }


            if (boredom <= -5 && sick < 7&& !terminate)
            {
                score = score - 5;
                Console.Clear();
                Console.WriteLine("\r\n\t{0}, we are sorry, but we had to give {1} to a new owner", userName, name);
                Console.WriteLine("\tHe needs an owner with a less active lifestyle.  You may want");
                Console.WriteLine("\tto consider a getting a Border Collie; they are wonderful pets");
                Console.WriteLine("\tbut require a lot of attention.");
                terminate = true;
            }
            else if (boredom <= 1 && sick < 7 && !terminate)
            {
                counterBad++;
                Console.WriteLine("*** Warning! {0} is tired.  He needs time to rest.",name);
                tempHunger += 0.2;
                tempThirst += 0.3;
                tempWaste += -0.2;
            }
            else if (boredom >= 8 && boredom < 10 && !terminate)
            {
                counterBad++;
                Console.WriteLine("*** Warning!  Why don't you take {0} to the park?  He needs stimulation.", name);
                tempSick += 0.2;

            }
            else if (boredom >= 10 && boredom <= 15 && !terminate)
            {
                counterBad++;
                Console.WriteLine("*** Warning!  {0} decided to \"play\" with your shoes out of boredom.", name);
                Console.WriteLine("              You lost 3 points and a pair of shoes!");
                score = score - 3;
                tempSick += 0.3;
            }
            else if (boredom > 15 && !terminate)
            {
                score = score - 5;
                Console.Clear();
                Console.WriteLine("\r\n\r\n\t{0}, I am ashamed of you!  We came to visit {1} and ", userName, name);
                Console.WriteLine("\tfound him starved for attention.  We just couldn't leave him.");
                Console.WriteLine("\tSo, we are currently looking for a new home for him.");
                Console.WriteLine("\tYou may want to consider a pet doesn't need much attention.");
                Console.WriteLine("\r\n\tI've heard pet rocks are fun!");
                terminate = true;
            }
            else
            {
                counterGood++;
            }


            if (sick >= 8 && sick < 10 && !terminate)
            {
                counterBad++;
                Console.WriteLine("*** Warning!  {0} doesn't look well.  It may be time to see the vet.", name);
            }
            else if (sick >= 10 && sick <= 15 && !terminate)
            {
                counterBad++;
                Console.WriteLine("*** Warning! {0} is very sick.  Take him to the vet immediately!", name);
                tempHunger += -0.2;
                tempThirst += -0.2;
                tempBoredom += -0.3;
            }
            else if (sick > 15 && !terminate)
            {
                score = score - 2;
                Console.Clear();
                Console.WriteLine("\r\n\t{0}, we apologize, but we had to rescue {1} before it was too late.", userName, name);
                Console.WriteLine("\r\n\tDon't worry!  The vet said he will recover eventually.");
                terminate = true;
            }
            else
            {
                counterGood++;
            }

            if (counterBad >= 1) Console.WriteLine("\a");                    // beep if their are any warnings

            if (tempHunger < (0-maxChange)) tempHunger = (0-maxChange);
            if (tempHunger > maxChange) tempHunger = maxChange;
            if (tempThirst < (0 - maxChange)) tempThirst = (0 - maxChange);
            if (tempThirst > maxChange) tempThirst = maxChange;
            if (tempWaste < (0 - maxChange)) tempWaste = (0 - maxChange);
            if (tempWaste > maxChange) tempWaste = maxChange;
            if (tempBoredom < (0 - maxChange)) tempBoredom = (0 - maxChange);
            if (tempBoredom > maxChange) tempBoredom = maxChange;
            if (tempSick < (0 - maxChange)) tempSick = (0 - maxChange);
            if (tempSick > maxChange) tempSick = maxChange;
            HungerChange(tempHunger);
            ThirstChange(tempThirst);
            WasteChange(tempWaste);
            BoredomChange(tempBoredom);
            SickChange(tempSick);

            score = score + counterGood/2;
            score = score - counterBad;
            return score;

        }

        //methods to make object states/attributes accessible from Program.cs
        public string GetName()
        {
            return name;
        }
        public double GetHunger()
        {
            return hunger;
        }
        public double GetThirst()
        {
            return thirst;
        }
        public double GetWaste()
        {
            return waste;
        }
        public double GetBoredom()
        {
            return boredom;
        }
        public double GetSick()
        {
            return sick;
        }
        public bool GetTerminate()
        {
            return terminate;
        }

        public double RandomEvent(int number, double newRndTime, string userName, string petName,double score, double time)  //random events
        {
            double rndTime = time;
            switch (number)
            {
                case 1: // pet was lost and found
                    Console.Clear();
                    Console.WriteLine("\r\n\t\a\a\a********************** ALERT ***********************");
                    Console.WriteLine("\r\n\t{0} got lost when he chased after a squirrel.", petName);
                    Console.WriteLine("\tHe returned home 3 hours later very tired and hungry!");
                    hunger += 1;                                       // increase hunger
                    thirst += 1;                                       // increase thirst
                    waste += -1;                                       // decrease need to go potty
                    boredom += -1.5;                                   // decrease boredom
                    sick += 0.5;                                       // increase pet's health
                    rndTime = newRndTime;                              // update time since last random event
                    MyPetStatus(userName, score);                      // print pet's current status
                    return rndTime;
                    break;
                case 5: // pet eats people food and gets sick
                    Console.Clear();
                    Console.WriteLine("\r\n\t\a\a\a************************ ALERT ***************************");
                    Console.WriteLine("\r\n\tYour friend gave {0} a steak bone and now {1}", petName, petName);
                    Console.WriteLine("\tis vomiting and has diarrhea and needs medicine from the vet.");
                    hunger += -1.5;                                    // decrease hunger
                    thirst += 1;                                       // increase thirst
                    waste += 2.5;                                      // increase need to go potty
                    boredom += -1.5;                                   // decrease boredom
                    sick += 2.5;                                       // increase pet's sickness
                    rndTime = newRndTime;                              // update time since last random event
                    MyPetStatus(userName, score);                      // print pet's current status
                    return rndTime;
                    break;
                case 13: // pet steals your dinner
                    Console.Clear();
                    Console.WriteLine("\r\n\t\a\a\a************************** ALERT *****************************");
                    Console.WriteLine("\r\n\t{0} stole your dinner right off your plate when you went", petName);
                    Console.WriteLine("\tto the bathroom.  You need to teach him some manners!");
                    hunger += -1;                                      // decrease hunger
                    thirst += 1;                                       // increase thirst
                    waste += 1;                                        // increase need to go potty
                    sick += 0.5;                                       // increase pet's sickness
                    rndTime = newRndTime;                              // update time since last random event
                    MyPetStatus(userName, score);                      // print pet's current status
                    return rndTime;
                    break;
                case 14: //pet saves child from drowning
                    Console.Clear();
                    Console.WriteLine("\r\n\t\a\a\a************************** ALERT *****************************");
                    Console.WriteLine("\r\n\t{0} saved the little girl next store from falling into the lake", petName);
                    Console.WriteLine("\tYou must be very proud of him!");
                    hunger += 1.5;                                     // decrease hunger
                    thirst += 1;                                       // increase thirst
                    waste += -0.5;                                     // increase need to go potty
                    sick += -1;                                        // increase pet's sickness
                    rndTime = newRndTime;                              // update time since last random event
                    MyPetStatus(userName, score);                      // print pet's current status
                    return rndTime;
                    break;
                case 21: // pet got into fight with dog next door
                    Console.Clear();
                    Console.WriteLine("\r\n\t\a\a\a************************** ALERT *****************************");
                    Console.WriteLine("\r\n\t{0} got into a fight with the dog next door.  He has a few", petName);
                    Console.WriteLine("\tbites that you might need to have looked at by your vet.");
                    sick += 2;                                         // increase pet's sickness
                    rndTime = newRndTime;                              // update time since last random event
                    MyPetStatus(userName, score);                      // print pet's current status
                    return rndTime;
                    break;
                case 27:  // pet wins in local dog show
                    Console.Clear();
                    Console.WriteLine("\r\n\t\a\a\a***************** CONGRATULATIONS **********************");
                    Console.WriteLine("\r\n\tYour {0} won \"Best in Show\" at the local dog show.", petName);
                    Console.WriteLine("\tIt was a stressful weekend, and {0} could use some pampering!", petName);
                    hunger += 1.5;                                     // increase hunger
                    thirst += 1;                                       // increase thirst
                    waste += 1;                                        // increase need to go potty
                    boredom += 2;                                      // increase pet's boredom
                    rndTime = newRndTime;                              // update time since last random event
                    MyPetStatus(userName, score);                      // print pet's current status
                    return rndTime;
                    break;
                case 32:  // pet is left in kennel for the weekend
                    Console.Clear();
                    Console.WriteLine("\r\n\t\a\a\a************************** ALERT *****************************");
                    Console.WriteLine("\r\n\tYou put {0} in the kennel this weekend because you went", petName);
                    Console.WriteLine("\tout of town. Poor {0} was depressed and didn't eat all weekend!", petName);
                    hunger += 2.5;                                     // increase hunger
                    thirst += 2;                                       // increase thirst
                    waste += 2;                                        // increase need to go potty
                    boredom += 2;                                      // increase pet's boredom
                    rndTime = newRndTime;                              // update time since last random event
                    MyPetStatus(userName, score);                      // print pet's current status
                    return rndTime;
                    break;
                case 39:  // pet is having accidents in the house
                    Console.Clear();
                    Console.WriteLine("\r\n\t\a\a\a************************** ALERT *******************************");
                    Console.WriteLine("\r\n\t{0} suddenly started having accidents in the house.  You need", petName);
                    Console.WriteLine("\tto keep him in his crate until he learns better. ");
                    Console.WriteLine("\tAlso, you may need to have the vet take a look at him.");
                    thirst += 1;                                       // increase thirst
                    waste += 1;                                        // increase need to go potty
                    boredom += 2;                                      // increase pet's boredom
                    sick += 2.5;                                       // increase pet's sickness
                    rndTime = newRndTime;                              // update time since last random event
                    MyPetStatus(userName, score);                      // print pet's current status
                    return rndTime;
                    break;
                case 43: // pet is becoming aggressive towards other dogs
                    Console.Clear();
                    Console.WriteLine("\r\n\t\a\a\a************************** ALERT *******************************");
                    Console.WriteLine("\r\n\t{0} is becoming more aggressive towards other animals.  You", petName);
                    Console.WriteLine("\twill need to work on socializing him to help him get over this.");
                    boredom += 2.5;                                    // increase pet's boredom
                    rndTime = newRndTime;                              // update time since last random event
                    MyPetStatus(userName, score);                      // print pet's current status
                    return rndTime;
                    break;
                case 49: // pet is overworked
                    Console.Clear();
                    Console.WriteLine("\r\n\t\a\a\a************************** ALERT *******************************");
                    Console.WriteLine("\r\n\t{0} is enjoying helping you train for your big hike, but he", petName);
                    Console.WriteLine("\tis getting awfully skinny!  You may need to increase his food portions");
                    hunger += 2;                                       // increase hunger
                    thirst += 2.5;                                     // increase thirst
                    waste += -2.0;                                     // reduce need to go potty
                    boredom += -2.5;                                   // decrease pet's boredom
                    rndTime = newRndTime;                              // update time since last random event
                    MyPetStatus(userName, score);                      // print pet's current status
                    return rndTime;
                    break;
                default: 
                    return rndTime;
                    break;
                }
            }
        }
    }
