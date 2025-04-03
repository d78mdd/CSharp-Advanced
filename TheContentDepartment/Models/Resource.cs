using TheContentDepartment.Models.Contracts;
using TheContentDepartment.Utilities.Messages;

namespace TheContentDepartment.Models;

public abstract class Resource : IResource
{
    public string Name { get; }

    public string Creator { get; }

    public int Priority { get; }


    public bool IsTested { get; private set; }

    public bool IsApproved { get; private set; }


    protected Resource(string name, string creator, int priority)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException(ExceptionMessages.NameNullOrWhiteSpace);
        Name = name;

        Creator = creator;

        Priority = priority;
    }


    public void Test()
    {
        IsTested = !IsTested;
    }

    public void Approve()
    {
        IsApproved = true;
    }


    public override string ToString()
    {
        string objectTypeName = this.GetType().Name;

        return $"{Name} ({objectTypeName}), Created By: {Creator}";
    }
}