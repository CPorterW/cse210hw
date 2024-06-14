abstract class Activity
{
    protected int duration;
    protected string description;
    protected string startingMessage;
    protected string endingMessage;
    protected string title;
    protected bool carat = true;

    public Activity(string description)
    {
        this.description = description;
        startingMessage = "Welcome to the ";
        endingMessage = "Well done! You have completed the ";
    }

    protected void Start()
    {
        Console.WriteLine(startingMessage + title + ". " + description);
        Console.Clear();
    }

    protected bool Carat() {
            Console.Write("> ");
            string item = Console.ReadLine();

            if (item.Trim().ToLower() == "quit")
            {
                return false;
            }
            return true;
    }

    public void End()
    {
        Console.WriteLine(endingMessage + title + " activity!");
        Pause(3);
    }

    public abstract void RunActivity();

    protected void Pause(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write("/" + i);
            Thread.Sleep(1000);
            Console.Write("\b\b\b");
        }
    }
}