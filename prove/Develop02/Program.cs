using System;
using System.Collections.Generic;
using System.IO;
"""
Write a new entry - Show the user a random prompt (from a list that you create), and save their response, the prompt, and the date as an Entry.
Display the journal - Iterate through all entries in the journal and display them to the screen.
Save the journal to a file - Prompt the user for a filename and then save the current journal (the complete list of entries) to that file location.
Load the journal from a file - Prompt the user for a filename and then load the journal (a complete list of entries) from that file. This should replace any entries currently stored the journal.
Provide a menu that allows the user choose these options
Your list of prompts must contain at least five different prompts. Make sure to add your own prompts to the list, but the following are examples to help get you started:
Who was the most interesting person I interacted with today?
What was the best part of my day?
How did I see the hand of the Lord in my life today?
What was the strongest emotion I felt today?
If I had one thing I could do over today, what would it be?
Your interface should generally follow the pattern shown in the video demo below.
"""
class Program
{
    static void Main(string[] args)
    {
        List<string> prompts = new List<string> { "What's the funniest thing you heard someone say today?", "What is the tastiest thing you ate today?", "What is the most interesting thing that has happened to you this week?", "What's your favorite song at the moment?", "What did you spend today's free time doing?"};
        List<string> currentJournalEntries = new List<string>;
    }
}

static void newEntry(){
        Random rand = new Random();
        int randomIndex = rand.Next(0, prompts.Count);
        string randomPrompt = prompts[randomIndex];
        Console.WriteLine(randomPrompt);
        entry = Console.ReadLine();
        currentJournalEntries.Add($"{randomPrompt} \n{entry}\n\n");
        
        // For once the journal logic is written
        Console.ReadLine("What file do you want to save this to? ")
        string filePath = Console.ReadLine;
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            writer.WriteLine(currentJournalEntries);
        }
}