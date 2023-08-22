using AutoMapper;
using TransneftEnergy.Application.SettlementMeters.GetSettlementMeters;
using TransneftEnergy.Domain.Entities;

namespace TransneftEnergy.Application.SettlementMeters
{
    public sealed class SettlementMeterMappingProfile : Profile
    {
        public SettlementMeterMappingProfile() 
        {
            CreateMap<SettlementMeter, GetSettlementMetersResponse>();
        }
    }
}
