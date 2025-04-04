namespace InfluencerManagerApp.Models;

public class ServiceCampaign : Campaign
{
    //It can contribute to these influencers
    private string[] validInfuencers = new[] { "BusinessInfluencer", "BloggerInfluencer" };

    public ServiceCampaign(string brand) : base(brand, 30000)
    {
    }

    public bool IsValidInfluencer(string name)
    {
        return validInfuencers.Contains(name);
    }
}