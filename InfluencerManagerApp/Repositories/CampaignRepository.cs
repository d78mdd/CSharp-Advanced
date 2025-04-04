using InfluencerManagerApp.Models.Contracts;
using InfluencerManagerApp.Repositories.Contracts;

namespace InfluencerManagerApp.Repositories;

public class CampaignRepository : IRepository<ICampaign>
{
    private List<ICampaign> _models;
    public IReadOnlyCollection<ICampaign> Models => _models.AsReadOnly();

    public CampaignRepository() // constructor wanted?
    {
        _models = new List<ICampaign>();
    }


    public void AddModel(ICampaign model)
    {
        _models.Add(model);
    }


    public bool RemoveModel(ICampaign model)
    {
        return _models.Remove(model);
    }


    public ICampaign? FindByName(string name)
    {
        return _models.FirstOrDefault(c => c.Brand == name);
    }
}
