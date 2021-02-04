using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using FinnanceApp.Server.Data;
using FinnanceApp.Shared.Models;

namespace FinnanceApp.Server.Services.MontlyService
{
    public class MontlyService : IMontlyService
    {
        private readonly DataContext _context;

        public MontlyService(DataContext context)
        {
            _context = context;
        }
        public async Task<ServiceResponse<string>> AddMontlyBill(MontlyBills bill)
        {
            await _context.MontlyBills.AddAsync(bill);
            await _context.SaveChangesAsync();
            return new ServiceResponse<string>{
            Data = "ok",
            isSuccess=true,
            Message="Usunięto rachunek miesięczny!"
            };

        }

        public async Task<ServiceResponse<string>> DeleteMontlyBill(MontlyBills bill)
        {
            var dBill = await _context.MontlyBills.Where(x => x.id == bill.id).FirstOrDefaultAsync();
            _context.MontlyBills.Remove(dBill);
            await _context.SaveChangesAsync();
            return new ServiceResponse<string>{
            Data = "ok",
            isSuccess=true,
            Message="Usunięto rachunek miesięczny!"
            };
        }

        public async Task<ServiceResponse<string>> EditMontyBill(MontlyBills bill)
        {
            var dBill = await _context.MontlyBills.Where(x => x.id == bill.id).FirstOrDefaultAsync();
            _context.MontlyBills.Update(bill);
            await _context.SaveChangesAsync();
            return new ServiceResponse<string>{
            Data = "ok",
            isSuccess=true,
            Message="Zedytowano rachunek miesięczny"
            };
        }
    }
}