using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903M_A01_2223
{
    class Card
    {
        //Base for the Card class.
        //Value: numbers 1 - 13
        //Suit: numbers 1 - 4
        //The 'set' methods for these properties could have some validation
        // only allows it if values is below 13 and suits is below or equal to 4
        private int _suits;
        private int _value;
        public int Value
        {
            get
            {
                return _value;
            }

            set
            {
                if (_value <= 13)
                {
                    _value = value + 1;
                }
            }
        }
        
        public int Suit
        {
            get
            {
                return _suits;
            }

            set
            {
                if (_suits <= 4)
                {
                    _suits = value + 1;
                }
            }
        
        }

       
    }
}
