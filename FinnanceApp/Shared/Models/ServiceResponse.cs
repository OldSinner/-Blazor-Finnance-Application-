using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinnanceApp.Shared.Models
{
    public class ServiceResponse<T>
    {
        public T Data { get; set; }
        public bool isSuccess { get; set; } = true;
        public string Message { get; set; }
    }
}
