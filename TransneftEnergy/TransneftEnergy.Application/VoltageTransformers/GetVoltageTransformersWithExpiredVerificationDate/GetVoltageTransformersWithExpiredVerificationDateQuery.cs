﻿using MediatR;

namespace TransneftEnergy.Application.VoltageTransformers.GetVoltageTransformersWithExpiredVerificationDate
{
    public sealed record GetVoltageTransformersWithExpiredVerificationDateQuery(int ConsumptionObjectId) : IRequest<IReadOnlyList<GetVoltageTransformersWithExpiredVerificationDateResponse>>;
}
