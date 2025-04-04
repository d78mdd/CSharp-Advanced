namespace InfluencerManagerApp.Models;

public class ProductCampaign : Campaign
{
    //It can contribute to business and fashion influencers
    private string[] validInfuencers = new[] { "BusinessInfluencer", "FashionInfluencer" };

    public ProductCampaign(string brand) : base(brand, 60000)
    {
    }

    public bool IsValidInfluencer(string name)
    {
        return validInfuencers.Contains(name);
    }
}