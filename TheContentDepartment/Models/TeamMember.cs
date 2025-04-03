using TheContentDepartment.Models.Contracts;

namespace TheContentDepartment.Models;

public abstract class TeamMember : ITeamMember
{
    public string Name { get; }

    public string Path { get; }

    public IReadOnlyCollection<string> InProgress { get; }



    public void WorkOnTask(string resourceName)
    {
        throw new NotImplementedException();
    }

    public void FinishTask(string resourceName)
    {
        throw new NotImplementedException();
    }
}