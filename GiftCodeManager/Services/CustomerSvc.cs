using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GiftCodeManager.Models;
using GiftCodeManager.Helper;
using GiftCodeManager.Models.ViewModels;

namespace GiftCodeManager.Services
{
    public interface ICustomer
    {
        Task<Customer> Login(ViewLogin login);
        Task<int> Register(Customer customer);
        Task<bool> SpinLucky(ViewSpin spin);
        Task<List<Winner>> GetAllWinner();
        Task<List<Winner>> GetAllGiftByID(int id);
        Task<int> UpdateProfile(Customer customer);//cập nhật thông tin cá nhân
        Task<int> ChangePass(ViewChangePass changePass);// đổi mật khẩu
        Task<bool> isPass(string email,string pass);// kiểm tra mataj khẩu củ
        Task<bool> isEmail(string email);// kiểm tra email có tồn tại hay không
    }
    public class CustomerSvc:ICustomer
    {
        private readonly DataContext _context;
        public CustomerSvc(DataContext context)
        {
            _context = context;
        }
        public async Task<Customer> Login(ViewLogin login)
        {
            Customer customer = new Customer();
            customer= await _context.Customers.Where(x=>x.email==login.Email && 
                x.Password== login.PassWord).FirstOrDefaultAsync();
            if(customer!=null)
            {
                return customer;
            }
            return null;
        }

        public async Task<int> Register(Customer customer)
        {
            int stt = 0;
            try
            {
                await _context.AddAsync(customer);
                await _context.SaveChangesAsync();
                stt = customer.Customer_Id;
            }
            catch
            {
                stt = 0;
            }
            return stt;
        }

        public async Task<bool> SpinLucky(ViewSpin spin)//quay vòng quay may mắn
        {
            Customer cus=new Customer(); 
            cus = await _context.Customers.Where(x => x.Customer_Id == spin.IdCus).FirstOrDefaultAsync();
            if(cus.Spin_Number<1) // kiểm tra người dùng còn vòng quay hay không
            {
                return false;
            }
            else
            {
                cus.Spin_Number -= 1;
                _context.Update(cus);
                await _context.SaveChangesAsync();//cập nhật trừ đi 1 vòng quay của người dùng
                if (spin.IdGift > 0) //
                {
                    Gift gift=new Gift();
                    gift=await _context.Gifts.Where(x=>x.Gift_Id == spin.IdGift).FirstOrDefaultAsync();
                    gift.Code_Count -= 1; // nếu trúng thưởng trừ đi số lượng quà tặng
                    _context.Update(gift);
                    await _context.SaveChangesAsync();
                    Winner winner = new Winner();
                    winner.Customer_Id = spin.IdCus;
                    winner.Gift_Id = spin.IdGift;
                    winner.Win_Date = DateTime.Now;
                    winner.Sent_Gift_Status = false;
                    await _context.Winners.AddAsync(winner);
                    await _context.SaveChangesAsync();
                }
                return true;
            }
            
        }

        public async Task<List<Winner>> GetAllWinner()
        {
            List<Winner> listCus=new List<Winner>();
            listCus = await _context.Winners.OrderByDescending(x => x.Win_Date)
                .Include(x => x.Customer)
                .Include(x => x.Gift)
                .ToListAsync();
            return listCus;
        }
        public async Task<List<Winner>> GetAllGiftByID(int id)
        {// hiển thị theo id khachsh hàng
            List<Winner> listCus = new List<Winner>();
            listCus = await _context.Winners.Where(x=>x.Customer_Id==id)
                .Include(x => x.Customer)
                .Include(x => x.Gift)
                .ToListAsync();
            return listCus;
        }
        public async Task<int> UpdateProfile(Customer customer)// cập nhtaj trang cá nhân
        {
            int stt = 0;
            try
            {
                _context.Customers.Update(customer);
                await _context.SaveChangesAsync();
                stt=customer.Customer_Id;
            }
            catch
            {
                stt=0;
            }
            return stt;
        }

        public async Task<int> ChangePass(ViewChangePass changePass)
        {
            int stt = 0;
            try
            {
                Customer cus=_context.Customers.Where(x=>x.email==changePass.email).FirstOrDefault();
                cus.Password = changePass.newPassword;
                _context.Customers.Update(cus);
                await _context.SaveChangesAsync();
                stt = cus.Customer_Id;
            }
            catch
            {
                stt = 0;
            }
            return stt;
        }

        public async Task<bool> isPass(string email,string pass)
        {
            bool ret=false;
            try
            {
                Customer cus =await _context.Customers.Where(x => x.email == email && x.Password==pass)
                    .FirstOrDefaultAsync();
                if(cus!=null)
                {
                    ret=true;
                }
                else
                {
                    ret=false;
                }
            }
            catch
            {
                ret = false;
            }
            return ret;
        }

        public async Task<bool> isEmail(string email)
        {
            bool ret = false;
            try
            {
                Customer cus = await _context.Customers.Where(x => x.email == email).FirstOrDefaultAsync();
                if (cus != null)
                {
                    ret = true;
                }
                else
                {
                    ret=false;
                }
            }
            catch
            {
                ret = false;
            }
            return ret;
        }
    }
}
