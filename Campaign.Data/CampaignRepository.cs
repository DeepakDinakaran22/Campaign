using Campaign.Data.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Campaign.Data
{
    public class CampaignRepository : ICampaignRepository, IDisposable
    {
        private CampaignContext context;
        public CampaignRepository(CampaignContext context)
        {
            this.context = context;
        }


        public void AddCampaign(Entities.Campaign campaign)
        {
            context.Campaign.Add(campaign);
        }

        public void DeleteCampaign(int campaignId)
        {
            Entities.Campaign campaign = context.Campaign.Find(campaignId);
            context.Campaign.Remove(campaign);
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public IEnumerable<Entities.Campaign> GetCampaign()
        {
            return context.Campaign.ToList();
        }

        public Entities.Campaign GetCampaignByID(int campaignId)
        {
            return context.Campaign.Find(campaignId);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void UpdateCampaign(Entities.Campaign campaign)
        {
            context.Entry(campaign).State = EntityState.Modified;
        }
    }
}
