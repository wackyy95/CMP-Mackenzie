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
            var NumofCardpersuits = NumOFCards/NumOfSuits;
            pack.Clear();
            for (int CurrentSuit = 0; CurrentSuit < NumOfSuits; CurrentSuit++)
            {

                for (int CurrentCard = 0; CurrentCard < NumofCardpersuits; CurrentCard++)
                {
                    pack.Add(new Card { Suit = CurrentSuit, Value = CurrentCard });
                }
            }  
        }

        //in the method shufflecardpack it takes the value from testing which holds the type of search the user wants to do
        //from there it either performs a Fisher-Yates Shuffle or a Riffle Shuffle on the orginal pack of cards
        public static void shuffleCardPack(int typeOfShuffle)
        {
            Random rnd = new Random();
            if (typeOfShuffle == 1)
            {
               
                int rannum = 0;
                List<Card> cardsorted = new List<Card>();
                for (int x = 0; x < 52; x++)
                {
                    rannum = rnd.Next(0, Pack.pack.Count);
                    cardsorted.Add(pack[rannum]);
                    pack.Remove(pack[rannum]);
                }
                pack.Clear();
                pack = cardsorted;    
            }

            if (typeOfShuffle == 2)
            {
                int fullshuffledeck1 = 0;
                int fullshuffledeck2 = 0;
                int randomnum1 = 0;
                int randomnum2 = 0;
                List<Card> pack2 = new List<Card>();
                List<Card> shuffledDeck = new List<Card>();
                for (int splitdeck = 0; splitdeck < 26; splitdeck++)
                {
                    pack2.Add(pack[0]);
                    pack.Remove(pack[0]);
                }
                while (fullshuffledeck1 < 26 || fullshuffledeck2 < 26)
                {
                    randomnum1 = rnd.Next(0, 3);
                    randomnum2 = rnd.Next(0, 3);

                    if (fullshuffledeck1 < 26)
                    {
                        for (int cardcount = 0; cardcount < randomnum1; cardcount++)
                        {
                            if (fullshuffledeck1 + randomnum1 <= 26)
                            {
                                shuffledDeck.Add(pack[0]);
                                pack.Remove(pack[0]);
                                fullshuffledeck1++;
                            }
                        }
                    }
                    if (fullshuffledeck2 < 26)
                    {
                        for (int deckcount = 0; deckcount < randomnum2; deckcount++)
                        {
                            if (fullshuffledeck2 + randomnum2 <= 26)
                            {
                                shuffledDeck.Add(pack2[0]);
                                pack2.Remove(pack2[0]);
                                fullshuffledeck2++;
                            }
                        }
                    }
                }
                pack.Clear();
                pack = shuffledDeck;
            }

                if (typeOfShuffle == 3)
                {
                    Console.WriteLine("no shuffle was performed");
                Console.WriteLine("the cards are in the right order");
                }
              
            
         }

        //the method deal allows the user to deal one card at a time
        // it allows the freshly shuffled cards by sending the value of the first card back to testing to be printed
        public static Card deal()
        {
            var frontofpack = pack.Count() - 1;
            Card firstcard = pack[frontofpack];
            pack.Remove(firstcard);
            return firstcard;
        }
        
        //the method dealcards is similar to deal but allows the user to specifiy the amount they want to deal user the input in the testing class
        //it allows the user to do multiple deals of any amount of cards and will stop when the user asks or when the cards run out
        public static List<Card> dealCard(int amount)
        {
            bool dealtloop = false;
            int cardcount = 0;
            while (!dealtloop)
            {
                if (amount < 53)
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
                else
                {
                    Console.WriteLine("the number you entered was greater then the amount of cards, please try again");
                    amount = int.Parse(Console.ReadLine());
                }
            }


            return pack;

        }
        

    }
}
