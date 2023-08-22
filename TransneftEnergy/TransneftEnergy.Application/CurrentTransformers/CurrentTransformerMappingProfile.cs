using TransneftEnergy.Application.CurrentTransformers.GetCurrentTransformersWithExpiredVerificationDate;

namespace TransneftEnergy.Application.VoltageTransformers
{
    public sealed class CurrentTransformerMappingProfile : Profile
    {
        public CurrentTransformerMappingProfile() 
        {
            CreateMap<VoltageTransformer, GetCurrentTransformersWithExpiredVerificationDateResponse>();
        }
    }
}
