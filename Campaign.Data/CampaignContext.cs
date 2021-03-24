

namespace Campaign.Data
{
    using Microsoft.EntityFrameworkCore;
    using Campaign.Data.Entities;
    public class CampaignContext : DbContext
    {
        public CampaignContext()
        {

        }
        public CampaignContext(DbContextOptions<CampaignContext> options) : base(options)
        {

        }
        public virtual DbSet<Campaign> Campaign { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Campaign>(entity =>
            {
                entity.HasKey(e => e.campaignId);

                entity.Property(e => e.campaignId)
                    .HasColumnName("CampaignId")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                // entity.Property(e => e.ResortId)
                // .HasColumnName("ResortId");


                // entity.Property(e => e.DisplayName)
                // .HasColumnName("DisplayName");

                // entity.Property(e => e.StartDate)
                //     .HasColumnName("StartDate")
                //     .IsUnicode(false);

                // entity.Property(e => e.EndDate)
                // .HasColumnName("EndDate")
                // .IsUnicode(false);

                // entity.Property(e => e.CreatedDate)
                // .HasColumnName("CreatedDate")
                // .IsUnicode(false);

                // entity.Property(e => e.ModifiedDate)
                //.HasColumnName("ModifiedDate")
                //.IsUnicode(false);

                // entity.Property(e => e.Deleted)
                //.HasColumnName("Deleted")
                //.IsUnicode(false);


            });
        }
    }
}
