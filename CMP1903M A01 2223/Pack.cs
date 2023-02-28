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
        List<Card> pack;

        public Pack(int NumOfSuits, int NumOFCards)
        {
            //Initialise the card pack here
            //Card X = new Card();
            // X.Value = x;
            //X.Suit = NumOfSuits;
            var NumofCardpersuits = NumOFCards/NumOfSuits;

            var pack = new List<Card>();
            for (int CurrentSuit = 0; CurrentSuit < NumOfSuits; CurrentSuit++)
            {
                
                for (int CurrentCard = 0; CurrentCard < NumofCardpersuits; CurrentCard++)
                {
                    


                    pack.Add(new Card { Suit = CurrentSuit, Value = CurrentCard });

                }
            }
            Console.WriteLine(pack.Count);
            
        }


        //public static bool shuffleCardPack(int typeOfShuffle)
        //{
         //Shuffles the pack based on the type of shuffle
//
      //  }
        //public static Card deal()
        //{
        //Deals one card

        // }
        //public static List<Card> dealCard(int amount)
        //{
        //Deals the number of cards specified by 'amount'
        // }

    }
}
