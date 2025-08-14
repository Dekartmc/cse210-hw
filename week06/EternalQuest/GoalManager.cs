using System.Collections.Generic;
using System.IO;
using System.Text.Json;
public class GoalManager
{
  private List<Goal> _goals = new List<Goal>();
  public int Score { get; private set; } = 0;

  public List<Goal> Goals => _goals;

  public void AddGoal(Goal goal)
  {
    _goals.Add(goal);
  }

  public void RecordEvent(int goalIndex)
  {
    if (goalIndex >= 0 && goalIndex < _goals.Count)
    {
      int pointsEarned = _goals[goalIndex].RecordEvent();
      Score += pointsEarned;
      if (pointsEarned > 0)
      {
        Console.WriteLine($"Congratulations! You earned {pointsEarned} points.");
      }
    }
  }

  public void DisplayGoals()
  {
    Console.WriteLine("\n--- Your Goals ---");
    for (int i = 0; i < _goals.Count; i++)
    {
      Console.WriteLine($"{i + 1}. {_goals[i].GetGoalString()}");
    }
  }

  public void SaveGoals(string filename)
  {
    try
    {
      var goalsToSave = new List<object>();
      foreach (var goal in _goals)
      {
        if (goal is SimpleGoal sg)
        {
          goalsToSave.Add(new { Type = "SimpleGoal", sg.Name, sg.Description, sg.Points, sg.IsCompleteFlag });
        }
        else if (goal is EternalGoal eg)
        {
          goalsToSave.Add(new { Type = "EternalGoal", eg.Name, eg.Description, eg.Points });
        }
        else if (goal is ChecklistGoal cg)
        {
          goalsToSave.Add(new { Type = "ChecklistGoal", cg.Name, cg.Description, cg.Points, cg.TargetCount, cg.BonusPoints, cg.CurrentCount });
        }
      }

      var data = new { Score, Goals = goalsToSave };
      string jsonString = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
      File.WriteAllText(filename, jsonString);
      Console.WriteLine($"Goals and score saved successfully to {filename}.");
    }
    catch (Exception ex)
    {
      Console.WriteLine($"An error occurred while saving: {ex.Message}");
    }
  }

  public void LoadGoals(string filename)
  {
    try
    {
      if (File.Exists(filename))
      {
        string jsonString = File.ReadAllText(filename);
        var data = JsonSerializer.Deserialize<JsonElement>(jsonString);

        Score = data.GetProperty("Score").GetInt32();
        _goals.Clear();

        foreach (var element in data.GetProperty("Goals").EnumerateArray())
        {
          string type = element.GetProperty("Type").GetString();
          string name = element.GetProperty("Name").GetString();
          string description = element.GetProperty("Description").GetString();
          int points = element.GetProperty("Points").GetInt32();

          switch (type)
          {
            case "SimpleGoal":
              bool isComplete = element.GetProperty("IsCompleteFlag").GetBoolean();
              _goals.Add(new SimpleGoal(name, description, points, isComplete));
              break;
            case "EternalGoal":
              _goals.Add(new EternalGoal(name, description, points));
              break;
            case "ChecklistGoal":
              int targetCount = element.GetProperty("TargetCount").GetInt32();
              int bonusPoints = element.GetProperty("BonusPoints").GetInt32();
              int currentCount = element.GetProperty("CurrentCount").GetInt32();
              _goals.Add(new ChecklistGoal(name, description, points, targetCount, bonusPoints, currentCount));
              break;
          }
        }
        Console.WriteLine($"Goals and score loaded successfully from {filename}.");
      }
      else
      {
        Console.WriteLine("File not found. No goals were loaded.");
      }
    }
    catch (Exception ex)
    {
      Console.WriteLine($"An error occurred while loading: {ex.Message}");
    }
  }
}