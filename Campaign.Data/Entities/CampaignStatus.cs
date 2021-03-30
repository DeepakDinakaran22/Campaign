using System;
using System.Collections.Generic;
using System.Text;

namespace Campaign.Data.Entities
{
    public class CampaignStatus
    {
        public long CampaignStatuID { get; set; }

        public string CampaignStatusBefore { get; set; }

        public string CampaignStatusAfter { get; set; }

        public bool? Status { get; set; }
    }
}
