

namespace Campaign.Data.Interface
{
    using System;
    using System.Collections.Generic;
    using Campaign.Data.Entities;
    public interface ICampaignRepository : IDisposable
    {
        IEnumerable<Campaign> GetCampaign();
        Campaign GetCampaignByID(int campaignId);
        void AddCampaign(Campaign campaign);
        void DeleteCampaign(int campaignId);
        void UpdateCampaign(Campaign campaign);
        void Save();
    }
}
