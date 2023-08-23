using MediatR;
using Microsoft.AspNetCore.Mvc;
using TransneftEnergy.Application.SettlementMeters.GetSettlementMeters;

namespace TransneftEnergy.WebAPI.Controllers
{
    /// <summary>
    /// Расчетные приборы учета.
    /// </summary>
    [Route("api/settlementMeters")]
    [ApiController]
    public class SettlementMeterController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SettlementMeterController(IMediator mediator)
            => _mediator = mediator;

        /// <summary>
        /// Получить расчетные приборы учета.
        /// </summary>
        /// <param name="query">Данные запроса.</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<GetSettlementMetersResponse>> GetSettlementMeters([FromQuery] GetSettlementMetersQuery query) =>
           await _mediator.Send(query);
    }
}
