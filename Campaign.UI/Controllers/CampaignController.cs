using System;
using System.Collections.Generic;

namespace Campaign.UI.Controllers
{
    using AutoMapper;
    using Campaign.Business.Interfaces;
    using Campaign.Data;
    using Campaign.Data.Entities;
    using Campaign.UI.Models;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    using System.Diagnostics;
    using System.Linq;
    public class CampaignController : Controller
    {
        private readonly ICampaignManager campaignManager = null;
        private readonly IMapper mapper = null;
        private UnitOfWork unitOfWork = new UnitOfWork();

        public CampaignController(ICampaignManager campaignManager)
        {
            this.campaignManager = campaignManager;

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CampaignViewModel, Campaign>();
                cfg.CreateMap<Campaign, CampaignViewModel>()
                    .ForMember(destination => destination.TaskId,
                      map => map.MapFrom(
                          source => source.CampaignStatus));
            });
            mapper = config.CreateMapper();
        }

        [HttpPost]
        public void CreateCampaign(CampaignViewModel campaign)
        {
            // For testing after binding ui please remove
            //campaign.CName = "Test";
            //campaign.CampaignName = "Test";
            //campaign.ContactNumber = "123456789";
            //campaign.Occurrence = "daiy";
            //campaign.ItemStartDate = DateTime.Now;
            //campaign.ItemEndDate = DateTime.Now;

            campaign.DateModified = DateTime.Now;
            campaign.CatgoryId = unitOfWork.CategoryRepository.Get().Where(x => x.CategoryName == "FOC").FirstOrDefault().CategoryID;

            var destination = mapper.Map<CampaignViewModel, Campaign>(campaign);
            unitOfWork.CampaignRepository.Insert(destination);
            unitOfWork.Save();
        }

        [HttpPost]
        public void UpdateCampaign(CampaignViewModel campaign)
        {
            var destination = mapper.Map<CampaignViewModel, Campaign>(campaign);
            destination.DateModified = DateTime.Now;
            destination.CatgoryId = unitOfWork.CategoryRepository.Get().Where(x => x.CategoryName == "FOC").FirstOrDefault().CategoryID;
            unitOfWork.CampaignRepository.Update(destination);
            unitOfWork.Save();
        }

        [HttpGet]
        public Campaign GetCampaign(long campaignId)
        {
            return unitOfWork.CampaignRepository.GetByID(campaignId);
        }

        [HttpGet]
        public IActionResult List(long networkId = 0)
        {

            var nwId = Convert.ToInt64(new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("AppSettings")["NetworkId"]);
            networkId = networkId == 0 ? nwId : networkId;
            var data = unitOfWork.CampaignRepository.Get().ToList();
            if (networkId != 0)
                data = data.Where(x => x.NetworkId == networkId).ToList();
            ViewBag.datasource = mapper.Map<List<CampaignViewModel>>(data);
            ViewBag.category = unitOfWork.CategoryRepository.Get().ToList();
            ViewBag.status = unitOfWork.StatusRepository.Get().ToList();
            ViewBag.agreement = unitOfWork.JobRepository.Get().ToList();
            ViewBag.filterCampaign = data;

            List<ResourceDataSourceModel> categories = new List<ResourceDataSourceModel>();
            categories.Add(new ResourceDataSourceModel { text = "Added", id = 5, groupId = 1, color = "#df5286" });
            categories.Add(new ResourceDataSourceModel { text = "Started", id = 2, groupId = 2, color = "#7fa900" });
            categories.Add(new ResourceDataSourceModel { text = "Approved", id = 1, groupId = 3, color = "#ea7a57" });
            ViewBag.Categories = categories;

            ViewBag.Resources = new string[] { "Categories" };

            var result = unitOfWork.NetworkRepository.Get()
                    .OrderBy(e => e.Level)
                    .ToList();

            List<object> listdata = new List<object>();
            foreach (var resultv in result)
            {
                //Get root network
                if (resultv.Level.GetLevel() == 1)
                {
                    listdata.Add(new
                    {
                        id = resultv.NetworkId,
                        name = resultv.NetworkName,
                        hasChild = true,
                        expanded = true
                    });
                }
                else
                {
                    //Check if it has child then make  hasChild = true
                    if (unitOfWork.NetworkRepository.Get()
    .Where(e => (bool)(e.Level.GetAncestor(1) == resultv.Level))
    .ToList().Count > 0)
                    {
                        listdata.Add(new
                        {
                            id = resultv.NetworkId,
                            name = resultv.NetworkName,
                            pid = unitOfWork.NetworkRepository.Get()
                            .FirstOrDefault(e => (bool)(e.Level == resultv.Level.GetAncestor(1))).NetworkId,
                            hasChild = true,
                            expanded = false
                        });
                    }
                    //It doesnot have any child
                    else
                    {
                        listdata.Add(new
                        {
                            id = resultv.NetworkId,
                            name = resultv.NetworkName,
                            pid = unitOfWork.NetworkRepository.Get()
   .FirstOrDefault(e => (bool)(e.Level == resultv.Level.GetAncestor(1))).NetworkId
                        });
                    }
                }

            }


            ViewBag.treeSource = listdata;
            return View("CampaignList");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}