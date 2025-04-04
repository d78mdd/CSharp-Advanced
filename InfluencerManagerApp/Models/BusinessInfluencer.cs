using System.Numerics;

namespace InfluencerManagerApp.Models;

public class BusinessInfluencer : Influencer
{
    private string[] validCampaigns = new[] { "ProductCampaign", "ServiceCampaign" };

    public BusinessInfluencer(string username, int followers) : base(username, followers, 3.0)
    {
    }

    public override int CalculateCampaignPrice()
    {
        double factor = 0.15;
        double price = Followers * EngagementRate * factor;
        double priceFloored = Math.Floor(price);
        int priceInt = (int)priceFloored;
        return priceInt;
    }
}