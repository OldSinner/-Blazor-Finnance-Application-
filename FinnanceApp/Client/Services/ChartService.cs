using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using FinnanceApp.Shared.Models;
using FinnanceApp.Shared.Models.ChartModels;

namespace FinnanceApp.Client.Services
{
    public class ChartService : IChartService
    {
        private readonly HttpClient _http;

        public IList<string> mLabels { get; set; } = new List<string>();
        public IList<double> mValue { get; set; } = new List<double>();
        public ChartService(HttpClient http)
        {
            _http = http;
        }
        public async Task GetMonthChart()
        {
            mLabels.Clear();
            mValue.Clear();
            var response = await _http.GetFromJsonAsync<ServiceResponse<List<ChartMonth>>>("api/Chart");
            if (response.isSuccess)
            {
                response.Data.Reverse();
                foreach (var obj in response.Data)
                {
                  mLabels.Add(obj.month);
                  mValue.Add(obj.money);
                }
            }
        }
    }
}