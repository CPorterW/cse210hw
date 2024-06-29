public abstract class Goal
{
    private string _name;
    private int _value;
    private bool _isCompleted;
    protected DateTime _lastCompletionDate;

    public string Name { get => _name; protected set => _name = value; }
    public int Value { get => _value; protected set => _value = value; }
    public bool IsCompleted { get => _isCompleted; protected set => _isCompleted = value; }

    public abstract int RecordEvent();
    public abstract string GetStatusString();
    
    public virtual void SetCompleted(bool completed)
    {
        _isCompleted = completed;
    }
}

public class SimpleGoal : Goal
{
    public SimpleGoal(string name, int value)
    {
        Name = name;
        Value = value;
    }

    public override int RecordEvent()
    {
        if (!IsCompleted)
        {
            SetCompleted(true);
            _lastCompletionDate = DateTime.Now;
            return Value;
        }
        return 0;
    }

    public override string GetStatusString()
    {
        return IsCompleted ? "[X]" : "[ ]";
    }
}
public class EternalGoal : Goal
{
    public EternalGoal(string name, int value)
    {
        Name = name;
        Value = value;
    }

    public override int RecordEvent()
    {
        _lastCompletionDate = DateTime.Now;
        return Value;
    }

    public override string GetStatusString()
    {
        return "[∞]";
    }

    public override void SetCompleted(bool completed)
    {
        // Do nothing - eternal goals are never completed
    }
}
public class ChecklistGoal : Goal
{
    private int _timesCompleted;
    private int _targetTimes;
    private int _bonusValue;

    public int TimesCompleted { get => _timesCompleted; private set => _timesCompleted = value; }
    public int TargetTimes { get => _targetTimes; private set => _targetTimes = value; }
    public int BonusValue { get => _bonusValue; private set => _bonusValue = value; }

    public ChecklistGoal(string name, int value, int targetTimes, int bonusValue)
    {
        Name = name;
        Value = value;
        TargetTimes = targetTimes;
        BonusValue = bonusValue;
    }

    public override int RecordEvent()
    {
        TimesCompleted++;
        _lastCompletionDate = DateTime.Now;
        if (TimesCompleted >= TargetTimes)
        {
            SetCompleted(true);
            return Value + BonusValue;
        }
        return Value;
    }
    public void SetTimesCompleted(int times)
    {
        TimesCompleted = times;
        if (TimesCompleted >= TargetTimes)
        {
            SetCompleted(true);
        }
    }
    public override string GetStatusString()
    {
        return $"[{TimesCompleted}/{TargetTimes}]";
    }
}