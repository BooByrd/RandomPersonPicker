using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows;

namespace Cts_Test_Gui__2_
{
    class personPicker
    {
        public List<string> randomPerson(string inputFilePath, string inputFileName, int inputAmountToDraw)
        {
            #region Local Veriables

            MainWindow mw = new MainWindow();

            List<int> listOfRandomInts = new List<int>();
            List<string> listOfChoosenPeople = new List<string>();
            List<string> listInputPeople = new List<string>();

            int minValue = 1;
            int maxValue;

            try
            {
                maxValue = File.ReadLines(inputFilePath + inputFileName).Count() + 1;
                listInputPeople = File.ReadAllLines(inputFilePath + inputFileName).ToList();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), "Error");
                
                return listOfChoosenPeople = null;
            }

            int randomInt = 0;
            int count = 1;
            Random rndm = new Random();


            #endregion

            #region Random number(s) picked between min and max values
            if (inputAmountToDraw <= 1)
            {
                randomInt = rndm.Next(minValue, maxValue);

                listOfRandomInts.Add(randomInt);
            }

            if (inputAmountToDraw >= 2)
            {
                randomInt = rndm.Next(minValue, maxValue);
                listOfRandomInts.Add(randomInt);
                count++;
                while (inputAmountToDraw >= count)
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

            #region Add people to a List based on random numbers picked
            foreach (int key in listOfRandomInts)
            {
                listOfChoosenPeople.Add($"\n{listInputPeople.ElementAt(key - 1)}: \t{key}");
            }
            #endregion

            return listOfChoosenPeople;
        }
    }
}
