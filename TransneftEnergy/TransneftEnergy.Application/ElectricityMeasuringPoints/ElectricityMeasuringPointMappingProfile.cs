using TransneftEnergy.Application.ElectricityMeasuringPoints.CreateElectricityMeasuringPoint;

namespace TransneftEnergy.Application.ElectricityMeasuringPoints
{
    internal sealed class ElectricityMeasuringPointMappingProfile : Profile
    {
        public ElectricityMeasuringPointMappingProfile()
        {
            CreateMap<CreateElectricityMeasuringPointCommand, ElectricityMeasuringPoint>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.ConsumptionObject, opt => opt.Ignore())
                .ForMember(dest => dest.ElectricityMeter, opt => opt.Ignore())
                .ForMember(dest => dest.CurrentTransformer, opt => opt.Ignore())
                .ForMember(dest => dest.VoltageTransformer, opt => opt.Ignore());
        }
    }
}
