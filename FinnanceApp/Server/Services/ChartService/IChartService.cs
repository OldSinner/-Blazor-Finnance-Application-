
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FinnanceApp.Shared.Models;

namespace FinnanceApp.Server.Services.ChartService
{
    public interface IChartService
    {
        Task<ServiceResponse<List<SumByMonth>>> GetSumBillsByMonth();
        Task<ServiceResponse<List<SumByPerson>>> GetSumByPerson();
        Task<ServiceResponse<List<SumByShop>>> GetSumByShop();
    }
}