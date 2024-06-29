public class Achievement
{
    private string _name;
    private string _description;
    private int _pointValue;
    private bool _isUnlocked;

    public string Name { get => _name; private set => _name = value; }
    public string Description { get => _description; private set => _description = value; }
    public int PointValue { get => _pointValue; private set => _pointValue = value; }
    public bool IsUnlocked { get => _isUnlocked; private set => _isUnlocked = value; }

    public Achievement(string name, string description, int pointValue)
    {
        Name = name;
        Description = description;
        PointValue = pointValue;
        IsUnlocked = false;
    }

    public int Unlock()
    {
        if (!IsUnlocked)
        {
            IsUnlocked = true;
            Console.WriteLine($"Achievement Unlocked: {Name}");
            Console.WriteLine(Description);
            return PointValue;
        }
        return 0;
    }
}