using System.ComponentModel;
using System.Text;
using InfluencerManagerApp.Core.Contracts;
using InfluencerManagerApp.Models;
using InfluencerManagerApp.Models.Contracts;
using InfluencerManagerApp.Repositories;
using InfluencerManagerApp.Repositories.Contracts;
using InfluencerManagerApp.Utilities.Messages;

namespace InfluencerManagerApp.Core;

public class Controller : IController
{
    private string[] validInfluencers = new[] { "BusinessInfluencer", "FashionInfluencer", "BloggerInfluencer" };
    private string[] validCampaigns = new[] { "ProductCampaign", "ServiceCampaign" };

    private IRepository<IInfluencer> influencers;
    private IRepository<ICampaign> campaigns;

    public Controller()
    {
        campaigns = new CampaignRepository();
        influencers = new InfluencerRepository();
    }




    public string RegisterInfluencer(string typeName, string username, int followers)
    {
        IInfluencer influencer;

        if (!validInfluencers.Contains(typeName))  // would want reflection instead ??
        {
            return string.Format(OutputMessages.InfluencerInvalidType, typeName);
        }

        IInfluencer? existingInfluencer = this.influencers.FindByName(username);

        if (existingInfluencer != null)
        {
            string correctRepositoryTypeName = "InfluencerRepository";

            return string.Format(OutputMessages.UsernameIsRegistered, username, correctRepositoryTypeName);
        }

        if (typeName == "BusinessInfluencer")
        {
            influencer = new BusinessInfluencer(username, followers);
        }
        else if (typeName == "FashionInfluencer")
        {
            influencer = new FashionInfluencer(username, followers);
        }
        else  // (typeName == "BloggerInfluencer")
        {
            influencer = new BloggerInfluencer(username, followers);
        }

        influencers.AddModel(influencer);

        return string.Format(OutputMessages.InfluencerRegisteredSuccessfully, username);
    }



    public string BeginCampaign(string typeName, string brand)
    {
        ICampaign campaign;

        if (!validCampaigns.Contains(typeName))
        {
            return string.Format(OutputMessages.CampaignTypeIsNotValid, typeName);
        }

        ICampaign? existingCampaign = this.campaigns.FindByName(brand);

        if (existingCampaign != null)
        {
            return string.Format(OutputMessages.CampaignDuplicated, brand);
        }


        if (typeName == "ProductCampaign")
        {
            campaign = new ProductCampaign(brand);
        }
        else  // (typeName == "ServiceCampaign")
        {
            campaign = new ServiceCampaign(brand);
        }


        campaigns.AddModel(campaign);

        return string.Format(OutputMessages.CampaignStartedSuccessfully, brand, typeName);
    }



    public string AttractInfluencer(string brand, string username)
    {
        IInfluencer? existingInfluencer = this.influencers.FindByName(username);
        if (existingInfluencer == null)
        {
            string correctRepositoryTypeName = "InfluencerRepository";
            return string.Format(OutputMessages.InfluencerNotFound, correctRepositoryTypeName, username);
        }

        ICampaign? existingCampaign = this.campaigns.FindByName(brand);
        if (existingCampaign == null)
        {
            return string.Format(OutputMessages.CampaignNotFound, brand);
        }

        bool alreadyEngaged = existingCampaign.Contributors.Contains(username);
        if (alreadyEngaged)
        {
            return string.Format(OutputMessages.InfluencerAlreadyEngaged, username, brand);
        }

        string influencerType = existingInfluencer.GetType().Name;

        string campaignType = existingCampaign.GetType().Name;   // will need to cast before that ??
        bool eligible = (
            (campaignType == "ProductCampaign" && (influencerType == "FashionInfluencer" || influencerType == "BusinessInfluencer"))
            ||
            (campaignType == "ServiceCampaign" && (influencerType == "BloggerInfluencer" || influencerType == "BusinessInfluencer"))
            );
        if (!eligible)
        {
            return string.Format(OutputMessages.InfluencerNotEligibleForCampaign, username, brand);
        }

        // update the influencer's Income  ??
        int influencerCampaignPrice = existingInfluencer.CalculateCampaignPrice();


        bool budgetAllows = existingCampaign.Budget >= influencerCampaignPrice;   // correct ?  // need influencerCampaignPrice ?
        if (!budgetAllows)
        {
            return string.Format(OutputMessages.UnsufficientBudget, brand, username);
        }


        existingInfluencer.EarnFee(influencerCampaignPrice);
        existingInfluencer.EnrollCampaign(brand);

        existingCampaign.Engage(existingInfluencer);

        return string.Format(OutputMessages.InfluencerAttractedSuccessfully, username, brand);

    }



    public string FundCampaign(string brand, double amount)  // task description : •	amount – string
    {
        ICampaign? existingCampaign = this.campaigns.FindByName(brand);
        if (existingCampaign == null)
        {
            return string.Format(OutputMessages.InvalidCampaignToFund);
        }

        if (amount < 0)  // need to parse string to double?
        {
            return string.Format(OutputMessages.NotPositiveFundingAmount);
        }

        existingCampaign.Gain(amount);

        return string.Format(OutputMessages.CampaignFundedSuccessfully, brand, amount);
    }



    public string CloseCampaign(string brand)
    {
        ICampaign? existingCampaign = this.campaigns.FindByName(brand);
        if (existingCampaign == null)
        {
            return string.Format(OutputMessages.InvalidCampaignToClose);
        }

        bool targetNotMet = existingCampaign.Budget <= 10000;
        if (targetNotMet)
        {
            return string.Format(OutputMessages.CampaignCannotBeClosed, brand);
        }

        foreach (var influencer in this.influencers.Models.Where(i => i.Participations.Contains("brand"))) // correct ?
        {
            influencer.EarnFee(2000);  // or directly use Income property?

            influencer.EndParticipation(brand);
        }

        campaigns.RemoveModel(existingCampaign);

        return string.Format(OutputMessages.CampaignClosedSuccessfully, brand);
    }



    public string ConcludeAppContract(string username)
    {
        IInfluencer? existingInfluencer = this.influencers.FindByName(username);
        if (existingInfluencer == null)
        {
            return string.Format(OutputMessages.InfluencerNotSigned, username);
        }

        bool hasParticipations = existingInfluencer.Participations.Count > 1;
        // ? or  this.campaigns.Models.Where(c => c.Contributors.Contains(username))

        if (hasParticipations)
        {
            return string.Format(OutputMessages.InfluencerHasActiveParticipations, username);
        }

        influencers.RemoveModel(existingInfluencer);  // enough ?

        return string.Format(OutputMessages.ContractConcludedSuccessfully, username);
    }





    public string ApplicationReport()
    {
        StringBuilder sb = new StringBuilder();

        foreach (IInfluencer influencer in this.influencers.Models
                     .OrderByDescending(i => i.Income)
                     .ThenByDescending(i => i.Followers)
                 )
        {

            sb.Append(influencer.ToString());
            sb.AppendLine();

            if (influencer.Participations.Count < 1)
            {
                continue;
            }

            sb.Append("Active Campaigns:");
            sb.AppendLine();

            //foreach (string campaign in influencer.Participations
            //             .OrderBy(brand => brand))
            foreach (var campaign in this.campaigns.Models
                         .Where(c => c.Contributors.Contains(influencer.Username)))
            {
                sb.Append("--");
                sb.Append(campaign.ToString());
                sb.AppendLine();
            }

           
        }

        return sb.ToString().Trim();

    }
}
