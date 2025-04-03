using TheContentDepartment.Repositories.Contracts;

namespace TheContentDepartment.Repositories;

public class ResourceRepository<IResource> : IRepository<IResource> where IResource : class
{
    public IReadOnlyCollection<IResource> Models { get; }



    public void Add(IResource model)
    {
        throw new NotImplementedException();
    }

    public IResource TakeOne(string modelName)
    {
        throw new NotImplementedException();
    }
}