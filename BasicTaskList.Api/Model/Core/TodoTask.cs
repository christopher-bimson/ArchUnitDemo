namespace BasicTaskList.Api.Model.Core;

public class TodoTask
{
    public static IEnumerable<TodoTask> From(IEnumerable<string> tasks)
    {
        return tasks.Select(t => new TodoTask(t, false));
    }
    
    public string Text { get; }
    public bool Complete { get; }

    private TodoTask(string text, bool complete)
    {
        Text = text;
        Complete = complete;
    }

    private bool Equals(TodoTask other)
    {
        return Text == other.Text && Complete == other.Complete;
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((TodoTask)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Text, Complete);
    }
}

    