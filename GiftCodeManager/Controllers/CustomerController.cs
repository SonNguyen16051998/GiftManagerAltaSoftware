using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using GiftCodeManager.Models;
using GiftCodeManager.Models.ViewModels;
using GiftCodeManager.Services;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;

namespace GiftCodeManager.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    [Authorize]
    public class CustomerController : Controller
    {
        private readonly ICustomer _customer;

        public CustomerController(ICustomer customer)
        {
            _customer = customer;
        }

        [AllowAnonymous]
        [HttpPost]
        [ActionName("register")]
        public async Task<IActionResult> Register([FromBody]Customer custom)
        {
            if(ModelState.IsValid)
            {
                int stt=await _customer.Register(custom);
                if(stt==0)
                {
                    return BadRequest("Register failure");
                }
                else
                {
                    return Ok("Register successfuly");
                }
            }
            return BadRequest("Invalid Data");
        }//đăng kí thành viên

        [HttpPut]
        [ActionName("spin")]
        public async Task<IActionResult> Spin([FromBody] ViewSpin spin)
        {
            bool stt=await _customer.SpinLucky(spin);
            if(stt)
            {
                return Ok("Bạn đã mất một lượt quay");
            }
           else
           {
                return BadRequest("Bạn không có lượt quay");
           }
            
        }// tham gia quay vòng quay
        [HttpGet]
        [ActionName("getallwinner")]
        public async Task<List<Winner>> GetAllWinner()
        {
            return await _customer.GetAllWinner();
        }//hiển thị danh sách người thắng cuộc

        [HttpGet("{id}")]
        [ActionName("getgiftbyid")]
        public async Task<List<Winner>> GetAllWinner(int id)
        {
            return await _customer.GetAllGiftByID(id);
        }//hiên thị danh sách quà tặng theo id khách hàng

        [HttpPut,ActionName("profile")]
        public async Task<IActionResult> UpdateProfile([FromBody] Customer customer)
        {
            if(ModelState.IsValid)
            {
                await _customer.UpdateProfile(customer);
                return Ok("Update profile successfuly");
            }
            return BadRequest("invalid data");
        }// cập nhật thông tin cá nhân
    }
}
