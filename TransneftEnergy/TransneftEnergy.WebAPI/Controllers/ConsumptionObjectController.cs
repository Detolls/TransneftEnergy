using TransneftEnergy.Application.CurrentTransformers.GetCurrentTransformersWithExpiredVerificationDate;
using TransneftEnergy.Application.ElectricityMeasuringPoints.CreateElectricityMeasuringPoint;
using TransneftEnergy.Application.ElectricityMeters.GetElectricityMetersWithExpiredVerificationDate;
using TransneftEnergy.Application.VoltageTransformers.GetVoltageTransformersWithExpiredVerificationDate;

namespace TransneftEnergy.WebAPI.Controllers
{
    /// <summary>
    /// Объекты потребления.
    /// </summary>
    [Route("api/consumptionObjects")]
    [ApiController]
    public class ConsumptionObjectController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ConsumptionObjectController(IMediator mediator)
            => _mediator = mediator;

        /// <summary>
        /// Создать точку измерения.
        /// </summary>
        /// <param name="id">Идентификатор объекта потребления.</param>
        /// <param name="createElectricityMeasuringPointCommand">Данные для создания точки измерения.</param>
        /// <returns></returns>
        [HttpPost("{id}/electricityMeasuringPoint")]
        public async Task<int> CreateMeasurementPoint(int id, CreateElectricityMeasuringPointCommand createElectricityMeasuringPointCommand)
        {
            createElectricityMeasuringPointCommand = createElectricityMeasuringPointCommand with { ConsumptionObjectId = id };
            return await _mediator.Send(createElectricityMeasuringPointCommand);
        }

        /// <summary>
        /// Получить все счетчики с закончившимся сроком проверки.
        /// </summary>
        /// <param name="id">Идентификатор объекта потребления.</param>
        /// <returns></returns>
        [HttpGet("{id}/electricityMetersWithExpiredVerificationDate")]
        public async Task<IEnumerable<GetElectricityMetersWithExpiredVerificationDateResponse>> GetElectricityMetersWithExpiredVerificationDate(int id)
        {
            var query = new GetElectricityMetersWithExpiredVerificationDateQuery(id);
            return await _mediator.Send(query);
        }

        /// <summary>
        /// Получить все трансформаторы тока с закончившимся сроком проверки.
        /// </summary>
        /// <param name="id">Идентификатор объекта потребления.</param>
        /// <returns></returns>
        [HttpGet("{id}/currentTransformersWithExpiredVerificationDate")]
        public async Task<IEnumerable<GetCurrentTransformersWithExpiredVerificationDateResponse>> GetCurrentTransformersWithExpiredVerificationDate(int id)
        {
            var query = new GetCurrentTransformersWithExpiredVerificationDateQuery(id);
            return await _mediator.Send(query);
        }

        /// <summary>
        /// Получить все трансформаторы напряжения с закончившимся сроком проверки.
        /// </summary>
        /// <param name="id">Идентификатор объекта потребления.</param>
        /// <returns></returns>
        [HttpGet("{id}/voltageTransformersWithExpiredVerificationDate")]
        public async Task<IEnumerable<GetVoltageTransformersWithExpiredVerificationDateResponse>> GetVoltageTransformersWithExpiredVerificationDate(int id)
        {
            var query = new GetVoltageTransformersWithExpiredVerificationDateQuery(id);
            return await _mediator.Send(query);
        }
    }
}
