using InfluencerManagerApp.Models.Contracts;
using InfluencerManagerApp.Repositories.Contracts;

namespace InfluencerManagerApp.Repositories;

public class InfluencerRepository : IRepository<IInfluencer>
{

    private List<IInfluencer> _models;
    public IReadOnlyCollection<IInfluencer> Models => _models.AsReadOnly();


    public InfluencerRepository()  // constructor wanted?
    {
        _models = new List<IInfluencer>();
    }




    public void AddModel(IInfluencer model)
    {
        _models.Add(model);
    }


    public bool RemoveModel(IInfluencer model)
    {
        return _models.Remove(model);
    }


    public IInfluencer? FindByName(string name)
    {
        return _models.FirstOrDefault(i => i.Username == name);
    }
}