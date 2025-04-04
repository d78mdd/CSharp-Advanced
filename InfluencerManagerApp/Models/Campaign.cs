using InfluencerManagerApp.Models.Contracts;
using InfluencerManagerApp.Utilities.Messages;

namespace InfluencerManagerApp.Models;

public abstract class Campaign : ICampaign
{
    public string Brand { get; }

    public double Budget { get; protected set; } // correct?


    private List<string> _contributors;
    public IReadOnlyCollection<string> Contributors { get; }


    protected Campaign(string brand, double budget)
    {
        if (string.IsNullOrWhiteSpace(brand))
            throw new ArgumentException(ExceptionMessages.BrandIsrequired);
        Brand = brand;

        Budget = budget;

        _contributors = new List<string>();
        Contributors = _contributors.AsReadOnly();
    }


    public override string ToString()
    {
        string campaignTypeName = GetType().Name;
        int count = Contributors.Count;
        return $"{campaignTypeName} - Brand: {Brand}, Budget: {Budget}, Contributors: {count}";
    }



    public void Gain(double amount)
    {
        Budget += amount; // or _budget?
    }


    public void Engage(IInfluencer influencer)
    {
        _contributors.Add(influencer.Username);
        Budget -= influencer.Income;  // influencer fees.  // correct?   // or _budget
    }
}