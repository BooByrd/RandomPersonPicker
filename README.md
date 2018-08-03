# randomPersonGenerator
This program was wrote to randomly pick employees for drug tests and write the data to a text file for record keeping. This program/project was created because my mom asked me I could write something to help her at work.

Anyone and every one is free to use program. I only ask that I be given credit if used by anyone else. There are no copyrights or anything attached to this program/project.

All of the files this program is going to use for reading/writing are on the desktop.

	This program uses rng(random number generator) to pick numbers between 1 and the total number of employees in the “Employee List” file. It won’t pick duplicate numbers. It uses/looks for a text file called “Employee List” on the desktop. The program won’t run without it. The random number(s) chosen are then used to find said employee at row position #2.

	The data is written to a text file on the desktop called “Drug Test”. This program searches your desktop to see if there is a text file named “Drug Test”. If there isn’t one, one will be created on the desktop. This is where all of the data will be written to.

	This program will also write the username of whoever is logged in on the computer running the program, along with the date and time. Example is below.

Output Example Below:
(username)   (current date and time when program was ran)
(Employee name): 	7     This number is the row position of the employee in “Employee List” file in case it needs to be checked.
 
boo   8/2/2018 1:10 PM
Bob: 	5
Joe: 	2
Bill: 	8
Fred:	10
