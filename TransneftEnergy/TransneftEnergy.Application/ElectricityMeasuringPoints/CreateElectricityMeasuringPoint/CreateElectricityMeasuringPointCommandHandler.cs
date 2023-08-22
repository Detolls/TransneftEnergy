using MediatR;
using TransneftEnergy.Domain.Entities;
using TransneftEnergy.Domain.Exceptions;
using TransneftEnergy.Infrastructure.Data;

namespace TransneftEnergy.Application.ElectricityMeasuringPoints.CreateElectricityMeasuringPoint
{
    public sealed class CreateElectricityMeasuringPointCommandHandler : IRequestHandler<CreateElectricityMeasuringPointCommand, int>
    {
        private readonly ApplicationDbContext _dbContext;

        public CreateElectricityMeasuringPointCommandHandler(ApplicationDbContext dbContext)
            => _dbContext = dbContext;

        public async Task<int> Handle(CreateElectricityMeasuringPointCommand request, CancellationToken cancellationToken)
        {
            var consumptionObject = await _dbContext.ConsumptionObjects.FindAsync(request.ConsumptionObjectId, cancellationToken)
                ?? throw new EntityNotFoundException(request.ConsumptionObjectId, nameof(ConsumptionObject));

            var electricityMeter = await _dbContext.ElectricityMeters.FindAsync(request.ElectricityMeterId, cancellationToken)
                ?? throw new EntityNotFoundException(request.ElectricityMeterId, nameof(ElectricityMeter));

            var currentTransformer = await _dbContext.CurrentTransformers.FindAsync(request.CurrentTransformerId, cancellationToken)
                ?? throw new EntityNotFoundException(request.CurrentTransformerId, nameof(CurrentTransformer));

            var voltageTransformer = await _dbContext.VoltageTransformers.FindAsync(request.VoltageTransformerId, cancellationToken)
                ?? throw new EntityNotFoundException(request.VoltageTransformerId, nameof(VoltageTransformer));

            var electricityMeasuringPoint = new ElectricityMeasuringPoint
            {
                Name = request.Name,
                ConsumptionObject = consumptionObject,
                ElectricityMeter = electricityMeter,
                CurrentTransformer = currentTransformer,
                VoltageTransformer = voltageTransformer
            };
            _dbContext.ElectricityMeasuringPoints.Add(electricityMeasuringPoint);

            await _dbContext.SaveChangesAsync(cancellationToken);

            return electricityMeasuringPoint.Id;
        }
    }
}
