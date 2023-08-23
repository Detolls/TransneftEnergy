﻿namespace TransneftEnergy.Application.CurrentTransformers.GetCurrentTransformersWithExpiredVerificationDate
{
    public sealed record GetCurrentTransformersWithExpiredVerificationDateQuery(int ConsumptionObjectId) : IRequest<IReadOnlyList<GetCurrentTransformersWithExpiredVerificationDateResponse>>;
}
