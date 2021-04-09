using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Campaign.Data.Entities
{
    [Table("tblJobs")]
    public class Job
    {
        public long JobsId { get; set; }

        public string APISnapShotSummaryID { get; set; }

        public string AgreeID { get; set; }

        public int RevisionNumber { get; set; }

        public string AgreementName { get; set; }

        public string AgreeNumber { get; set; }

        public int AvailableItemCount { get; set; }

        public DateTime DateModified { get; set; }

        public bool? Status { get; set; }
    }
}
