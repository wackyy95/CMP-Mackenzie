using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903M_A01_2223
{
    //the testing class runs the whole code 
    internal class Testing
    {
     // it is what allows the user to select the type of shuffle they want out of the fisher-yates shuffle or the riffle shuffle. it also allows the user 
     //to deal one card at a time or multiple cards by calling classes from the pack class
     // it also allows them to do no shuffle or quit the programs
        public Testing()
        {
            bool Quitprogram = false;
            Console.WriteLine("welcome to the card shuffler program");
            Console.WriteLine("\n");
            while (Quitprogram == false)
            {
                bool stopdealing = false;
                Pack y = new Pack(4, 52);
                Console.WriteLine("what type of shuffle would you like to perform?");
                Console.WriteLine("1: Fisher-Yates Shuffle");
                Console.WriteLine("2: Riffle Shuffle");
                Console.WriteLine("3: No Shuffle");
                Console.WriteLine("4: Quit");
                Console.WriteLine("\n");
                int userinp = int.Parse(Console.ReadLine());
                if (userinp >= 1 || userinp <= 3)
                {
                    Pack.shuffleCardPack(userinp);
                }
                else if (userinp == 4)
                {
                    Quitprogram = true;
                    stopdealing = true;
                }
                else
                {
                    Console.WriteLine("Please pick from the options provided");

                }
                while (stopdealing == false)
                {
                    Console.WriteLine("\n");
                    Console.WriteLine("Please pick a following option");
                    Console.WriteLine("1: Deal one card");
                    Console.WriteLine("2: Deal multiple card");
                    Console.WriteLine("3: stop dealing");
                    int userinp2 = int.Parse(Console.ReadLine());
                    if (userinp2 == 1)
                    {
                       Pack.deal();
                        bool dealtloop = false;
                        int amountleft = 1;

                        while (!dealtloop)
                        { 
                         if (amountleft < 52)
                            {
                                Console.WriteLine("would you like to deal a card");
                                string dealanother = Console.ReadLine();
                                if (dealanother == "yes" || dealanother == "Yes")
                                {
                                    Card returns = Pack.deal();
                                    var value = returns.Value.ToString();
                                    var suits = returns.Suit.ToString();
                                    Console.WriteLine($"your suit is {suits[0]} your value is {value}  ");
                                    amountleft++;
                                }
                                else if (dealanother == "no" || dealanother == "No")
                                {
                                    dealtloop = true;
                                }
                                else
                                {
                                    Console.WriteLine("the option ypu picked is not valid please choose again");
                                    dealtloop = true;
                                }
                                
                            }
                            else
                            {
                                Console.WriteLine("All cards have been dealt");
                                dealtloop = true;
                            }
                        }

                    }
                    else if (userinp2 == 2)
                    {
                        Console.WriteLine("\n");
                        Console.WriteLine("Please enter an amount of cards you would liked to be dealed");
                        int amountofcardealt = int.Parse(Console.ReadLine());
                        Pack.dealCard(amountofcardealt);
                    }
                    else if (userinp2 == 3)
                    {
                        stopdealing = true;
                        Console.WriteLine("\n");
                    }
                    else
                    {
                        Console.WriteLine("The option you picked isnt avaliable");
                    }
                }

            }
        }
    }
}


