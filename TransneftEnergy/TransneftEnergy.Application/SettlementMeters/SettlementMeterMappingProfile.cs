using TransneftEnergy.Application.SettlementMeters.GetSettlementMeters;

namespace TransneftEnergy.Application.SettlementMeters
{
    internal sealed class SettlementMeterMappingProfile : Profile
    {
        public SettlementMeterMappingProfile() 
        {
            CreateMap<SettlementMeter, GetSettlementMetersResponse>();
        }
    }
}
