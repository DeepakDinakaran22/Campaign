

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
        public virtual DbSet<Job> Job { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Campaign>(entity =>
            {
                entity.HasKey(e => e.ItemJobsId);

                entity.Property(e => e.ItemJobsId)
                    .HasColumnName("ItemJobsId")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ItemStartDate)
                .HasColumnName("ItemStartDate")
                .IsUnicode(false);


                entity.Property(e => e.ItemEndDate)
                .HasColumnName("ItemEndDate")
                .IsUnicode(false);

                entity.Property(e => e.AgreementName)
                    .HasColumnName("AgreementName");



                entity.Property(e => e.AgreeId)
                .HasColumnName("AgreeID")
                .IsUnicode(false);

                entity.Property(e => e.NetworkId)
                .HasColumnName("NetworkID")
                .IsUnicode(false);

            });

            modelBuilder.Entity<Job>(entity =>
            {
                entity.HasKey(e => e.JobsId);

                entity.Property(e => e.JobsId)
                      .HasColumnName("JobsId")
                      .IsUnicode(false);

                entity.Property(e => e.APISnapShotSummaryID)
                      .HasColumnName("x20APISnapShotSummaryID")
                      .IsUnicode(false);

                entity.Property(e => e.Status)
                      .HasColumnName("Status")
                      .IsUnicode(false);

                entity.Property(e => e.DateModified)
                      .HasColumnName("DateModified")
                      .IsUnicode(false);

                entity.Property(e => e.AgreeID)
                      .HasColumnName("AgreeID")
                      .IsUnicode(false);

                entity.Property(e => e.RevisionNumber)
                      .HasColumnName("RevisionNumber")
                      .IsUnicode(false);

                entity.Property(e => e.AgreementName)
                      .HasColumnName("AgreementName")
                      .IsUnicode(false);

                entity.Property(e => e.AgreeNumber)
                      .HasColumnName("AgreeNumber")
                      .IsUnicode(false);
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.CategoryID);

                entity.Property(e => e.CategoryID)
                .HasColumnName("CategoryID");

                entity.Property(e => e.CategoryName)
                .HasColumnName("CategoryName");

                entity.Property(e => e.CampaignApplicable)
                .HasColumnName("CampaignApplicable");

                entity.Property(e => e.Status)
                .HasColumnName("Status");
            });
        }
    }
}
