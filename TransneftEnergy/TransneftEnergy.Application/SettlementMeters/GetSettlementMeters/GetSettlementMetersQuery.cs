namespace TransneftEnergy.Application.SettlementMeters.GetSettlementMeters
{
    public sealed record GetSettlementMetersQuery(DateTime? StartTime, DateTime? EndTime) : IRequest<IReadOnlyList<GetSettlementMetersResponse>>;
}
