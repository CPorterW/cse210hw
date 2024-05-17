using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
public class MainMenu
{
    public static void DisplayMenu(List<string> currentJournalEntries)
    {
        string randomPrompt;
        bool continueRunning = true;
        while (continueRunning)
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Journal Program!\nA perfectly safe place to share your innermost thoughts. \nI definitely won't sell your info or keep it for my own amusement!");
            Console.WriteLine("Select an option:");
            Console.WriteLine("1 - New Entry");
            Console.WriteLine("2 - Display Entries");
            Console.WriteLine("3 - Save Entries");
            Console.WriteLine("4 - Load Entries");
            Console.WriteLine("0 - Exit");

            Console.Write("\nYour choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    randomPrompt = Prompt.GeneratePrompt();
                    currentJournalEntries = Entry.NewEntry(randomPrompt, currentJournalEntries); 
                    break;
                case "2":
                    Entry.DisplayEntry(currentJournalEntries); 
                    break;
                case "3":
                    Entry.SaveEntry(currentJournalEntries); 
                    break;
                case "4":
                    currentJournalEntries = Entry.LoadEntry(currentJournalEntries);
                    break;
                case "0":
                    if (ConfirmExit())
                    {
                        continueRunning = false;
                    }
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please select a valid option.");
                    Console.WriteLine("Press Enter to continue...");
                    Console.ReadLine();
                    break;
            }
        }
    }

    public static bool ConfirmExit()
    {
        Console.Write("Are you sure you want to exit? (Y/N): ");
        string input = Console.ReadLine().ToUpper();
        return input == "Y";
    }
}
