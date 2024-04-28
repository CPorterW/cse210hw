using System;
using System.Globalization;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("\n\nWelcome to Grade Yourself! (Ferris Bueller's most prized invention.)");
        Console.Write("\nNow, what would you like YOUR grade to be? ");
        string gradeString = Console.ReadLine();
        float gradePercent;
        while(true){
            try{
                gradePercent = float.Parse(gradeString);
                break;
            }
            catch{
                Console.Write("\nTry again, this time give me a number. ");
                gradeString = Console.ReadLine();
            };
        }

        // nOrNoN is called in the final write statement.
        // It causes the 'a' to become 'an' if your letterGrade
        // is an A or an F. 
        string nOrNoN = "n";

        string letterGrade = "F";
        if (gradePercent >= 90){
            letterGrade = "A";
            nOrNoN = "n";
        }
        else if (gradePercent >= 80){
            letterGrade = "B";
            nOrNoN = "";
        }
        else if (gradePercent >= 70){
            letterGrade = "C";
            nOrNoN = "";
        }
        else if (gradePercent >= 60){
            letterGrade = "D";
            nOrNoN = "";
        };
        if (gradePercent >= 93 || gradePercent < 60){}
        else if (gradePercent%10>=7){
            letterGrade += "+";
        }
        else if (gradePercent%10<3){
            letterGrade += "-";
        };
        Console.WriteLine($"\nYour grade is now a{nOrNoN} {letterGrade} at {gradePercent}%!");
        if (gradePercent < 70){
            Console.WriteLine("\nYou failed, maggot!\n\n");
        }
        else{
            Console.WriteLine ("\nGood work, soldier!\n\n");
        }

    }
}