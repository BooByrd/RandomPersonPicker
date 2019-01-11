using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows;
using System.Windows.Threading;
using System.Threading;

namespace Cts_Test_Gui__2_
{
    class writeDataToFile
    {
        List<string> peopleList = new List<string>();
        List<string> choosenPeople = new List<string>();

        MainWindow mw = new MainWindow();

        string outputFilePath;
        string outputFileName;
        string inputFilePath;
        string inputFileName;
        bool write;
        
        public List<string> fileCheck(List<string> listOfChoosen, string inputFilePath, string inputFileName,
            string outputFilePath, string outputFileName, bool write)
        {
            this.outputFilePath = outputFilePath;
            this.outputFileName = outputFileName;
            this.inputFilePath = inputFilePath;
            this.inputFileName = inputFileName;
            this.write = write;

            if (write == true)
            {
                if (!File.Exists(outputFilePath + outputFileName))
                {
                    writeToFIle(listOfChoosen);
                    return null;
                }
                else if (File.Exists(outputFilePath + outputFileName))
                {
                    appendToFile(listOfChoosen);
                    return null;
                }
                else
                {
                    MessageBox.Show("Something has gone wrong in the program", "Error");
                    return null;
                }
            }
            else
            {
                return peopleList;
            }
        }

        void writeToFIle(List<string> choosen)
        {
            try
            {
                int count = 0;

                using (StreamWriter sw = new StreamWriter(outputFilePath + outputFileName))
                {
                    sw.WriteLine($"{Environment.UserName}   {DateTime.Now.ToString("g")}");
                    foreach (string key in choosen)
                    {
                        sw.WriteLine($"\n{key}");
                        count++;
                    }
                    sw.WriteLine("\n");

                    sw.Close();
                }

                if (count == choosen.Count())
                {
                    MessageBox.Show("Data wrote to file successfully!", "Successful");
                }
                else
                {
                    MessageBox.Show("Data didn't write to file!", "Error");
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), "Error");
            }
        }

        void appendToFile(List<string> choosen)
        {
            try
            {
                int count = 0;

                using (StreamWriter sw = File.AppendText(outputFilePath + outputFileName))
                {
                    sw.WriteLine($"{Environment.UserName}   {DateTime.Now.ToString("g")}");
                    foreach (string key in choosen)
                    {
                        sw.WriteLine($"\n{key}");
                        count++;
                    }
                    sw.WriteLine("\n");

                    sw.Close();
                }

                if (count == choosen.Count())
                {
                    MessageBox.Show("Data wrote to file successfully!", "Successful");
                }
                else
                {
                    MessageBox.Show("Data didn't write to file!", "Error");
                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), "Error");
            }
        }
    }
}
