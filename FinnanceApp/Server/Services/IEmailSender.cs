using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace FinnanceApp.Server.Services
{
    public interface IEmailSender
    {
        Task SendEmailActivate(int id, string email);

    }
}
