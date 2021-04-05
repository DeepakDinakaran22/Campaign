using Microsoft.SqlServer.Types;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Campaign.Data.Entities
{
    [Table("tblNetwork")]
    public class Network
    {
        public long NetworkId { get; set; }
        public SqlHierarchyId Level { get; set; }

        public string NetworkName { get; set; }


}
}
