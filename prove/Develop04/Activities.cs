class BreathingActivity : Activity
{
    public BreathingActivity() : base("Breathing Activity")
    {
        _description = "This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.";
    }

    public override void RunActivity()
    {
        Console.Clear();
        while (IsTimeLeft())
        {
            Console.WriteLine("Breathe in...");
            Pause(8);
            Console.WriteLine("Breathe out...");
            Pause(8);
        }
    }
}

class ReflectionActivity : Activity
{
    private static readonly string[] prompts = { "Think of a time when you stood up for someone else.", "Think of a time when you did something really difficult.", "Think of a time when you helped someone in need.", "Think of a time when you did something truly selfless." };
    private List<string> questions = new List<string>{ "Why was this experience meaningful to you?", "Have you ever done anything like this before?", "How did you get started?", "How did you feel when it was complete?", "What made this time different than other times when you were not as successful?", "What is your favorite thing about this experience?", "What could you learn from this experience that applies to other situations?", "What did you learn about yourself through this experience?", "How can you keep this experience in mind in the future?" };

    public ReflectionActivity() : base("Reflection Activity")
    {
        _title = "Reflection Activity";
        _description = "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.";
    }

    public override void RunActivity()
    {
        Console.WriteLine("Get ready...");
        Pause(3);
        Console.Clear();
        Console.WriteLine("Type 'quit' to exit.");
        Random random = new Random();
        string prompt = prompts[random.Next(prompts.Length)];
        Console.WriteLine(prompt);
        Carat();
        string question;
        while (_carat && questions.Count > 0 && IsTimeLeft()) {
            question = questions[random.Next(questions.Count)];
            Console.WriteLine(question);
            _carat = Carat();
            questions.Remove(question);
        }
    }
}

class ListingActivity : Activity
{
    private static readonly string[] prompts = { "Who are people that you appreciate?", "What are personal strengths of yours?", "Who are people that you have helped this week?", "When have you felt the Holy Ghost this month?", "Who are some of your personal heroes?" };

    public ListingActivity() : base("Listing Activity")
    {
        _title = "Listing Activity";
        _description = "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.";
    }

    public override void RunActivity()
    {
        int itemCount = 0;
        Random random = new Random();
        string prompt = prompts[random.Next(prompts.Length)];
        Console.Clear();
        Console.WriteLine("Type 'quit' to exit.");
        Console.WriteLine(prompt);
        Pause(5);

        while (_carat && IsTimeLeft())
        {
            _carat = Carat();
            itemCount = _carat ? itemCount += 1 : itemCount;
        }
        
        Console.WriteLine("You listed " + itemCount + " items.");
    }
}