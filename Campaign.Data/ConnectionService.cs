using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Campaign.Data
{
    public class ConnectionService
    {
        public static string connstring = "";
        public static void Set(IConfiguration config)
        {
            connstring = config.GetConnectionString("CampaignConnection");
        }
    }
}
