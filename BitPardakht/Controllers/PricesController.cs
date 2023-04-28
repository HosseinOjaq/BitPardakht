using Data.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace BitPardakht.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PricesController : ControllerBase
    {
        private readonly IPriceAccessWrapperRepository servicePrices;

        public PricesController(IPriceAccessWrapperRepository servicePrices)
        {
            this.servicePrices = servicePrices;
        }


        [HttpGet(nameof(GetPrices))]
        public async Task<ActionResult> GetPrices(CancellationToken cancellationToken)
        {
            var result = await servicePrices.GetPrices(cancellationToken);
            return Ok(result);
        }
    }
}
