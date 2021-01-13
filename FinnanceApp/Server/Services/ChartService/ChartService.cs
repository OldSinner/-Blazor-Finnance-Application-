using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinnanceApp.Server.Data;
using FinnanceApp.Server.Services.PersonService;
using FinnanceApp.Server.Services.ShopService;
using FinnanceApp.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace FinnanceApp.Server.Services.ChartService
{
    public class ChartService : IChartService
    {
        private readonly IUtilityService _utilityService;
        private readonly DataContext _context;
        private readonly IPersonService _personService;
        private readonly IShopService _shopService;

        public ChartService(IUtilityService utilityService, DataContext context, IPersonService personService, IShopService shopService)
        {
            _shopService = shopService;
            _personService = personService;
            _utilityService = utilityService;
            _context = context;
        }

        public async Task<ServiceResponse<List<SumByMonth>>> GetSumBillsByMonth()
        {
            var sums = new List<SumByMonth>();
            var user = await _utilityService.GetUser();
            for (int i = 0; i < 4; i++)
            {
                var datetimenow = DateTime.Now.AddMonths(-i);
                var bills = await _context.Bills.Where(x => x.OwnerId == user.id
                && x.BuyDate.Month == datetimenow.Month
                && x.BuyDate.Year == datetimenow.Year
              ).ToListAsync();
                double sum = 0;
                foreach (var bill in bills)
                {
                    sum += bill.money;
                }
                sums.Add(new SumByMonth
                {
                    money = Math.Round(sum,2),
                    month = datetimenow.ToString("MMMM")
                });
            }
            return new ServiceResponse<List<SumByMonth>>
            {
                Data = sums,
                isSuccess = true,
                Message = "Pobrano listę rachunków"
            };
        }

        public async Task<ServiceResponse<List<SumByPerson>>> GetSumByPerson()
        {
            var sums = new List<SumByPerson>();
            var personlist = await _personService.GetPersonList();
            foreach (var person in personlist.Data)
            {
                double sum = 0;
                var bills = await _context.Bills.Where(x => x.PersonId == person.id
                && x.BuyDate.Month == DateTime.Now.Month
                && x.BuyDate.Year == DateTime.Now.Year
                 ).ToListAsync();
                foreach (var bill in bills)
                {
                    sum += bill.money;
                }
                sums.Add(new SumByPerson
                {
                    money = Math.Round(sum,2),
                    person = person.name

                });
            }
            return new ServiceResponse<List<SumByPerson>>
            {
                Data = sums,
                isSuccess = true,
                Message = "Załadowano Rachunki na podstawie osób"
            };

        }

        public async Task<ServiceResponse<List<SumByShop>>> GetSumByShop()
        {
            var sums = new List<SumByShop>();
            var shoplist = await _shopService.GetShopList();
            foreach (var shop in shoplist.Data)
            {
                double sum = 0;
                var bills = await _context.Bills.Where(x => x.ShopId == shop.id
                && x.BuyDate.Month == DateTime.Now.Month
                && x.BuyDate.Year == DateTime.Now.Year
                 ).ToListAsync();
                foreach (var bill in bills)
                {
                    sum += bill.money;
                }
                if(sum == 0) continue;
                sums.Add(new SumByShop
                {
                    money = Math.Round(sum,2),
                    shop = shop.name

                });
            }
            return new ServiceResponse<List<SumByShop>>
            {
                Data = sums,
                isSuccess = true,
                Message = "Załadowano Rachunki na podstawie osób"
            };
        }
    }
}