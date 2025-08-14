public class SimpleGoal : Goal
{
    public bool IsCompleteFlag { get; private set; }

    public SimpleGoal(string name, string description, int points) : base(name, description, points)
    {
        IsCompleteFlag = false;
    }
    
    public SimpleGoal(string name, string description, int points, bool isComplete) : base(name, description, points)
    {
        IsCompleteFlag = isComplete;
    }

    public override int RecordEvent()
    {
        if (!IsCompleteFlag)
        {
            IsCompleteFlag = true;
            return Points;
        }
        return 0;
    }

    public override bool IsComplete()
    {
        return IsCompleteFlag;
    }
    
    public override string GetStatusString()
    {
        return IsCompleteFlag ? "[X]" : "[ ]";
    }

    public override string GetGoalString()
    {
        return $"{GetStatusString()} {Name} ({Description})";
    }
}