public class DailyStreak
{
    private int _currentStreak;
    private int _longestStreak;
    private DateTime _lastCompletionDate;

    public int CurrentStreak { get => _currentStreak; private set => _currentStreak = value; }
    public int LongestStreak { get => _longestStreak; private set => _longestStreak = value; }

    public DailyStreak()
    {
        _currentStreak = 0;
        _longestStreak = 0;
        _lastCompletionDate = DateTime.MinValue;
    }
    public DateTime GetLastCompletionDate()
    {
        return _lastCompletionDate;
    }
    public void IncrementStreak()
    {
        if (_lastCompletionDate.Date == DateTime.Today.AddDays(-1))
        {
            CurrentStreak++;
            if (CurrentStreak > LongestStreak)
            {
                LongestStreak = CurrentStreak;
            }
        }
        else if (_lastCompletionDate.Date != DateTime.Today)
        {
            CurrentStreak = 1;
        }
        _lastCompletionDate = DateTime.Today;
    }

    public void SetCurrentStreak(int streak)
    {
        CurrentStreak = streak;
        if (CurrentStreak > LongestStreak)
        {
            LongestStreak = CurrentStreak;
        }
    }

    public void SetLongestStreak(int streak)
    {
        LongestStreak = streak;
    }

    public void SetLastCompletionDate(DateTime date)
    {
        _lastCompletionDate = date;
    }

    public override string ToString()
    {
        return $"Current Streak: {CurrentStreak} days, Longest Streak: {LongestStreak} days";
    }
}