using TheContentDepartment.Utilities.Messages;

namespace TheContentDepartment.Models;

public class ContentMember : TeamMember
{
    public override string Path // correct?
    {
        get => base.Path;

        protected set
        {
            if (
                value != "CSharp"
                && value != "JavaScript"
                && value != "Python"
                && value != "Java"
                )
                throw new ArgumentException(ExceptionMessages.PathIncorrect, value);

            base.Path = value;
        }
    }


    public ContentMember(string name, string path) : base(name, path)
    {

    }

    public override string ToString()
    {
        return $"{Name} - {Path} path. Currently working on {this.InProgress.Count} tasks.";
    }
}