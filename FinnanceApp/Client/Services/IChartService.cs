using System.Collections.Generic;
using System.Threading.Tasks;
using FinnanceApp.Shared.Models.ChartModels;

namespace FinnanceApp.Client.Services
{
    public interface IChartService
    {

        IList<ChartMonth> chartMonths {get;set;}

        Task GetMonthChart();
    }
}