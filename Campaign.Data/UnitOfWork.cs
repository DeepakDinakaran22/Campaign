

namespace Campaign.Data
{
    using Campaign.Data;
    using System;
    using Campaign.Data.Entities;
    public class UnitOfWork : IDisposable
    {
        private CampaignContext context = new CampaignContext();
        private GenericRepository<Campaign> campaignRepository;
        private GenericRepository<Category> categoryRepository;
        public GenericRepository<Campaign> CampaignRepository
        {
            get
            {
                if (this.campaignRepository == null)
                {
                    this.campaignRepository = new GenericRepository<Campaign>(context);
                }
                return campaignRepository;
            }
        }
        public GenericRepository<Category> CategoryRepository
        {
            get
            {
                if (this.campaignRepository == null)
                {
                    this.categoryRepository = new GenericRepository<Category>(context);
                }
                return categoryRepository;
            }
        }
        public void Save()
        {
            context.SaveChanges();
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
    }
}
