using TransneftEnergy.Domain.Enums;

namespace TransneftEnergy.Application.VoltageTransformers.GetVoltageTransformersWithExpiredVerificationDate
{
    public sealed record GetVoltageTransformersWithExpiredVerificationDateResponse(int Id, string Number, ElectricityMeterType Type, DateTime VerificationDate);
}
