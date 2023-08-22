namespace TransneftEnergy.Application.CurrentTransformers.GetCurrentTransformersWithExpiredVerificationDate
{
    public sealed record GetCurrentTransformersWithExpiredVerificationDateResponse(int Id, string Number, ElectricityMeterType Type, DateTime VerificationDate);
}
