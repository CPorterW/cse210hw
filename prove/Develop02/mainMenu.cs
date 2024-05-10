using System;

public class MainMenu
{
    public static void Main(string[] args)
    {
        DisplayMenu();
    }

    private static void DisplayMenu()
    {
        bool continueRunning = true;
        while (continueRunning)
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Journal Program!\n");
            Console.WriteLine("Please select an option:");
            Console.WriteLine("1 - New Entry");
            Console.WriteLine("2 - Display Entry");
            Console.WriteLine("3 - Save Entry");
            Console.WriteLine("4 - Load Entry");
            Console.WriteLine("0 - Exit");

            Console.Write("\nYour choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    NewEntry(); 
                    break;
                case "2":
                    DisplayEntry(); 
                    break;
                case "3":
                    SaveEntry(); 
                    break;
                case "4":
                    LoadEntry();
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

    public static void NewEntry()
    {
        Console.WriteLine("Creating a new entry...");
        // Implement your logic here
    }

    public static void DisplayEntry()
    {
        Console.WriteLine("Displaying an entry...");
        // Implement your logic here
    }

    public static void SaveEntry()
    {
        Console.WriteLine("Saving an entry...");
        // Implement your logic here
    }

    public static void LoadEntry()
    {
        Console.WriteLine("Loading an entry...");
        // Implement your logic here
    }

    public static bool ConfirmExit()
    {
        Console.Write("Are you sure you want to exit? (Y/N): ");
        string input = Console.ReadLine().ToUpper();
        return input == "Y";
    }
}

