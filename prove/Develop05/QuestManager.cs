public class QuestManager
{
    private List<Goal> goals = new List<Goal>();
    private List<Achievement> achievements = new List<Achievement>();
    public int Score { get; private set; }
    public int Level { get; private set; }
    public DailyStreak Streak { get; private set; }

    public QuestManager()
    {
        Streak = new DailyStreak();
        InitializeAchievements();
    }

    private void InitializeAchievements()
    {
        achievements.Add(new Achievement("Streak Master", "Reach a five day streak", 500));
        achievements.Add(new Achievement("Century Club", "Reach level 100", 10000));
        achievements.Add(new Achievement("Checklist Champion", "Complete a checklist goal", 100));
    }

    public void AddGoal(Goal goal)
    {
        goals.Add(goal);
    }

    public void RecordEvent(int goalIndex)
    {
        if (goalIndex >= 0 && goalIndex < goals.Count)
        {
            int pointsEarned = goals[goalIndex].RecordEvent();
            Score += pointsEarned;
            Streak.IncrementStreak();
            UpdateLevel();
            CheckAchievements();
            Console.WriteLine($"Congratulations! You earned {pointsEarned} points!");
        }
    }

    private void UpdateLevel()
    {
        Level = (Score / 1000) + 1;
    }

    private void CheckAchievements()
    {
        if (Streak.CurrentStreak == 5)
        {
            Score += UnlockAchievement("Streak Master");
        }

        if (Level >= 100)
        {
            Score += UnlockAchievement("Century Club");
        }

        if (goals.Any(g => g is ChecklistGoal cg && cg.IsCompleted))
        {
            Score += UnlockAchievement("Checklist Champion");
        }
    }

    private int UnlockAchievement(string name)
    {
        var achievement = achievements.FirstOrDefault(a => a.Name == name && !a.IsUnlocked);
        return achievement?.Unlock() ?? 0;
    }

    public void DisplayGoals()
    {
        for (int i = 0; i < goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {goals[i].GetStatusString()} {goals[i].Name}");
        }
    }

    public void DisplayScore()
    {
        Console.WriteLine($"You have {Score} points.");
        Console.WriteLine($"Your current level: {Level}");
        Console.WriteLine(Streak.ToString());
    }

    public void DisplayAchievements()
    {
        Console.WriteLine("Achievements:");
        foreach (var achievement in achievements)
        {
            Console.WriteLine($"{achievement.Name}: {(achievement.IsUnlocked ? "Unlocked" : "Locked")}");
        }
    }

    public void SaveProgress(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            writer.WriteLine(Score);
            writer.WriteLine(Level);
            writer.WriteLine($"{Streak.CurrentStreak},{Streak.LongestStreak},{Streak.GetLastCompletionDate():yyyy-MM-dd}");
            
            foreach (var achievement in achievements)
            {
                writer.WriteLine($"Achievement:{achievement.Name},{achievement.IsUnlocked}");
            }

            foreach (Goal goal in goals)
            {
                if (goal is SimpleGoal simpleGoal)
                {
                    writer.WriteLine($"SimpleGoal:{simpleGoal.Name},{simpleGoal.Value},{simpleGoal.IsCompleted}");
                }
                else if (goal is EternalGoal eternalGoal)
                {
                    writer.WriteLine($"EternalGoal:{eternalGoal.Name},{eternalGoal.Value}");
                }
                else if (goal is ChecklistGoal checklistGoal)
                {
                    writer.WriteLine($"ChecklistGoal:{checklistGoal.Name},{checklistGoal.Value},{checklistGoal.TimesCompleted},{checklistGoal.TargetTimes},{checklistGoal.BonusValue},{checklistGoal.IsCompleted}");
                }
            }
        }
    }

    public void LoadProgress(string filename)
    {
    goals.Clear();
    using (StreamReader reader = new StreamReader(filename))
    {
        Score = int.Parse(reader.ReadLine());
        Level = int.Parse(reader.ReadLine());

        var streakData = reader.ReadLine().Split(',');
        Streak.SetCurrentStreak(int.Parse(streakData[0]));
        Streak.SetLongestStreak(int.Parse(streakData[1]));
        Streak.SetLastCompletionDate(DateTime.Parse(streakData[2]));

        string line;
        while ((line = reader.ReadLine()) != null)
        {
            if (line.StartsWith("Achievement:"))
            {
                var achievementData = line.Substring(12).Split(',');
                var achievement = achievements.FirstOrDefault(a => a.Name == achievementData[0]);
                if (achievement != null && bool.Parse(achievementData[1]))
                {
                    achievement.Unlock();
                }
            }
            else {
                string[] parts = line.Split(':');
                string goalType = parts[0];
                string[] goalData = parts[1].Split(',');

                switch (goalType)
                {
                    case "SimpleGoal":
                        SimpleGoal simpleGoal = new SimpleGoal(goalData[0], int.Parse(goalData[1]));
                        simpleGoal.SetCompleted(bool.Parse(goalData[2]));
                        goals.Add(simpleGoal);
                        break;
                    case "EternalGoal":
                        EternalGoal eternalGoal = new EternalGoal(goalData[0], int.Parse(goalData[1]));
                        goals.Add(eternalGoal);
                        break;
                    case "ChecklistGoal":
                        ChecklistGoal checklistGoal = new ChecklistGoal(goalData[0], int.Parse(goalData[1]), int.Parse(goalData[3]), int.Parse(goalData[4]));
                        checklistGoal.SetTimesCompleted(int.Parse(goalData[2]));
                        goals.Add(checklistGoal);
                        break;
                }
            }
        }
    }
    }
}