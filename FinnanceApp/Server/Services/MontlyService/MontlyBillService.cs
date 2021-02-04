using System;
using System.Threading;
using System.Threading.Tasks;
using FinnanceApp.Server.Services.BillService;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace FinnanceApp.Server.Services.MontlyService
{
    public class MontlyBillService : IHostedService
    {
        private readonly IServiceScopeFactory _scopeFactory;
        public Timer _timer;
        public MontlyBillService(IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;
        }
        public Task StartAsync(CancellationToken cancellationToken)
        {
            _timer = new Timer(test, null, TimeSpan.Zero, TimeSpan.FromSeconds(10));
            return Task.CompletedTask;

        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }

        private void test(object state)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var _montlyService = scope.ServiceProvider.GetRequiredService<IMontlyService>();
                _montlyService.AddBillsFromMontlyBill();

            }

        }
    }
}