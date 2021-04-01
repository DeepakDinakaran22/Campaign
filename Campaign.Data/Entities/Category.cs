using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Campaign.Data.Entities
{
    [Table("tblCategory")]
    public class Category
    {
        public long CategoryID { get; set; }

        public string CategoryName { get; set; }

        public bool? CampaignApplicable { get; set; }

        public bool? Status { get; set; }
    }
}
