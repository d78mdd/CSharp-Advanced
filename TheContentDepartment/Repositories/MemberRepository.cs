using TheContentDepartment.Models.Contracts;
using TheContentDepartment.Repositories.Contracts;

namespace TheContentDepartment.Repositories;

public class MemberRepository : IRepository<ITeamMember>
{
    private List<ITeamMember> models;

    public IReadOnlyCollection<ITeamMember> Models => models.AsReadOnly();

    public MemberRepository()
    {
        this.models = new List<ITeamMember>();
    }


    public void Add(ITeamMember model)
    {
        models.Add(model);
    }

    public ITeamMember? TakeOne(string modelName)
    {
        return models.FirstOrDefault(member => member.Name == modelName);
    }
}
