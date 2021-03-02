using System.Threading.Tasks;
using Finnanceapp.Shared.Models;

namespace FinnanceApp.Client.Services
{
    public interface IAdditionalService
    {
         Task<CoronaCases> GetCoronaCases();
    }
}