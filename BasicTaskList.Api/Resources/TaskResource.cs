namespace BasicTaskList.Api.Resources;

public class TaskResource
{
    public string Text { get; }
    public bool Complete { get; }
    
    public TaskResource(string text, bool complete)
    {
        Text = text;
        Complete = complete;
    }

}