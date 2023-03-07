using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903M_A01_2223
{

    class Pack
    {
       public static List<Card> pack  = new List<Card>();
        //in the method pack, the pack of cards is created that is used throughout the code
        //it creates 13 cards for all four suits and stores them in a list called pack
        public Pack(int NumOfSuits, int NumOFCards)
        {
            //Initialise the card pack here
            
            var NumofCardpersuits = NumOFCards/NumOfSuits;
            
            
            pack.Clear();

            for (int CurrentSuit = 0; CurrentSuit < NumOfSuits; CurrentSuit++)
            {
                
                for (int CurrentCard = 0; CurrentCard < NumofCardpersuits; CurrentCard++)
                {
                    


                    pack.Add(new Card { Suit = CurrentSuit, Value = CurrentCard });

                }
            }
            
            Console.WriteLine(pack.Count);
          
           
        }

        //in the method shufflecardpack it takes the value from testing which holds the type of search the user wants to do
        //from there it either performs a Fisher-Yates Shuffle or a Riffle Shuffle on the orginal pack of cards
        public static void shuffleCardPack(int typeOfShuffle)
        {//Shuffles the pack based on the type of shuffle
            Random rnd = new Random();
            if (typeOfShuffle == 1)
            {
               
                int num = 0;
                List<Card> cardsorted = new List<Card>();
                for (int i = 0; i < 52; i++)
                {
                    num = rnd.Next(0, Pack.pack.Count);

                    cardsorted.Add(pack[num]);

                    pack.Remove(pack[num]);

                }
                pack.Clear();
                pack = cardsorted;

                
            }
         
            if(typeOfShuffle == 2)
            {
                int shuffledeck1 = 0;
                int shuffledeck2 = 0;
                int randomnum1 = 0;
                int randomnum2 = 0;
                List<Card> cards2 = new List<Card>();
                List<Card> shuffledDeck = new List<Card>();
                for (int y = 0; y < 26; y++)
                {
                    cards2.Add(pack[0]);
                    pack.Remove(pack[0]);
                }
                while (shuffledeck1 < 26 || shuffledeck2 < 26)
                {
                    randomnum1 = rnd.Next(0, 3);
                    randomnum2 = rnd.Next(0, 3);

                    if (shuffledeck1 < 26)
                    {
                        for (int z = 0; z < randomnum1; z++)
                        {
                            if (shuffledeck1 + randomnum1 <= 26)
                            {
                                shuffledDeck.Add(pack[0]);
                                pack.Remove(pack[0]);
                                shuffledeck1++;
                            }
                        }
                    }
                    if (shuffledeck2 < 26)
                    {
                        for (int p = 0; p < randomnum2; p++)
                        {
                            if (shuffledeck2 + randomnum2 <= 26)
                            {
                                shuffledDeck.Add(cards2[0]);
                                cards2.Remove(cards2[0]);
                                shuffledeck2++;
                            }


                        }
                    }
                }
                pack.Clear();
                pack = shuffledDeck;
            }
         }

        //the method deal allows the user to deal one card at a time
        // it allows the freshly shuffled cards to be dealt and stops when the user asks or when it runs out fo cards
        public static Card deal()
        {
            //Deals one card
            Console.WriteLine($"your suit is {pack[0].Suit} your value is {pack[0].Value}  ");
            pack.Remove(pack[0]);

            bool endloop = false;
            int amountleft = 1;
            
                while (!endloop)
                {
                    if (amountleft < 52)
                    {
                        Console.WriteLine("would you like to deal another card");
                        string dealanother = Console.ReadLine();


                        if (dealanother == "yes" || dealanother == "Yes")
                        {
                            Console.WriteLine($"your suit is {pack[0].Suit} your value is {pack[0].Value}  ");
                            pack.Remove(pack[0]);
                            amountleft++;
                        }
                        else if (dealanother == "no" || dealanother == "No")
                        {
                            endloop = true;
                        }
                        else
                        {
                            Console.WriteLine("the option ypu picked is not valid please choose again");
                            endloop = true;
                        }
                    }
                else
                {
                    Console.WriteLine("All cards have been dealt");
                    endloop = true;
                }
            }
            
            return pack[0];
        }
        
        //the method dealcards is similar to deal but allows the user to specifiy the amount they want to deal user the input in the testing class
        //it allows the user to do multiple deals of any amount of cards and will stop when the user asks or when the cards run out
        public static List<Card> dealCard(int amount)
        {
            //Deals the number of cards specified by 'amount'
            bool endloop2 = false;
            int cardcount = 0;
            while (!endloop2)
            {
                
                if (cardcount < 52) 
                {
                    for (int dealtcards = 0; dealtcards < amount; dealtcards++)
                    {
                        Console.WriteLine($"your suit is {pack[0].Suit} your value is {pack[0].Value}  ");
                        pack.Remove(pack[0]);
                        cardcount++;
                    }
                    Console.WriteLine("would you like to deal another card");
                    string dealmore = Console.ReadLine();


                    if (dealmore == "yes" || dealmore == "Yes")
                    {
                        Console.WriteLine("how many more cards would you like to deal");
                        amount = int.Parse(Console.ReadLine());
                    }
                    else if (dealmore == "no" || dealmore == "No")
                    {
                        endloop2 = true;
                    }
                    else
                    {
                        Console.WriteLine("the option ypu picked is not valid please choose again");
                        endloop2 = true;
                    }
                }
                else
                {
                    Console.WriteLine("All cards have been dealt");
                    endloop2 = true;
                }
                
            }
            return pack;
        }
           

    }
}
