using Microsoft.AspNetCore.Mvc;
using GiftCodeManager.Services;
using GiftCodeManager.Models;
using GiftCodeManager.Models.ViewModels;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace GiftCodeManager.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ManagerController : Controller
    {
        private readonly IManager _manager;
        public ManagerController(IManager manager)
        {
            _manager = manager;
        }

        [HttpGet]
        [ActionName("dashboard")]
        public async Task<List<ViewDashBoard>> GetDashBoard()
        {
            List<ViewDashBoard> dashboard = new List<ViewDashBoard>();
            foreach(var item in await _manager.GetCampaigns())
            {
                foreach(var item1 in await _manager.GetWinnerByCampaign(item.Campaign_Id))
                {
                    dashboard.Add(new ViewDashBoard
                    {
                        Name_Campaign = item.Campaign_Name,
                        Start_date = item.StartDate,
                        End_Date = item.EndDate,
                        Activated_Code=item.Activated_Code,
                        Qty_Gift=item.Gifts.Count,
                        Scanned=item.Barcode.Scanned,
                        Winners=item1.Winner.Count
                    });
                }
            }
            return dashboard;
        }//hiển thị danh sách campaign trên trang chính

        [HttpPost]
        [ActionName("campaign")]
        public async Task<IActionResult> addCampaign([FromBody] Campaign campaign)
        {
            if(ModelState.IsValid)
            {
                if(await _manager.AddCampaign(campaign)>0)
                {
                    return Ok("insert programsize successfuly");
                }
            }
            return BadRequest("invalid data");
        }//thêm campaign

        [HttpPost]
        [ActionName("gift")]
        public async Task<IActionResult> addGift([FromBody] Gift gift)
        {
            if (ModelState.IsValid)
            {
                if (await _manager.AddGift(gift) > 0)
                {
                    return Ok("insert gift successfuly");
                }
            }
            return BadRequest("invalid data");
        }//thêm quà tặng cho campaign

        [HttpPost, ActionName("rule")]
        public async Task<IActionResult> addRule([FromBody] Rule rule)
        {
            if (ModelState.IsValid)
            {
                if (await _manager.AddRuleOfGift(rule) > 0)
                {
                    return Ok("insert rule successfuly");
                }
            }
            return BadRequest("invalid data");
        }//thêm quy chế quà tặng

        [HttpPut,ActionName("gift")]
        public async Task<IActionResult> updateGift([FromBody]Gift gift)
        {
            if (ModelState.IsValid)
            {
                if (await _manager.UpdateGift(gift) > 0)
                {
                    return Ok("update gift successfuly");
                }
            }
            return BadRequest("invalid data");
        }//cập nhật quà tặng

        [HttpPost,ActionName("barcode")]
        public async Task<IActionResult> addBarcode([FromBody]Barcode barcode)
        {
            if(ModelState.IsValid)
            {
                if(await _manager.AddBarcode(barcode) > 0)
                {
                    return Ok("insert barcode successfuly");
                }
            }
            return BadRequest("invalid data");
        }//thêm barcode

        [HttpPost,ActionName("scanbarcode")]
        public async Task<IActionResult> scanBarcode([FromBody] Usedbarcode_Customer usedbarcode)
        {
            if(ModelState.IsValid)
            {
                if(await _manager.ScanBarcode(usedbarcode)>0)
                {
                    return Ok("scan barcode successfuly");
                }
            }
            return BadRequest("failure");
        }// quét mã barcode

        [HttpGet("{id}")]
        [ActionName("details")]
        public async Task<List<Campaign>> DetailsCampaign(int id)
        {
            return await _manager.DetailsCampaign(id);
        }//chi tiết campaign
    }
}
