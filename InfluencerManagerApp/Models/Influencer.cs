using InfluencerManagerApp.Models.Contracts;
using InfluencerManagerApp.Utilities.Messages;
using System.Numerics;

namespace InfluencerManagerApp.Models;

public abstract class Influencer : IInfluencer
{
    public string Username { get; }

    public int Followers { get; }

    public double EngagementRate { get; }

    public double Income { get; private set; } // be set to zero by default


    private List<string> _participations;
    public IReadOnlyCollection<string> Participations { get; }


    protected Influencer(string username, int followers, double engagementRate)
    {
        if (string.IsNullOrWhiteSpace(username))
        {
            throw new ArgumentException(ExceptionMessages.UsernameIsRequired);
        }
        Username = username;

        if (followers < 0)
        {
            throw new ArgumentException(ExceptionMessages.FollowersCountNegative);
        }
        Followers = followers;

        EngagementRate = engagementRate;

        _participations = new List<string>();
        Participations = _participations.AsReadOnly();
    }

    public override string ToString()
    {
        return $"{Username} - Followers: {Followers}, Total Income: {Income}";
    }


    public void EarnFee(double amount)
    {
        Income += amount;
    }

    public void EnrollCampaign(string brand)
    {
        _participations.Add(brand);
    }

    public void EndParticipation(string brand)
    {
        _participations.Remove(brand);
    }

    public abstract int CalculateCampaignPrice();
}
