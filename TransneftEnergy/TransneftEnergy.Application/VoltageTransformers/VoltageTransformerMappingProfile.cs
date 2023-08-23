using TransneftEnergy.Application.VoltageTransformers.GetVoltageTransformersWithExpiredVerificationDate;

namespace TransneftEnergy.Application.VoltageTransformers
{
    internal sealed class VoltageTransformerMappingProfile : Profile
    {
        public VoltageTransformerMappingProfile() 
        {
            CreateMap<VoltageTransformer, GetVoltageTransformersWithExpiredVerificationDateResponse>();
        }
    }
}
