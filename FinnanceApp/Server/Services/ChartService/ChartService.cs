using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinnanceApp.Server.Data;
using FinnanceApp.Shared.Models;
using FinnanceApp.Shared.Models.ChartModels;
using Microsoft.EntityFrameworkCore;

namespace FinnanceApp.Server.Services.ChartService
{
    public class ChartService : IChartService
    {
        private readonly DataContext _context;
        private readonly IUtilityService _utility;

        public ChartService(DataContext context, IUtilityService utility)
        {
            _utility = utility;
            _context = context;

        }
        public async Task<ServiceResponse<List<ChartMonth>>> GetMonthChart()
        {
            var user = await _utility.GetUser();
            var list = new List<ChartMonth>();
            for (int i = 0; i < 6; i++)
            {
                double sum = 0;
                var bills = await _context.Bills.Where(x => x.BuyDate.Month == DateTime.Now.AddMonths(-i).Month && x.OwnerId==user.id).ToListAsync();
                foreach (var bill in bills)
                {
                    sum += bill.money;
                }
                list.Add(new ChartMonth
                {
                    money = sum,
                    month = DateTime.Now.AddMonths(-i).ToString("MMMM")
                });
            }
            return new ServiceResponse<List<ChartMonth>>
            {
                Data = list,
                isSuccess = true,
                Message = "Załadowano chart!"
            };

        }
    }
}