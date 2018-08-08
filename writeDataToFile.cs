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
        List<string> employeeList = new List<string>();
        string myDocPath =
                Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

        // File check
        public void fileCheck(List<int> randomInts)
        {
            if (File.Exists(myDocPath + @"\Drug Test.txt") == false)
            {
                employeeList = readEmployeeList();
                writeToFIle(randomInts);
            }
            else if (File.Exists(myDocPath + @"\Drug Test.txt") == true)
            {
                employeeList = readEmployeeList();
                appendToFile(randomInts);
            }
            else
            {
                Console.WriteLine("Something has gone wrong in the program");
            }
        }

        public List<string> readEmployeeList()
        {
            List<string> employeeList = new List<string>();
            try
            {
                employeeList = File.ReadAllLines(myDocPath + @"\Employee List.txt").ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine("\n" + e + "\n");
            }

            return employeeList;
        }

        void writeToFIle(List<int> randomIntList)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(myDocPath + @"\Drug Test.txt"))
                {
                    sw.WriteLine($"{Environment.UserName}   {DateTime.Now.ToString("g")}");
                    foreach (int key in randomIntList)
                    {
                        sw.WriteLine($"\n{employeeList.ElementAt(key - 1)}: \t{key}");
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
                using (StreamWriter sw = File.AppendText(myDocPath + @"\Drug Test.txt"))
                {
                    sw.WriteLine($"{Environment.UserName}   {DateTime.Now.ToString("g")}");
                    foreach (int key in randomIntList)
                    {
                        sw.WriteLine($"\n{employeeList.ElementAt(key - 1).ToString()}: \t{key}");
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

