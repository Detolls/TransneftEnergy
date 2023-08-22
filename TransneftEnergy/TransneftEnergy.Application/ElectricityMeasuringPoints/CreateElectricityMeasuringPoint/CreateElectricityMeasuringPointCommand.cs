using MediatR;

namespace TransneftEnergy.Application.ElectricityMeasuringPoints.CreateElectricityMeasuringPoint
{
    public sealed record CreateElectricityMeasuringPointCommand(
        string Name, 
        int ConsumptionObjectId,
        int ElectricityMeterId, 
        int CurrentTransformerId, 
        int VoltageTransformerId) : IRequest<int>;
}
