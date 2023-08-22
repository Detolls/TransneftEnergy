using TransneftEnergy.Domain.Enums;

namespace TransneftEnergy.Application.ElectricityMeters.GetElectricityMetersWithExpiredVerificationDate
{
    public sealed record GetElectricityMetersWithExpiredVerificationDateResponse(
        int Id, 
        string Number, 
        ElectricityMeterType Type, 
        DateTime VerificationDate);
}
