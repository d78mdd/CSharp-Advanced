using AccessControlSystem.Models.Contracts;
using AccessControlSystem.Repositories.Contracts;

namespace AccessControlSystem.Repositories;

public class SecurityZoneRepository : IRepository<ISecurityZone>
{
    private List<ISecurityZone> _models;
    public IReadOnlyCollection<ISecurityZone> Models => _models.AsReadOnly();


    public SecurityZoneRepository() // constructor wanted?
    {
        _models = new List<ISecurityZone>();
    }



    public void AddNew(ISecurityZone model)
    {
        _models.Add(model);
    }

    public ISecurityZone? GetByName(string modelName)
    {
        return _models.FirstOrDefault(z => z.Name == modelName);
    }

    // no default value when no such zone ?
    public int SecurityCheck(string modelName)
    {
        ISecurityZone securityZone = GetByName(modelName);
        int accessLevel = securityZone.AccessLevelRequired;
        return accessLevel;
    }
}
