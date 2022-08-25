using GiftCodeManager.Models;
using GiftCodeManager.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GiftCodeManager.Services
{
    public interface IManager
    {
        Task<User> Login(ViewLogin login);
        Task<List<Campaign>> GetCampaigns();
        Task<List<Gift>> GetWinnerByCampaign(int id);
        Task<int> AddCampaign(Campaign campaign);
        Task<int> AddGift(Gift gift);
        Task<int> UpdateGift(Gift gift);
        Task<int> AddRuleOfGift(Rule rule);
        Task<int> AddBarcode(Barcode barcode);
        Task<List<Usedbarcode_Customer>> GetBarcodeHistory();
        Task<int> ScanBarcode(Usedbarcode_Customer usedbarcode); 
        Task<List<Campaign>> DetailsCampaign(int id);
    }
    public class ManagerSvc:IManager
    {
        private readonly DataContext _context;
        public ManagerSvc(DataContext context)
        {
            _context = context;
        }
        public async Task<User> Login(ViewLogin login)
        {
            User user = new User();
            user = await _context.Users.Where(x => x.Email == login.Email && x.PassWord == login.PassWord).
                FirstOrDefaultAsync();
            if (user != null)
            {
                return user;
            }
            return null;
        }

        public async Task<List<Campaign>> GetCampaigns()
        {
            List<Campaign> campaigns = new List<Campaign>();
            campaigns= await _context.Campaigns.Include(x=>x.Barcode)
                .Include(x=>x.Gifts)
                .ToListAsync();    
            return campaigns;
        }

        public async Task<List<Gift>> GetWinnerByCampaign(int id)
        {
            List<Gift> winners = new List<Gift>();
            winners=await _context.Gifts.Where(x=>x.Campaign_Id==id).Include(x=>x.Winner).ToListAsync();
            return winners;
        }

        public async Task<int> AddCampaign(Campaign campaign)
        {
            int stt = 0;
            try
            {
                await _context.Campaigns.AddAsync(campaign);
                await _context.SaveChangesAsync();
                stt = campaign.Campaign_Id;
            }
            catch
            {
                stt = 0;
            }
            return stt;
        }

        public async Task<int> AddGift(Gift gift)
        {
            int stt = 0;
            try
            {
                await _context.Gifts.AddAsync(gift);
                await _context.SaveChangesAsync();
                stt = gift.Gift_Id;
            }
            catch
            {
                stt = 0;
            }
            return stt;
        }

        public async Task<int> AddRuleOfGift(Rule rule)
        {
            int stt = 0;
            try
            {
                await _context.Rules.AddAsync(rule);
                await _context.SaveChangesAsync();
                stt = rule.Gift_Id;
            }
            catch
            {
                stt = 0;
            }
            return stt;
        }

        public async Task<int> UpdateGift(Gift gift)
        {
            int stt = 0;
            try
            {
                _context.Gifts.Update(gift);
                await _context.SaveChangesAsync();
                stt=gift.Gift_Id;
            }
            catch
            {
                stt = 0;
            }
            return stt;
        }

        public async Task<int> AddBarcode(Barcode barcode)
        {
            int stt = 0;
            try
            {
                await _context.Barcodes.AddAsync(barcode);
                await _context.SaveChangesAsync();
                stt = barcode.Campaign_Id;
            }
            catch
            {
                stt = 0;
            }
            return stt;
        }

        public async Task<int> ScanBarcode(Usedbarcode_Customer usedbarcode)
        {// quét mã
            int stt = 0;
            try
            {
                await _context.Usedbarcode_Customers.AddAsync(usedbarcode);//thêm vào bảng lịch sử quét
                await _context.SaveChangesAsync();
                stt = usedbarcode.Customer_Id;
                if(stt >0)
                {
                    Barcode barcode=new Barcode();
                    barcode=await _context.Barcodes.Where(x=>x.Campaign_Id==usedbarcode.Barcode_Id)
                        .FirstOrDefaultAsync();
                    barcode.Scanned += 1;
                    _context.Barcodes.Update(barcode);
                    await _context.SaveChangesAsync();// cập nhật  trường scanned khi có người quét mã
                }
            }
            catch
            {
                stt = 0;
            }
            return stt;
        }

        public async Task<List<Usedbarcode_Customer>> GetBarcodeHistory()
        {// lịch sử quét mã
            List<Usedbarcode_Customer> usedbarcodes = new List<Usedbarcode_Customer>();
            usedbarcodes=await _context.Usedbarcode_Customers.ToListAsync();
            return usedbarcodes;
        }

        public async Task<List<Campaign>> DetailsCampaign(int id)
        {// chi tiết chiến dịch
            List<Campaign> details = new List<Campaign>();
            details=await _context.Campaigns.Where(x=>x.Campaign_Id == id)
                .Include(x=>x.Barcode)
                .Include(x=>x.Gifts)
                .ToListAsync();
            return details;
        }

    }
}
