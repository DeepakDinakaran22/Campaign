using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Campaign.Business.Interfaces;
using Campaign.UI.Models;
using Microsoft.AspNetCore.Mvc;

namespace Campaign.UI.Controllers
{
    public class CampaignController : Controller
    {
        private readonly ICampaignManager campaignManager = null;

        public CampaignController(ICampaignManager campaignManager)
        {
            this.campaignManager = campaignManager;
        }

        public IActionResult List()
        {
            campaignManager.GetAllRecords();
            return View("CampaignList");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}