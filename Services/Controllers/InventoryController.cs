using Microsoft.AspNetCore.Mvc;
using System;
using BullionRateEngine.Services;

namespace BullionRateEngine.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InventoryController : ControllerBase
    {
        [HttpGet("calculate-valuation")]
        public IActionResult GetLiveValuation([FromQuery] decimal weightInGrams, [FromQuery] decimal makingCharges)
        {
            decimal liveRate = GoldPriceBackgroundService.CurrentGoldPrice22K;
            decimal goldCost = weightInGrams * liveRate;
            decimal totalValuation = goldCost + makingCharges;

            return Ok(new
            {
                Timestamp = DateTime.UtcNow,
                LiveGoldRatePerGram = liveRate,
                ItemWeight = weightInGrams,
                MakingFee = makingCharges,
                FinalStoreValue = Math.Round(totalValuation, 2)
            });
        }
    }
}
