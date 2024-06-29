// Exceeding Requirements:
// 1. Daily Streak: I added a streak counter that checks for how many days in a row you've been here.
// 2. Achievements: Unlockable milestones that provide bonus points, easily the most complex part of this program.
// 3. Inspirational Quotes: I got some quotes from church leaders to display after completing a task.
// 4. Other Aesthetic and Logical Modifications: I'm pretty proud of all the other minor improvements I made, too.

class Program
{
    static QuestManager questManager = new QuestManager();
    static QuoteManager quoteManager = new QuoteManager();

    static void Main(string[] args)
    {
        bool quit = false;
        while (!quit)
        {
            Console.Clear();
            DisplayMenu();
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    CreateNewGoal();
                    break;
                case "2":
                    RecordEvent();
                    break;
                case "3":
                    questManager.DisplayGoals();
                    break;
                case "4":
                    questManager.DisplayScore();
                    break;
                case "5":
                    questManager.DisplayAchievements();
                    break;
                case "6":
                    SaveProgress();
                    break;
                case "7":
                    LoadProgress();
                    break;
                case "8":
                    quit = true;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
            Console.WriteLine("\nPress enter to continue.");
            Console.Read();
        }
    }

    static void DisplayMenu()
    {
        Console.WriteLine("\n--- Eternal Quest ---");
        Console.WriteLine("1. Create New Goal");
        Console.WriteLine("2. Record Event");
        Console.WriteLine("3. Display Goals");
        Console.WriteLine("4. Display Score and Streak");
        Console.WriteLine("5. Display Achievements");
        Console.WriteLine("6. Save Progress");
        Console.WriteLine("7. Load Progress");
        Console.WriteLine("8. Quit");
        Console.Write("Enter your choice: ");
    }


    static void CreateNewGoal()
    {
        Goal newGoal;
        try{
            Console.WriteLine("\nCreate a new goal");
            Console.WriteLine("1. Simple Goal");
            Console.WriteLine("2. Eternal Goal");
            Console.WriteLine("3. Checklist Goal");
            Console.Write("Select the type of goal: ");
            string type = Console.ReadLine();

            Console.Write("Enter the name of the goal: ");
            string name = Console.ReadLine();

            Console.Write("Enter the point value for this goal: ");
            int value = int.Parse(Console.ReadLine());

            

            switch (type)
            {
                case "1":
                    newGoal = new SimpleGoal(name, value);
                    break;
                case "2":
                    newGoal = new EternalGoal(name, value);
                    break;
                case "3":              
                    Console.Write("Enter the number of times this goal needs to be accomplished: ");
                    int targetTimes = int.Parse(Console.ReadLine());
                    Console.Write("Enter the bonus value for completing the goal: ");
                    int bonusValue = int.Parse(Console.ReadLine());
                    newGoal = new ChecklistGoal(name, value, targetTimes, bonusValue);
                    break;
                default:
                    Console.WriteLine("Invalid goal type. Goal not created.");
                    return;
            }
        }
        catch(FormatException){
            Console.WriteLine("Please only use integers.");
            return;
        }

        questManager.AddGoal(newGoal);
        Console.WriteLine("Goal created successfully!");
    }

    static void RecordEvent()
    {
        questManager.DisplayGoals();
        Console.Write("Enter the number of the goal you accomplished: ");
        if (int.TryParse(Console.ReadLine(), out int goalIndex))
        {
            questManager.RecordEvent(goalIndex - 1);
            Console.WriteLine(quoteManager.GetRandomQuote());
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a number.");
        }
    }

    static void SaveProgress()
    {
        Console.Write("Enter a filename to save your progress: ");
        string filename = Console.ReadLine();
        questManager.SaveProgress(filename);
        Console.WriteLine("Progress saved successfully!");
    }

    static void LoadProgress()
    {
        Console.Write("Enter the filename to load your progress: ");
        string filename = Console.ReadLine();
        questManager.LoadProgress(filename);
        Console.WriteLine("Progress loaded successfully!");
    }
}