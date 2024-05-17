using System;
using System.Collections.Generic;
using System.IO;
/*
To exceed requirements, I allowed the user to see their entries as they write and 
submit them. I also cleared the terminal and provided an aesthetic line break to 
improve the user experience. The load and menu functions have some basic
conditional error handling. Also included double checking with the user whenever
I overwrite their data or close the program.
*/
class Program
{
    static void Main(string[] args)
    {
        List<string> currentJournalEntries = new List<string>();
        MainMenu.DisplayMenu(currentJournalEntries);
    }


    // static void newEntry(List<string> prompts, List<string> currentJournalEntries){
    //         Random rand = new Random();
    //         int randomIndex = rand.Next(0, prompts.Count);
    //         string randomPrompt = prompts[randomIndex];
    //         Console.WriteLine(randomPrompt);
    //         string entry = Console.ReadLine();
    //         currentJournalEntries.Add($"{randomPrompt} \n{entry}\n\n");
            
    //         // For once the journal logic is written
    //         Console.WriteLine("What file do you want to save this to? ");
    //         string filePath = Console.ReadLine();
    //         using (StreamWriter writer = new StreamWriter(filePath))
    //         {
    //             writer.WriteLine(currentJournalEntries);
    //         }
    // }
}