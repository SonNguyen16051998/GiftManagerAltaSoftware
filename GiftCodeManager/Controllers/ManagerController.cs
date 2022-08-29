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

        [HttpGet,ActionName("campaigns")]
        public async Task<List<Campaign>> GetCampaigns()
        {
            return await _manager.GetCampaigns();
        }//lấy toàn bộ chiến dịch

        [HttpGet("{id}"),ActionName("getgiftbycampaign")]
        public async Task<List<Gift>> getgiftbycampaign(int id)
        {
            return await _manager.GetWinnerByCampaign(id);
        }//quà tặng của từng chiến dịch

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

        [HttpGet,ActionName("barcodehistory")]
        public async Task<List<Usedbarcode_Customer>> BarcodeHistory()
        {
            return await _manager.GetBarcodeHistory();
        }//lịch sử quét mã.

        [HttpPut,ActionName("changepass")]
        public async Task<IActionResult> ChangePass([FromBody] ViewChangePass changePass)
        {
            if (ModelState.IsValid)
            {
                if (await _manager.isPass(changePass.email, changePass.password))// kiểm tra mật khẩu củ đúng hay sai
                {
                    await _manager.ChangePass(changePass);
                    return Ok("change pass successfuly");
                }
                return BadRequest("old password do not match");
            }
            return BadRequest("invalid data");
        }

        [HttpGet,ActionName("rule")]
        public async Task<List<Rule>> GetRules()
        {
            return await _manager.GetRules();
        }//hiển thị toàn bộ rule
        [HttpGet,ActionName("customers")]
        public async Task<List<Customer>> GetCustomers()
        {
            return await _manager.GetCustomers();
        }//hiển thị toàn bộ khách hàng
    }
}
