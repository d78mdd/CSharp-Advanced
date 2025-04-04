namespace InfluencerManagerApp.Models;

public class BloggerInfluencer : Influencer
{
    private string[] validCampaigns = new[] { "ServiceCampaign" };

    public BloggerInfluencer(string username, int followers) : base(username, followers, 2.0)
    {
    }

    public override int CalculateCampaignPrice()
    {
        double factor = 0.2;
        double price = Followers * EngagementRate * factor;
        double priceFloored = Math.Floor(price);
        int priceInt = (int)priceFloored;
        return priceInt;
    }
}