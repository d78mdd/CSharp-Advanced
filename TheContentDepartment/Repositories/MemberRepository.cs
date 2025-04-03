using TheContentDepartment.Repositories.Contracts;

namespace TheContentDepartment.Repositories;

public class MemberRepository<ITeamMember> : IRepository<ITeamMember> where ITeamMember : class
{
    public IReadOnlyCollection<ITeamMember> Models { get; }



    public void Add(ITeamMember model)
    {
        throw new NotImplementedException();
    }

    public ITeamMember TakeOne(string modelName)
    {
        throw new NotImplementedException();
    }
}