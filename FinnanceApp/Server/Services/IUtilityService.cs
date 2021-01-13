using FinnanceApp.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinnanceApp.Server.Services
{
    public interface IUtilityService
    {
        Task<User> GetUser();
    }
}
