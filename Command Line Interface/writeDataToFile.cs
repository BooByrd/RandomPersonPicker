using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace randomPersonGenerator
{
    class writeDataToFile
    {
        List<string> peopleList = new List<string>();
        string myDocPath =
                Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

        // File check
        public void fileCheck(List<int> randomInts)
        {
            if (File.Exists(myDocPath + @"\Choosen People.txt") == false)
            {
                peopleList = readPeopleList();
                writeToFIle(randomInts);
            }
            else if (File.Exists(myDocPath + @"\Choosen People.txt") == true)
            {
                peopleList = readPeopleList();
                appendToFile(randomInts);
            }
            else
            {
                Console.WriteLine("Something has gone wrong in the program");
            }
        }

        public List<string> readPeopleList()
        {
            List<string> peopleList = new List<string>();
            try
            {
                peopleList = File.ReadAllLines(myDocPath + @"\People List.txt").ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine("\n" + e + "\n");
            }

            return peopleList;
        }

        void writeToFIle(List<int> randomIntList)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(myDocPath + @"\Choosen People.txt"))
                {
                    sw.WriteLine($"{Environment.UserName}   {DateTime.Now.ToString("g")}");
                    foreach (int key in randomIntList)
                    {
                        sw.WriteLine($"\n{peopleList.ElementAt(key - 1)}: \t{key}");
                        Console.WriteLine($"\n{peopleList.ElementAt(key - 1)}: \t{key}");
                    }
                    sw.WriteLine("\n");

                    sw.Close();
                }
            }
            catch (Exception e)
            { Console.WriteLine("\n" + e + "\n"); }
        }

        void appendToFile(List<int> randomIntList)
        {
            try
            {
                using (StreamWriter sw = File.AppendText(myDocPath + @"\Choosen People.txt"))
                {
                    sw.WriteLine($"{Environment.UserName}   {DateTime.Now.ToString("g")}");
                    foreach (int key in randomIntList)
                    {
                        sw.WriteLine($"\n{peopleList.ElementAt(key - 1).ToString()}: \t{key}");
                        Console.WriteLine($"\n{peopleList.ElementAt(key - 1)}: \t{key}");
                    }
                    sw.WriteLine("\n");

                    sw.Close();
                }
            }
            catch (Exception e)
            { Console.WriteLine("\n" + e + "\n"); }
        }
    }
}

