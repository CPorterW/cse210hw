
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("\n\nWelcome to the Scripture Memorization Program!");
        string input;
        do
        {
            Console.WriteLine("Enter the scripture you want to memorize (or type 'quit' to exit):");
            input = Console.ReadLine();

            if (input.ToLower() != "quit")
            {
                ScriptureStorer scriptureStorer = new ScriptureStorer(input);
                WordRemover wordRemover = new WordRemover(scriptureStorer.GetScripture());

                Console.WriteLine("Press Enter to start memorizing...");
                Console.ReadLine();

                while (!wordRemover.IsCompletelyRemoved())
                {
                    Console.Clear();
                    Console.WriteLine(wordRemover.GetCurrentScripture());
                    wordRemover.RemoveRandomWord();
                    Console.WriteLine("Press Enter to continue or type 'quit' to exit.");
                    if (Console.ReadLine().ToLower() == "quit")
                        break;
                }

                if (wordRemover.IsCompletelyRemoved())
                {
                    Console.WriteLine("Congratulations! You've memorized the scripture!\n");
                }
            }

        } while (input.ToLower() != "quit");

        Console.WriteLine("Goodbye!");
    }
}

