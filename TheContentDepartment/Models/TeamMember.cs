using TheContentDepartment.Models.Contracts;
using TheContentDepartment.Utilities.Messages;

namespace TheContentDepartment.Models;

public abstract class TeamMember : ITeamMember
{
    private List<string> _inProgress;


    public string Name { get; }

    public virtual string Path { get; protected set; } // Be careful with the access modifier! ??
                                                       
    public IReadOnlyCollection<string> InProgress { get; }


    protected TeamMember(string name, string path)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException(ExceptionMessages.NameNullOrWhiteSpace);
        Name = name;

        Path = path;
 
        _inProgress = new List<string>();
        InProgress = _inProgress.AsReadOnly();
    }


    public void WorkOnTask(string resourceName)
    {
        _inProgress.Add(resourceName); ;
    }

    public void FinishTask(string resourceName)
    {
        _inProgress.Remove(resourceName);
    }
}