using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FinnanceApp.Shared.Models;

namespace FinnanceApp.Client.Services
{
    public interface IChartService
    {
        event Action OnChange;

        IList<string> HalfYearChartLabels { get; set; }
        IList<double> HalfYearChartValues { get; set; }
        Task GetHalfYearChartValues();

        IList<string> DoughnutChartLabels { get; set; }
        IList<double> DoughnutChartValues { get; set; }

        IList<string> ShopChartLabels { get; set; }
        IList<double> ShopChartValues { get; set; }
        Task GetDoughnutCharValues();
        Task GetShopChartValues();
        IList<Bills> bill { get; set; }
         

        Task GetBillList();
        double GetByDate(DateTime date);
        double GetDiff();

    }
}