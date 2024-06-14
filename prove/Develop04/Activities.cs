class BreathingActivity : Activity
{
    
    public BreathingActivity() : base("Breathing Activity")
    {
        title = "Breathing Activity";
        description = "This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.";
    }

    public override void RunActivity()
    {
        Start();
        Console.Write("Enter the duration in seconds (try multiples of 16): ");
        duration = int.Parse(Console.ReadLine());
        Console.Clear();
        for (int i = 0; i < duration/16; i++)
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
    private static readonly string[] questions = { "Why was this experience meaningful to you?", "Have you ever done anything like this before?", "How did you get started?", "How did you feel when it was complete?", "What made this time different than other times when you were not as successful?", "What is your favorite thing about this experience?", "What could you learn from this experience that applies to other situations?", "What did you learn about yourself through this experience?", "How can you keep this experience in mind in the future?" };

    public ReflectionActivity() : base("Reflection Activity")
    {
        title = "Reflection Activity";
        description = "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.";
    }

    public override void RunActivity()
    {
        Start();
        Console.WriteLine("Get ready...");
        Pause(3);
        Console.Clear();
        Console.WriteLine("Type 'quit' to exit.");
        Random random = new Random();
        string prompt = prompts[random.Next(prompts.Length)];
        Console.WriteLine(prompt);
        Carat();
        string question = questions[random.Next(questions.Length)];
        while (carat) {
            Console.WriteLine(question);
            carat = Carat();
            question = questions[random.Next(questions.Length)];
        }
    }
}

class ListingActivity : Activity
{
    private static readonly string[] prompts = { "Who are people that you appreciate?", "What are personal strengths of yours?", "Who are people that you have helped this week?", "When have you felt the Holy Ghost this month?", "Who are some of your personal heroes?" };

    public ListingActivity() : base("Listing Activity")
    {
        title = "Listing Activity";
        description = "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.";
    }

    public override void RunActivity()
    {
        Start();
        int itemCount = -1;
        Random random = new Random();
        string prompt = prompts[random.Next(prompts.Length)];
        Console.Clear();
        Console.WriteLine("Type 'quit' to exit.");
        Console.WriteLine(prompt);
        Pause(5);

        while (carat)
        {
            carat = Carat();
            itemCount += 1;
        }
        
        
        Console.WriteLine("You listed " + itemCount + " items.");
    }
}