using System.Reflection;
using TheContentDepartment.Models;
using TheContentDepartment.Models.Contracts;
using TheContentDepartment.Repositories.Contracts;

namespace TheContentDepartment.Repositories;

public class ResourceRepository : IRepository<IResource>
{
    private List<IResource> models;
    
    public IReadOnlyCollection<IResource> Models => models.AsReadOnly();


    public ResourceRepository()
    {
        this.models = new List<IResource>();
    }




    public void Add(IResource model)
    {
        models.Add(model); ;
    }

    public IResource TakeOne(string modelName)
    {
        return models.FirstOrDefault(resource => resource.Name == modelName);
    }
}