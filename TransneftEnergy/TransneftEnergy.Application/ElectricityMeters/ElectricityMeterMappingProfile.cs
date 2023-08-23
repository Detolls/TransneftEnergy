using TransneftEnergy.Application.ElectricityMeters.GetElectricityMetersWithExpiredVerificationDate;

namespace TransneftEnergy.Application.ElectricityMeters
{
    internal sealed class ElectricityMeterMappingProfile : Profile
    {
        public ElectricityMeterMappingProfile() 
        {
            CreateMap<ElectricityMeter, GetElectricityMetersWithExpiredVerificationDateResponse>();
        }
    }
}
