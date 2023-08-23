namespace TransneftEnergy.Application.ElectricityMeters.GetElectricityMetersWithExpiredVerificationDate
{
    public sealed class GetElectricityMetersWithExpiredVerificationDateHandler : IRequestHandler<GetElectricityMetersWithExpiredVerificationDateQuery, IReadOnlyList<GetElectricityMetersWithExpiredVerificationDateResponse>>
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetElectricityMetersWithExpiredVerificationDateHandler(ApplicationDbContext dbContext, IMapper mapper)
            => (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<IReadOnlyList<GetElectricityMetersWithExpiredVerificationDateResponse>> Handle(GetElectricityMetersWithExpiredVerificationDateQuery request, CancellationToken cancellationToken)
        {
            return await _dbContext.ElectricityMeasuringPoints
                .Where(emp => emp.ConsumptionObjectId == request.ConsumptionObjectId)
                .Select(emp => emp.ElectricityMeter)
                .Where(em => em.VerificationDate <= DateTime.UtcNow)
                .ProjectTo<GetElectricityMetersWithExpiredVerificationDateResponse>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
        }
    }
}
