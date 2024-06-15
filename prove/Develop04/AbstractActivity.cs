abstract class Activity
{
    private int _duration;
    protected string _description;
    private string _startingMessage;
    private string _endingMessage;
    protected string _title;
    protected bool _carat;
    private DateTime _endTime;

    public Activity(string _description)
    {
        this._description = _description;
        _startingMessage = "Welcome to the ";
        _endingMessage = "Well done! You have completed the ";
        _carat = true;
    }

    public bool Start()
    {
        Console.Write("How long do you want this activity to last (in seconds)? ");
        try{
            _duration = int.Parse(Console.ReadLine());
            _endTime = DateTime.Now.AddSeconds(_duration);
            Console.WriteLine(_startingMessage + _title + ". " + _description);
            Console.Clear();
        }
        catch{
            Console.WriteLine("Enter an integer.");
            Pause(1);
            return false;
        }
        return true;
    }

    protected bool IsTimeLeft() {
        return DateTime.Now < _endTime; 
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
        Console.WriteLine(_endingMessage + _title + " activity!");
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