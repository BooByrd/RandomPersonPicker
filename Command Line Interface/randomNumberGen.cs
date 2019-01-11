using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace randomPersonGenerator
{
    class randomNumberGen
    {
        string myDocPath =
                Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

        public List<int> randomNumber()
        {
            #region Local Veriables
            List<string> peopleList = new List<string>();
            try
            {
                peopleList = File.ReadAllLines(myDocPath + @"\People List.txt").ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine("\n" + e + "\n");
            }
            int randomInt = 0;
            List<int> listOfRandomInts = new List<int>();            
            int count = 1;
            int amount = 0;
            Random rndm = new Random();
            int minValue = 1;
            int maxValue = peopleList.Count + 1;
            #endregion

            #region Number of people to draw
            Console.Write("\nEnter the number of people to draw: ");

            try
            {
                amount = Convert.ToInt32(Console.ReadLine());
            }
            catch (InvalidCastException)
            {
                Console.Write("\nError! Please enter a number.\n");
            }
            catch (Exception e)
            {
                Console.Write($"\n {e} \n");
            }
            
            while (minValue > amount || maxValue - 1 < amount)
            {
                Console.WriteLine($"\nAmount picked can't be lower than {minValue} and can't be higher than {maxValue - 1}");
                Console.Write("\nEnter the number of people to draw: ");
                try
                {
                    amount = Convert.ToInt32(Console.ReadLine());
                }
                catch (InvalidCastException)
                {
                    Console.Write("\nError! Please enter a number.\n");
                }
                catch (Exception e)
                {
                    Console.Write($"\n {e} \n");
                }
            }
            #endregion

            #region Random number(s) picked between min and max values
            if (amount <= 1)
            {
                randomInt = rndm.Next(minValue, maxValue);

                listOfRandomInts.Add(randomInt);
            }

            if (amount >= 2)
            {
                randomInt = rndm.Next(minValue, maxValue);
                listOfRandomInts.Add(randomInt);
                count++;
                while (amount >= count)
                {
                    randomInt = rndm.Next(minValue, maxValue);

                    while (listOfRandomInts.Contains(randomInt))
                    {
                        randomInt = rndm.Next(minValue, maxValue);
                    }

                    listOfRandomInts.Add(randomInt);

                    count++;
                }
            }
            #endregion

            return listOfRandomInts;
        }
    }
}
