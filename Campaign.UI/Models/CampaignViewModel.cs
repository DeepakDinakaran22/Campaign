using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Campaign.UI.Models
{
    
    public class CampaignViewModel
    {

        public long ItemJobsId { get; set; }

        public long? JobsId { get; set; }

        public string CampaignName { get; set; }

        public string Occurrence { get; set; }
        public string ContactNumber { get; set; }

        public string DailyHourlyAvailId { get; set; }

        public string AgreeId { get; set; }

        public string APISnapShotSummaryId { get; set; }

        public string AgreeItemId { get; set; }

        public string AgreementItemProcessStatusId { get; set; }

        public string AgreementItemProcessStatus { get; set; }

        public string AgreementItem_APIProcessDescription { get; set; }

        public int RevisionNumber { get; set; }

        public int ItemRevisionNumber { get; set; }

        public string AgreementName { get; set; }

        public string AgreeNumber { get; set; }

        public string AgreementType { get; set; }

        public string AgreeDescription { get; set; }

        public string AgreementBrandName { get; set; }

        public string BrandId { get; set; }

        public string Cid { get; set; }

        public string CName { get; set; }

        public string CReference { get; set; }

        public string CReference2 { get; set; }

        public string CustomerType { get; set; }

        public string ItemName { get; set; }

        public string ItemRef { get; set; }

        public string ItemNumber { get; set; }

        public string OperatingDivision { get; set; }

        public DateTime ItemStartDate { get; set; }

        public DateTime ItemEndDate { get; set; }

        public int ItemSpotlength { get; set; }

        public int ItemSpotLoop { get; set; }

        public int ItemTotalSecondPerLoop { get; set; }

        public string CustomerISIC1 { get; set; }

        public string CustomerISIC2 { get; set; }

        public string BrandISIC1 { get; set; }

        public string BrandISIC2 { get; set; }

        public DateTime DateModified { get; set; }

        public long? CatgoryId { get; set; }

        public long? NetworkId { get; set; }

        public long? CampaignStatus { get; set; }

        public bool? Status { get; set; }
    }
}
