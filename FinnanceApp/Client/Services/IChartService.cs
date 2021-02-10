using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinnanceApp.Client.Services
{
    public interface IChartService
    {

        IList<string> mLabels { get; set; }
        IList<double> mValue { get; set; }

        Task GetMonthChart();
    }
}