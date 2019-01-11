using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
//using System.Windows.Shapes;
using Microsoft.Win32;
using System.IO;

namespace Cts_Test_Gui__2_
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Local veriables
        private string _inputFilePath;

        public string inputFilePath
        {
            get { return _inputFilePath; }
            set { _inputFilePath = value; }
        }

        private string _inputFileName;

        public string inputFileName
        {
            get { return _inputFileName; }
            set { _inputFileName = value; }
        }

        private int _inputAmountToDraw;

        public int inputAmountToDraw
        {
            get { return _inputAmountToDraw; }
            set { _inputAmountToDraw = value; }
        }

        private string _outputFilePath;

        public string outputFilePath
        {
            get { return _outputFilePath; }
            set { _outputFilePath = value; }
        }

        private string _outputFileName;

        public string outputFileName
        {
            get { return _outputFileName; }
            set { _outputFileName = value; }
        }

        private string _outputFileLocation;

        public string outputFileLocation
        {
            get { return _outputFileLocation; }
            set { _outputFileLocation = value; }
        }

        private string _defaultFilePath;

        public string defaultFilePath
        {
            get { return _defaultFilePath; }
            set { _defaultFilePath = value; }
        }

        private string _defaultFileName;

        public string defaultFileName
        {
            get { return _defaultFileName; }
            set { _defaultFileName = value; }
        }

        int maxInputValue;

        public bool writeData;
        #endregion

        public MainWindow()
        {
            InitializeComponent();
        }
        
        private void buttonSelectFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            if (!String.IsNullOrEmpty(textboxOutputFileLocation.Text))
            {
                buttonReset_Click(null, e);
            }

            if (ofd.ShowDialog() == true)
            {
                inputFilePath = Path.GetDirectoryName(ofd.FileName);
                defaultFilePath = inputFilePath;

                defaultFileName = @"\People Picked_" + Path.GetFileName(ofd.FileName);
                inputFileName = "\\" + Path.GetFileName(ofd.FileName);

                textboxInputFileLocation.Text = ofd.FileName;

                textboxOutputFileLocation.Text = defaultFilePath + defaultFileName;

                checkboxWriteDataToFile.IsEnabled = true;
                
                textboxOutputFileLocation.Visibility = Visibility.Visible;
                
                textboxInputNumberToDraw.IsReadOnly = false;
                buttonGenerateData.IsEnabled = true;

                labelInputFileAlert.Visibility = Visibility.Hidden;
                labelOutputFileAlert.Visibility = Visibility.Hidden;
            }
            else
            {
                textboxInputFileLocation.Clear();
                
                checkboxWriteDataToFile.IsChecked = false;
                checkboxWriteDataToFile.IsEnabled = false;

                textboxOutputFileName.IsReadOnly = true;
                textboxOutputFileName.Clear();

                buttonOutputFile.IsEnabled = false;
                textboxOutputFileLocation.Clear();

                textboxInputNumberToDraw.Clear();
                textboxInputNumberToDraw.IsReadOnly = true;

                buttonGenerateData.IsEnabled = false;
                labelInputFileAlert.Visibility = Visibility.Visible;
            }

            checkAndAssignOutputPathAndNameVeriables();

            if (textboxInputFileLocation.Text.Length >= 240)
            {
                MessageBox.Show("Input file location exceeds the 239 character limit! Please move the file to a different location like your desktop.", "Error");
                buttonReset_Click(null, e);
            }
            else if (textboxOutputFileLocation.Text.Length >= 240)
            {
                outputFilePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                checkAndAssignOutputPathAndNameVeriables();
                MessageBox.Show("Output file location exceeds the 239 character limit! The file will be created on your desktop.", "Error");
            }

            if (!String.IsNullOrWhiteSpace(inputFilePath) && !String.IsNullOrWhiteSpace(inputFileName))
            {
                try
                {
                    maxInputValue = File.ReadLines(inputFilePath + inputFileName).Count();
                }
                catch { }
            }
        }

        // https://codereview.stackexchange.com/questions/120002/windows-filepath-and-filename-validation?newreg=fa544283ead7402f9355fd0ff7611ae4
        // https://stackoverflow.com/questions/62771/how-do-i-check-if-a-given-string-is-a-legal-valid-file-name-under-windows

        // Regex link
        // https://www.google.com/search?rlz=1C1GCEA_enUS822US822&ei=0OEXXNSrKs_QsAWo2pXgBA&q=regex+c%23&oq=regex+c%23&gs_l=psy-ab.3..0i7i30j0i67j0i7i30l8.7194309.7195010..7196314...0.0..0.83.349.5......0....1..gws-wiz.......0i71.jaqkbfQFBuY
        private void textboxOutputFileName_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(textboxOutputFileName.Text))
            {
                outputFileName = textboxOutputFileName.Text;

                char invalidChar = '\u0061';

                char[] invalidNameChars = Path.GetInvalidFileNameChars();

                try
                {
                    int count = 0;

                    foreach (char invalid in invalidNameChars)
                    {
                        if (!outputFileName.Contains(invalid))
                        {
                            count++;
                            if (count == invalidNameChars.Count())
                            {
                                outputFileName = "\\" + outputFileName + ".txt";
                            }
                        }
                        else
                        {
                            invalidChar = invalid;
                            textboxOutputFileName.Text = "";
                            outputFileName = null;
                        }
                    }
                }
                catch (ArgumentNullException ane)
                {
                    MessageBox.Show($"Invalid character {invalidChar} used", "Error");
                }

                labelOutputFileAlert.Visibility = Visibility.Hidden;
            }
            else
            {
                outputFileName = null;
            }

            checkAndAssignOutputPathAndNameVeriables();
        }

        private void buttonOutputFile_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.FolderBrowserDialog fbd = new System.Windows.Forms.FolderBrowserDialog();

            fbd.RootFolder = Environment.SpecialFolder.Desktop;

            if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                outputFilePath = fbd.SelectedPath;
                outputFileLocation = textboxOutputFileLocation.Text;
                labelOutputFileAlert.Visibility = Visibility.Hidden;
            }

            checkAndAssignOutputPathAndNameVeriables();
        }


        private void textboxInputNumberToDraw_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Int32.TryParse(textboxInputNumberToDraw.Text, out int number))
            {
                if (number > maxInputValue || number < 1)
                {
                    labelInputNumberAlert.Content = "Input has to be equal to or greater than 1 and less than " + (maxInputValue) + "!";
                    buttonGenerateData.IsEnabled = false;
                    labelInputNumberAlert.Visibility = Visibility.Visible;
                }

                if (number <= maxInputValue && number >= 1)
                {
                    inputAmountToDraw = number;
                    buttonGenerateData.IsEnabled = true;
                    labelInputNumberAlert.Visibility = Visibility.Hidden;
                }
            }
            else
            {
                labelInputNumberAlert.Content = "Input can only be a whole number!";
                buttonGenerateData.IsEnabled = false;
                labelInputNumberAlert.Visibility = Visibility.Visible;
            }
        }

        
        private void buttonGenerateData_Click(object sender, RoutedEventArgs e)
        {
            personPicker pP = new personPicker();
            List<string> listOfPeople = pP.randomPerson(inputFilePath, inputFileName, inputAmountToDraw);

            writeDataToFile wDTF = new writeDataToFile();
            List<string> listOfChoosenPeople = wDTF.fileCheck(listOfPeople, inputFilePath, inputFileName, outputFilePath, outputFileName, writeData);

            try
            {
                foreach (string key in listOfPeople)
                {
                    textblockOutputDataForUserView.Text += key;
                }

                scrollviewerForOutputData.Visibility = Visibility.Visible;
            }
            catch (Exception showDataError)
            {
                MessageBox.Show(showDataError.ToString(), "Error");
            }
        }


        private void buttonReset_Click(object sender, RoutedEventArgs e)
        {
            inputFilePath = null;
            inputFileName = null;
            inputAmountToDraw = 1;
            defaultFilePath = null;
            defaultFileName = null;
            outputFilePath = null;
            outputFileName = null;
            maxInputValue = 0;

            labelInputFileAlert.Visibility = Visibility.Hidden;
            textboxInputFileLocation.Clear();

            checkboxWriteDataToFile.IsChecked = false;
            checkboxWriteDataToFile.IsEnabled = false;

            textboxOutputFileName.IsReadOnly = true;
            textboxOutputFileName.Clear();

            buttonOutputFile.IsEnabled = false;
            labelOutputFileAlert.Visibility = Visibility.Hidden;
            textboxOutputFileLocation.Clear();

            textboxInputNumberToDraw.IsReadOnly = true;
            textboxInputNumberToDraw.Clear();
            labelInputNumberAlert.Visibility = Visibility.Hidden;

            buttonGenerateData.IsEnabled = false;
            scrollviewerForOutputData.Visibility = Visibility.Hidden;
            textblockOutputDataForUserView.Text = "";
        }
        

        private void CheckboxWriteDataToFile_Checked(object sender, RoutedEventArgs e)
        {
            writeData = true;
            textboxOutputFileName.IsReadOnly = false;
            buttonOutputFile.IsEnabled = true;
        }

        private void CheckboxWriteDataToFile_Unchecked(object sender, RoutedEventArgs e)
        {
            writeData = false;
            textboxOutputFileName.IsReadOnly = true;
            buttonOutputFile.IsEnabled = false;
        }


        void checkAndAssignOutputPathAndNameVeriables()
        {
            if (!String.IsNullOrWhiteSpace(outputFilePath) && !String.IsNullOrWhiteSpace(outputFileName))
            {
                textboxOutputFileLocation.Text = outputFilePath + outputFileName;

            }
            else if (!String.IsNullOrWhiteSpace(outputFilePath) && String.IsNullOrWhiteSpace(outputFileName))
            {
                outputFileName = defaultFileName;
                textboxOutputFileLocation.Text = outputFilePath + outputFileName;

                labelOutputFileAlert.Content = "Default file name prefix \"People Picked_\" will be used!";
                labelOutputFileAlert.Visibility = Visibility.Visible;
            }
            else if (String.IsNullOrWhiteSpace(outputFilePath) && !String.IsNullOrWhiteSpace(outputFileName))
            {
                outputFilePath = defaultFilePath;
                textboxOutputFileLocation.Text = outputFilePath + outputFileName;

                labelOutputFileAlert.Content = "Default output location will be used!";
                labelOutputFileAlert.Visibility = Visibility.Visible;
            }
            else
            {
                outputFilePath = defaultFilePath;
                outputFileName = defaultFileName;
                textboxOutputFileLocation.Text = outputFilePath + outputFileName;

                labelOutputFileAlert.Content = "Default output location and file name prefix \"People Picked_\" will be used!";
                labelOutputFileAlert.Visibility = Visibility.Visible;
            }
        }


    }
}
