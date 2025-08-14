using System.Collections.Generic;
using System.IO;
using System.Text.Json;
public class ChecklistGoal : Goal
{
  public int TargetCount { get; private set; }
  public int CurrentCount { get; private set; }
  public int BonusPoints { get; private set; }

  public ChecklistGoal(string name, string description, int points, int targetCount, int bonusPoints) : base(name, description, points)
  {
    TargetCount = targetCount;
    CurrentCount = 0;
    BonusPoints = bonusPoints;
  }

  public ChecklistGoal(string name, string description, int points, int targetCount, int bonusPoints, int currentCount) : base(name, description, points)
  {
    TargetCount = targetCount;
    BonusPoints = bonusPoints;
    CurrentCount = currentCount;
  }

  public override int RecordEvent()
  {
    if (!IsComplete())
    {
      CurrentCount++;
      if (IsComplete())
      {
        return Points + BonusPoints;
      }
      return Points;
    }
    return 0;
  }

  public override bool IsComplete()
  {
    return CurrentCount >= TargetCount;
  }

  public override string GetStatusString()
  {
    return IsComplete() ? "[X]" : "[ ]";
  }

  public override string GetGoalString()
  {
    return $"{GetStatusString()} {Name} ({Description}) -- Currently completed {CurrentCount}/{TargetCount} times";
  }
}