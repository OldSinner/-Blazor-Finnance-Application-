using FinnanceApp.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinnanceApp.Server.Services.ShopService
{
    public interface IShopService
    {
        Task<ServiceResponse<List<Shops>>> GetShopList();
        Task<bool> ShopExist(string name);
        Task<ServiceResponse<int>> AddShop(string name);
        Task<ServiceResponse<string>> DeleteShop(int id);
        Task<ServiceResponse<int>> EditShop(Shops shop);
    }
}
