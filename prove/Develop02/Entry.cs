
public class Entry
{
    
    public static List<string> NewEntry(string randomPrompt, List<string> currentJournalEntries)
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


}

