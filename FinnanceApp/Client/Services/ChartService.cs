using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using FinnanceApp.Shared.Models;

namespace FinnanceApp.Client.Services
{
    public class ChartService : IChartService
    {
        private readonly HttpClient _http;
        public ChartService(HttpClient http)
        {
            _http = http;

        }
        public event Action OnChange;
        void ChartChanged() => OnChange.Invoke();


        public IList<string> HalfYearChartLabels { get; set; } = new List<string>();
        public IList<double> HalfYearChartValues { get; set; } = new List<double>();
        public IList<string> DoughnutChartLabels { get; set; } = new List<string>();
        public IList<double> DoughnutChartValues { get; set; } = new List<double>();
        

        public async Task GetDoughnutCharValues()
        {
            DoughnutChartLabels.Clear();
            DoughnutChartValues.Clear();
            var result = await _http.GetFromJsonAsync<ServiceResponse<List<SumByPerson>>>("api/Chart/GetSumBillsByPerson");
            var list = result.Data;
            foreach (var obj in list)
            {
                if(obj.money==0)continue;
                DoughnutChartLabels.Add(obj.person);
                DoughnutChartValues.Add(obj.money);
            }
        }

        public async Task GetHalfYearChartValues()
        {
            HalfYearChartLabels.Clear();
            HalfYearChartValues.Clear();
            var result = await _http.GetFromJsonAsync<ServiceResponse<List<SumByMonth>>>("api/Chart/GetSumBillsByMonth");
            var list = result.Data;
            list.Reverse();
            foreach (var obj in list)
            {
                HalfYearChartLabels.Add(obj.month);
                HalfYearChartValues.Add(obj.money);
            }
        }
        public IList<Bills> bill { get; set; } = new List<Bills>();
        public IList<string> ShopChartLabels { get; set; } = new List<string>();
        public IList<double> ShopChartValues { get; set; } = new List<double>();

        public async Task GetBillList()
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<List<Bills>>>("api/Bill/GetBill");
            bill = result.Data;
        }
        public double GetByDate(DateTime date)
        {
            Console.WriteLine(date.ToString());
            double sum=0;
            foreach(var b in bill)
            {
                if(b.BuyDate >= date)
                sum += b.money;
            }
            return Math.Round(sum,2);
        }
        

        public double GetDiff()
        {
            double sum1 = 0;
            
            double sum2 = 0;
            foreach(var b in bill)
            {
                if(b.BuyDate.Month == DateTime.Now.Month)
                sum1 += b.money;
                else if (b.BuyDate.Month == DateTime.Now.AddMonths(-1).Month )
                sum2 += b.money;
            }
            return Math.Round(sum2-sum1,2);
        }

        public async Task GetShopChartValues()
        {
            ShopChartLabels.Clear();
            ShopChartValues.Clear();
            var result = await _http.GetFromJsonAsync<ServiceResponse<List<SumByShop>>>("api/Chart/GetSumByShop");
            var list = result.Data;
            list.Reverse();
            foreach (var obj in list)
            {
                ShopChartLabels.Add(obj.shop);
                ShopChartValues.Add(obj.money);
            }
        }
    }
}