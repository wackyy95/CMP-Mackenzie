using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903M_A01_2223
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("welcome to the card shuffler program");
            Console.WriteLine("what type of shuffle would you like to perform?");
            Console.WriteLine("1: Fisher-Yates Shuffle");
            Console.WriteLine("2: Riffle Shuffle");
            Console.WriteLine("3: No Shuffle");
            Pack y = new Pack(4, 52);
            Console.ReadLine();
            
        }
    }
}
