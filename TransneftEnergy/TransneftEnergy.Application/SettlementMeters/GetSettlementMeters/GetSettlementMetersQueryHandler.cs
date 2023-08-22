namespace TransneftEnergy.Application.SettlementMeters.GetSettlementMeters
{
    public sealed class GetSettlementMetersQueryHandler : IRequestHandler<GetSettlementMetersQuery, IReadOnlyList<GetSettlementMetersResponse>>
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetSettlementMetersQueryHandler(ApplicationDbContext dbContext, IMapper mapper)
            => (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<IReadOnlyList<GetSettlementMetersResponse>> Handle(GetSettlementMetersQuery request, CancellationToken cancellationToken)
        {
            return await _dbContext.ElectricityMeasuringPointsSettlementMeters
                .Where(empsm => empsm.StartTime >= request.StartTime && empsm.EndTime <= request.EndTime)
                .Select(empsm => empsm.SettlementMeter)
                .ProjectTo<GetSettlementMetersResponse>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
        }
    }
}
