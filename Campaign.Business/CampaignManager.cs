using Campaign.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Campaign.Business
{
    public class CampaignManager : ICampaignManager
    {
        public List<Models.Campaign> GetAllRecords()
        {
            //var campaigns = unitOfWork.CampaignRepository.Get();
            return null;
        }
    }
}
