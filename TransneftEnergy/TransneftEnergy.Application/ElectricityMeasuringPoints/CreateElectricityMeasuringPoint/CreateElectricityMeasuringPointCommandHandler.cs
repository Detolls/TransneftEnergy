using TransneftEnergy.Domain.Exceptions;

namespace TransneftEnergy.Application.ElectricityMeasuringPoints.CreateElectricityMeasuringPoint
{
    public sealed class CreateElectricityMeasuringPointCommandHandler : IRequestHandler<CreateElectricityMeasuringPointCommand, int>
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public CreateElectricityMeasuringPointCommandHandler(ApplicationDbContext dbContext, IMapper mapper)
            => (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<int> Handle(CreateElectricityMeasuringPointCommand request, CancellationToken cancellationToken)
        {
            await CheckCommandWithThrow(request, cancellationToken);

            var electricityMeasuringPoint = _mapper.Map<ElectricityMeasuringPoint>(request);
            _dbContext.ElectricityMeasuringPoints.Add(electricityMeasuringPoint);

            await _dbContext.SaveChangesAsync(cancellationToken);

            return electricityMeasuringPoint.Id;
        }

        private async Task CheckCommandWithThrow(CreateElectricityMeasuringPointCommand command, CancellationToken cancellationToken)
        {
            if (!await _dbContext.ConsumptionObjects.AnyAsync(co => co.Id == command.ConsumptionObjectId, cancellationToken))
                throw new EntityNotFoundException(command.ConsumptionObjectId, nameof(ConsumptionObject));

            if (!await _dbContext.ElectricityMeters.AnyAsync(co => co.Id == command.ElectricityMeterId, cancellationToken))
                throw new EntityNotFoundException(command.ConsumptionObjectId, nameof(ElectricityMeter));

            if (!await _dbContext.CurrentTransformers.AnyAsync(co => co.Id == command.CurrentTransformerId, cancellationToken))
                throw new EntityNotFoundException(command.ConsumptionObjectId, nameof(CurrentTransformer));

            if (!await _dbContext.VoltageTransformers.AnyAsync(co => co.Id == command.VoltageTransformerId, cancellationToken))
                throw new EntityNotFoundException(command.ConsumptionObjectId, nameof(VoltageTransformer));

            if (await _dbContext.ElectricityMeasuringPoints.AnyAsync(emp => emp.ElectricityMeterId == command.ElectricityMeterId))
                throw new Exception($"{nameof(ElectricityMeasuringPoint)} with {nameof(ElectricityMeasuringPoint.ElectricityMeterId)} already exists");

            if (await _dbContext.ElectricityMeasuringPoints.AnyAsync(emp => emp.CurrentTransformerId == command.CurrentTransformerId))
                throw new Exception($"{nameof(ElectricityMeasuringPoint)} with {nameof(ElectricityMeasuringPoint.CurrentTransformerId)} already exists");

            if (await _dbContext.ElectricityMeasuringPoints.AnyAsync(emp => emp.VoltageTransformerId == command.VoltageTransformerId))
                throw new Exception($"{nameof(ElectricityMeasuringPoint)} with {nameof(ElectricityMeasuringPoint.VoltageTransformerId)} already exists");
        }
    }
}
