using System;
using System.IO;
using TheContentDepartment.Utilities.Messages;

namespace TheContentDepartment.Models;

public class TeamLead : TeamMember
{

    public override string Path // correct?
    {
        get => base.Path;

        protected set
        {
            if (value != "Master")
                throw new ArgumentException(ExceptionMessages.PathIncorrect, value);

            base.Path = value;
        }
    }


    public TeamLead(string name, string path) : base(name, path)
    {
    }


    public override string ToString()
    {
        return $"{Name} ({this.GetType().Name}) - Currently working on {this.InProgress.Count} tasks.";
        // {this.GetType().Name}?
    }
}