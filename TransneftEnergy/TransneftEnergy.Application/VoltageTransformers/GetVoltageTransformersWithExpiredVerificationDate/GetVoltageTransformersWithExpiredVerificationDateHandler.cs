namespace TransneftEnergy.Application.VoltageTransformers.GetVoltageTransformersWithExpiredVerificationDate
{
    public sealed class GetVoltageTransformersWithExpiredVerificationDateHandler : IRequestHandler<GetVoltageTransformersWithExpiredVerificationDateQuery, IReadOnlyList<GetVoltageTransformersWithExpiredVerificationDateResponse>>
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetVoltageTransformersWithExpiredVerificationDateHandler(ApplicationDbContext dbContext, IMapper mapper)
            => (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<IReadOnlyList<GetVoltageTransformersWithExpiredVerificationDateResponse>> Handle(GetVoltageTransformersWithExpiredVerificationDateQuery request, CancellationToken cancellationToken)
        {
            return await _dbContext.ElectricityMeasuringPoints
                .Where(emp => emp.ConsumptionObjectId == request.ConsumptionObjectId)
                .Select(emp => emp.VoltageTransformer)
                .Where(em => em.VerificationDate <= DateTime.UtcNow)
                .ProjectTo<GetVoltageTransformersWithExpiredVerificationDateResponse>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
        }
    }
}
