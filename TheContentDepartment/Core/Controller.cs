using System.Text;
using TheContentDepartment.Core.Contracts;
using TheContentDepartment.Models;
using TheContentDepartment.Models.Contracts;
using TheContentDepartment.Repositories;
using TheContentDepartment.Utilities.Messages;

namespace TheContentDepartment.Core;

public class Controller : IController
{
    private string[] memberPaths = { "CSharp", "JavaScript", "Python", "Java" };
    private string[] resourceTypes = { "Exam", "Presentation", "Workshop" };

    private ResourceRepository resources;
    private MemberRepository members;

    public Controller()
    {
        resources = new ResourceRepository();
        members = new MemberRepository();
    }

    public string JoinTeam(string memberType, string memberName, string path)
    {
        if (memberType != "ContentMember" && memberType != "TeamLead")
        {
            return string.Format(OutputMessages.MemberTypeInvalid, memberType);
        }

        ITeamMember newMember;

        if (memberType == "ContentMember")
        {
            if (members.Models.Any(existingMember => existingMember.Path == path))
            {
                return string.Format(OutputMessages.PositionOccupied);
            }
        }

        ITeamMember? member = this.members.Models
            .FirstOrDefault(teamMember => teamMember.Name == memberName);
        if (member is not null)
        {
            return string.Format(OutputMessages.MemberExists, memberName);
        }

        if (memberPaths.Contains(path))
        {
            newMember = new ContentMember(memberName, path);
        }
        else  // is TeamLead
        {
            newMember = new TeamLead(memberName, path);
        }

        members.Add(newMember);

        return string.Format(OutputMessages.MemberJoinedSuccessfully, memberName);
    }



    public string CreateResource(string resourceType, string resourceName, string path)
    {
        if (!resourceTypes.Contains(resourceType))
        {
            return string.Format(OutputMessages.ResourceTypeInvalid, resourceType);
        }

        ContentMember? contentMember = (ContentMember?)this.members.Models.FirstOrDefault(m => m.Path == path && memberPaths.Contains(path));

        if (contentMember is null)
        {
            return string.Format(OutputMessages.NoContentMemberAvailable, resourceName);
        }
        else
        {
            if (contentMember.InProgress.Contains(resourceName))
            {
                return string.Format(OutputMessages.ResourceExists, resourceName);
            }
        }

        IResource resource;
        string memberName = contentMember.Name;
        if (resourceType == "Exam")
        {
            resource = new Exam(resourceName, memberName);
        }
        else if (resourceType == "Presentation")
        {
            resource = new Presentation(resourceName, memberName);
        }
        else // (resourceType == "Workshop")
        {
            resource = new Workshop(resourceName, memberName);
        }

        contentMember.WorkOnTask(resourceName);

        this.resources.Add(resource);

        return string.Format($"{memberName} created {resourceType} - {resourceName}.");
    }



    public string LogTesting(string memberName)
    {
        ITeamMember? member = this.members.TakeOne(memberName);

        if (member is null)
        {
            return string.Format(OutputMessages.WrongMemberName);
        }

        IResource? resource = this.resources.Models
            .OrderBy(r => r.Priority)
            .Where(r => !r.IsTested)
            .Where(r => r.Creator == memberName)
            .FirstOrDefault();

        if (resource == null)
        {
            return string.Format(OutputMessages.NoResourcesForMember, memberName);
        }

        ITeamMember teamLead = members
            .Models
            .First(m => m.Path == "Master");

        member.FinishTask(resource.Name);

        teamLead.WorkOnTask(resource.Name);

        resource.Test();  // ? is this ok

        return string.Format(OutputMessages.ResourceTested, resource.Name);
    }



    public string ApproveResource(string resourceName, bool isApprovedByTeamLead)
    {
        IResource resource = this.resources.TakeOne(resourceName);

        if (!resource.IsTested)
        {
            return string.Format(OutputMessages.ResourceNotTested, resourceName);
        }
        // else IsTested

        ITeamMember teamLead = this.members.Models
            .First(m => m.Path == "Master");

        if (isApprovedByTeamLead)
        {
            resource.Approve();
            teamLead.FinishTask(resourceName);
            return string.Format(OutputMessages.ResourceApproved, teamLead.Name, resourceName);
        }
        else
        {
            resource.Test(); // correct?
            return string.Format(OutputMessages.ResourceReturned, teamLead.Name, resourceName);
        }

    }


    // will have issues with correct teamLead member type used thus wrong tostring?
    public string DepartmentReport()
    {
        ITeamMember teamLead = members.Models.First(m => m.Path == "Master");
        int countOfTasks = teamLead.InProgress.Count;

        StringBuilder sb = new StringBuilder();

        sb.Append("Finished Tasks:");

        foreach (IResource resource in this.resources.Models.Where(r => r.IsApproved))
        {
            sb.AppendLine();

            sb.Append("--");
            sb.Append(resource.ToString());
        }
        sb.AppendLine();

        sb.Append("Team Report:");
        sb.AppendLine();
        sb.Append("--");
        sb.Append(teamLead.ToString());

        foreach (var member in this.members.Models.Where(m => m.Path != "Master"))
        {
            sb.AppendLine();
            sb.Append(member.ToString());
        }

        return sb.ToString();

    }
}
