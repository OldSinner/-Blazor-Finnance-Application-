using System;
namespace Finnanceapp.Shared.Models
{
    public class CoronaCases
    {
        public int confirmed { get; set; } = 1;
        public int recovered { get; set; } = 1;
        public int critical { get; set; } = 1;
        public int deaths { get; set; } = 1;

        public DateTime lastChange { get; set; } = DateTime.Now;
        public DateTime lastUpdate { get; set; } = DateTime.Now;
    }
}