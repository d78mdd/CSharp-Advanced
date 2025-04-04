namespace InfluencerManagerApp.Models;

public class FashionInfluencer : Influencer
{

    private string[] validCampaigns = new[] { "ProductCampaign" };

    public FashionInfluencer(string username, int followers) : base(username, followers, 4.0)
    {
    }

    public override int CalculateCampaignPrice()
    {
        double factor = 0.1;
        double price = Followers * EngagementRate * factor;
        double priceFloored = Math.Floor(price);
        int priceInt = (int)priceFloored;
        return priceInt;
    }
}