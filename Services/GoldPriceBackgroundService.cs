using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;
using BullionRateEngine.Hubs;

namespace BullionRateEngine.Services
{
    public class GoldPriceBackgroundService : BackgroundService
    {
        private readonly IHubContext<RateHub> _hubContext;
        private readonly Random _random = new();
        public static decimal CurrentGoldPrice22K { get; private set; } = 7250.00m;

        public GoldPriceBackgroundService(IHubContext<RateHub> hubContext)
        {
            _hubContext = hubContext;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                decimal fluctuation = (decimal)(_random.NextDouble() * 10 - 5);
                CurrentGoldPrice22K = Math.Round(CurrentGoldPrice22K + fluctuation, 2);
                await _hubContext.Clients.All.SendAsync("ReceiveGoldRate", CurrentGoldPrice22K);
                await Task.Delay(5000, stoppingToken);
            }
        }
    }
}
