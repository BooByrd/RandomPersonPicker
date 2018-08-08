using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace randomPersonGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            randomNumberGen rNG = new randomNumberGen();
            List<int> listOfInts = rNG.randomNumber();

            writeDataToFile wDTF = new writeDataToFile();
            wDTF.fileCheck(listOfInts);


            Console.Write("\nPress any key to exit program.");
            Console.ReadKey();
        }
    }
}
