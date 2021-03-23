using System.Collections.Generic;

namespace Campaign.Business.Interfaces
{
    public interface ICampaignManager
    {
        List<Models.Campaign> GetAllRecords();
    }
}
