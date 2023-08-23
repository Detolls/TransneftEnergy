using System.Text.Json.Serialization;

namespace TransneftEnergy.Application.ElectricityMeasuringPoints.CreateElectricityMeasuringPoint
{
    public sealed record CreateElectricityMeasuringPointCommand : IRequest<int>
    {
        public string Name { get; init; }

        [JsonIgnore]
        public int ConsumptionObjectId { get; init; }

        public int ElectricityMeterId { get; init; }

        public int CurrentTransformerId { get; init; }

        public int VoltageTransformerId { get; init;  }
    }
}
