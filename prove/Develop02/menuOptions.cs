public class MenuOptions
{
    public static List<string> NewEntry(string randomPrompt, List<string> currentJournalEntries, List<DateTime> dateTimes)
    {
        DateTime dt = DateTime.Now;
        string dtString = $"{dt}";

        Console.Write(randomPrompt + "\n> ");
        string entry = Console.ReadLine();
        currentJournalEntries.Add($"-~-\nDate: {dtString} - Prompt: {randomPrompt}\n{entry}\n");
        Console.WriteLine($"-~-\nDate: {dtString} - Prompt: {randomPrompt}\n{entry}\n");
        Console.Write("Press enter to continue.");
        string wait = Console.ReadLine();
        
        
        return currentJournalEntries;
    }

    public static void DisplayEntry(List<string> currentJournalEntries)
    {
        foreach (string entry in currentJournalEntries){
            Console.Write(entry);
        }
        Console.Write("\nPress enter to continue.");
        string wait = Console.ReadLine();
    }

    public static void SaveEntry(List<string> currentJournalEntries)
    {
        Console.Write("What file do you want to save this to? \n> ");
        string filePath = Console.ReadLine();
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            foreach (string entry in currentJournalEntries){
                writer.Write(entry);
            }  
        }
    }

    public static List<string> LoadEntry(List<string> currentJournalEntries)
    {
        Console.Write("Are you sure you want to overwrite everything since your last save? (Y/N): ");
        string input = Console.ReadLine().ToUpper();
        if (input == "Y"){
        Console.Write("What file do you want to load from? \n> ");
        string filePath = Console.ReadLine();

        if (File.Exists(filePath))
        {
            string fileContent = File.ReadAllText(filePath);
            currentJournalEntries = [];
            // Split the file content by the separator "-~-"
            string[] entries = fileContent.Split(new string[] { "-~-"}, StringSplitOptions.RemoveEmptyEntries);

            // Add each entry with the separator to currentJournalEntries
            foreach (string entry in entries)
            {
                currentJournalEntries.Add("-~- " + entry); // Add separator as part of the entry
                Console.Write("-~- " + entry);
            }
        }
        else
        {
            Console.WriteLine("File not found.");
        }
        Console.Write("\nPress enter to continue.");
        string wait = Console.ReadLine();
        return currentJournalEntries;}
        return currentJournalEntries;
    }

    public static bool ConfirmExit()
    {
        Console.Write("Are you sure you want to exit? (Y/N): ");
        string input = Console.ReadLine().ToUpper();
        return input == "Y";
    }

    public static string GeneratePrompt(){
        List<string> prompts = new List<string> {"How did I see the hand of the Lord in my life today?", "What's the funniest thing you heard someone say today? (If you're a couch potato, feel free to use a quote from whatever media you watched)", "What is the tastiest thing you ate today?", "What is the most interesting thing that has happened to you in the past week?", "What's your favorite song this month?", "What did you spend today's free time doing?"};

        Random rand = new Random();
        int randomIndex = rand.Next(0, prompts.Count);
        string randomPrompt = prompts[randomIndex];
        return randomPrompt;
    }
}

