namespace TransneftEnergy.Application.CurrentTransformers.GetCurrentTransformersWithExpiredVerificationDate
{
    public sealed class GetCurrentTransformersWithExpiredVerificationDateHandler : IRequestHandler<GetCurrentTransformersWithExpiredVerificationDateQuery, IReadOnlyList<GetCurrentTransformersWithExpiredVerificationDateResponse>>
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetCurrentTransformersWithExpiredVerificationDateHandler(ApplicationDbContext dbContext, IMapper mapper)
            => (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<IReadOnlyList<GetCurrentTransformersWithExpiredVerificationDateResponse>> Handle(GetCurrentTransformersWithExpiredVerificationDateQuery request, CancellationToken cancellationToken)
        {
            return await _dbContext.ElectricityMeasuringPoints
                .Where(emp => emp.ConsumptionObjectId == request.ConsumptionObjectId)
                .Select(emp => emp.CurrentTransformer)
                .Where(em => em.VerificationDate <= DateTime.UtcNow)
                .ProjectTo<GetCurrentTransformersWithExpiredVerificationDateResponse>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
        }
    }
}
