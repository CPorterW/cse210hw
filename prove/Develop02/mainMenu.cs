using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
public class MainMenu
{
    // static void Main(string[] args)
    // {
    //     List<string> currentJournalEntries = new List<string>();
    //     List<DateTime> dateTimes = [];
    //     string randomPrompt = "";
    //     DisplayMenu(randomPrompt, currentJournalEntries, dateTimes);
    // }

    public static void DisplayMenu(List<string> currentJournalEntries, List<DateTime> dateTimes)
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
                    randomPrompt = MenuOptions.GeneratePrompt();
                    currentJournalEntries = MenuOptions.NewEntry(randomPrompt, currentJournalEntries, dateTimes); 
                    break;
                case "2":
                    MenuOptions.DisplayEntry(currentJournalEntries); 
                    break;
                case "3":
                    MenuOptions.SaveEntry(currentJournalEntries); 
                    break;
                case "4":
                    currentJournalEntries = MenuOptions.LoadEntry(currentJournalEntries);
                    break;
                case "0":
                    if (MenuOptions.ConfirmExit())
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
}
