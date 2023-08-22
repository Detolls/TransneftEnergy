using TransneftEnergy.Application.ElectricityMeters.GetElectricityMetersWithExpiredVerificationDate;

namespace TransneftEnergy.Application.ElectricityMeters
{
    public sealed class ElectricityMeterMappingProfile : Profile
    {
        public ElectricityMeterMappingProfile() 
        {
            CreateMap<ElectricityMeter, GetElectricityMetersWithExpiredVerificationDateResponse>();
        }
    }
}
