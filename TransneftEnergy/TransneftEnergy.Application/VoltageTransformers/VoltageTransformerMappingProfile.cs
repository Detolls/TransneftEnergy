using TransneftEnergy.Application.VoltageTransformers.GetVoltageTransformersWithExpiredVerificationDate;
using TransneftEnergy.Domain.Entities;

namespace TransneftEnergy.Application.VoltageTransformers
{
    public sealed class VoltageTransformerMappingProfile : Profile
    {
        public VoltageTransformerMappingProfile() 
        {
            CreateMap<VoltageTransformer, GetVoltageTransformersWithExpiredVerificationDateResponse>();
        }
    }
}
