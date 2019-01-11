# README for GUI
This program was wrote to randomly pick employees for drug tests and write the data to a text file for record keeping. This program/project was created because my mom asked me I could write something to help her at work.

Anyone and everyone is free to use program. I only ask that I be given credit if used by anyone else. There are no copyrights or anything attached to this program/project.

In this folder, you will find the .exe and all of the code for the RandomPersonPicker program. This program uses WPF(front-end) and C#(back-end).

If you only want the program itself, download "RandomPersonPicker.exe" and read the directions below before running this program.

This program will be reading/writing from files on your computer or maybe even a cloud server (ex. OneDrive).

*Input File*  
Click the "Input File" button and select your text file to used for input. Each name should be on their own row using the return/enter key and not one name right after the next.

*Check Box*  
This program has a check box under the "Input File" button. By default, it's unchecked so it won't write any generated data to a text file. If the check box is unchecked, you can't change any of the fields relating to an output file location or an output file name.

If the check box is checked, the generated data will be wrote to a text file. By default, the output file location will be in the same spot as your "Input File" location. The default file output name will start your text file with "People Picked_" + the name of the input file. You can change the output file name and the output file path to whatever you want.

*Output File Name*  
The output file name will not allow you to exceed a 239 character limit. You also won't be allowed to use certain charachers that are considered illegal. You will see a popup message showing you what illegal character was used.

*Output File Path*  
Click the "Output File Path" button and select where you want the output file to be put. You can't type out the output file location in the box to the right. If the output file location exceeds the 239 character limit, the output file location will default to your desktop.

*Number of people to draw*  
