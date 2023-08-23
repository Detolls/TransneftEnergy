using Microsoft.Extensions.DependencyInjection;

namespace TransneftEnergy.Infrastructure.Data
{
    public static class InitialiserExtensions
    {
        public static async Task InitialiseDatabaseAsync(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();

            var initialiser = scope.ServiceProvider.GetRequiredService<ApplicationDbContextInitialiser>();

            await initialiser.SeedAsync();
        }
    }

    public sealed class ApplicationDbContextInitialiser
    {
        private readonly ApplicationDbContext _context;

        public ApplicationDbContextInitialiser(ApplicationDbContext context)
            => _context = context;

        public async Task SeedAsync()
        {
            if (!_context.Organizations.Any())
            {
                _context.Organizations.Add(new Organization
                {
                    Name = "Организация",
                    Address = Guid.NewGuid().ToString()
                });

                await _context.SaveChangesAsync();
            }

            if (!_context.ChildOrganizations.Any()) 
            {
                var parentOrganization = await _context.Organizations.FirstAsync();
                _context.ChildOrganizations.Add(new ChildOrganization
                {
                    Name = "Дочерняя организация",
                    Address = Guid.NewGuid().ToString(),
                    ParentOrganization = parentOrganization
                });

                await _context.SaveChangesAsync();
            }

            if (!_context.ConsumptionObjects.Any()) 
            {
                var childOrganization = await _context.ChildOrganizations.FirstAsync();
                _context.ConsumptionObjects.Add(new ConsumptionObject
                {
                    Name = "Объект потребления",
                    Address = Guid.NewGuid().ToString(),
                    ChildOrganization = childOrganization
                });

                await _context.SaveChangesAsync();
            }

            if (!_context.ElectricityMeters.Any())
            {
                _context.ElectricityMeters.AddRange(
                    new ElectricityMeter
                    {
                        Number = Guid.NewGuid().ToString(),
                        Type = Domain.Enums.ElectricityMeterType.Electronic,
                        VerificationDate = DateTime.UtcNow.AddDays(-10)
                    },
                    new ElectricityMeter
                    {
                        Number = Guid.NewGuid().ToString(),
                        Type = Domain.Enums.ElectricityMeterType.Induction,
                        VerificationDate = DateTime.UtcNow.AddDays(10)
                    });

                await _context.SaveChangesAsync();
            }

            if (!_context.CurrentTransformers.Any()) 
            {
                _context.CurrentTransformers.AddRange(
                    new CurrentTransformer
                    {
                        Number = Guid.NewGuid().ToString(),
                        Type = Domain.Enums.CurrentTransformerType.Winding,
                        TransformationRatio = 1,
                        VerificationDate = DateTime.UtcNow.AddDays(-10)
                    },
                    new CurrentTransformer
                    {
                        Number = Guid.NewGuid().ToString(),
                        Type = Domain.Enums.CurrentTransformerType.Winding,
                        TransformationRatio = 1,
                        VerificationDate = DateTime.UtcNow.AddDays(10)
                    });

                await _context.SaveChangesAsync();
            }

            if (!_context.VoltageTransformers.Any())
            {
                _context.VoltageTransformers.AddRange(
                    new VoltageTransformer
                    {
                        Number = Guid.NewGuid().ToString(),
                        Type = Domain.Enums.VoltageTransformerType.Grounded,
                        TransformationRatio = 1,
                        VerificationDate = DateTime.UtcNow.AddDays(-10)
                    },
                    new VoltageTransformer
                    {
                        Number = Guid.NewGuid().ToString(),
                        Type = Domain.Enums.VoltageTransformerType.Ungrounded,
                        TransformationRatio = 1,
                        VerificationDate = DateTime.UtcNow.AddDays(10)
                    });

                await _context.SaveChangesAsync();
            }

            if (!_context.ElectricityMeasuringPoints.Any()) 
            {
                var consumptionObject = await _context.ConsumptionObjects.FirstAsync();
                var electricityMeters = await _context.ElectricityMeters.Take(2).ToListAsync();
                var currentTransformers = await _context.CurrentTransformers.Take(2).ToListAsync();
                var voltageTransformers = await _context.VoltageTransformers.Take(2).ToListAsync();

                for (int i = 0; i < 2; i++) 
                {
                    _context.ElectricityMeasuringPoints.Add(new ElectricityMeasuringPoint
                    {
                        Name = "Точка измерения электроэнергии",
                        ConsumptionObject = consumptionObject,
                        ElectricityMeter = electricityMeters[i],
                        CurrentTransformer = currentTransformers[i],
                        VoltageTransformer = voltageTransformers[i]
                    });
                }

                await _context.SaveChangesAsync();
            }

            if (!_context.ElectricitySupplyPoints.Any())
            {
                var consumptionObject = await _context.ConsumptionObjects.FirstAsync();
                _context.ElectricitySupplyPoints.Add(new ElectricitySupplyPoint
                {
                    Name = "Точка поставки электроэнергии",
                    MaxPower = 1000,
                    ConsumptionObject = consumptionObject,
                });

                await _context.SaveChangesAsync();
            }

            if (!_context.SettlementMeters.Any())
            {
                var electricitySupplyPoint = await _context.ElectricitySupplyPoints.FirstAsync();
                _context.SettlementMeters.Add(new SettlementMeter
                {
                    ElectricitySupplyPoint = electricitySupplyPoint
                });

                await _context.SaveChangesAsync();
            }

            if (!_context.ElectricityMeasuringPointsSettlementMeters.Any())
            {
                var settlementMeter = await _context.SettlementMeters.FirstAsync();
                var electricityMeasuringPoints = await _context.ElectricityMeasuringPoints.Take(2).ToListAsync();

                _context.ElectricityMeasuringPointsSettlementMeters.AddRange(
                    new ElectricityMeasuringPointsSettlementMeters
                    {
                        SettlementMeter = settlementMeter,
                        ElectricityMeasuringPoint = electricityMeasuringPoints[0],
                        StartTime = new DateTime(2018, 1, 1),
                        EndTime = new DateTime(2018, 12, 31)
                    },
                    new ElectricityMeasuringPointsSettlementMeters
                    {
                        SettlementMeter = settlementMeter,
                        ElectricityMeasuringPoint = electricityMeasuringPoints[1],
                        StartTime = new DateTime(2019, 1, 1),
                        EndTime = new DateTime(2020, 1, 1)
                    });

                await _context.SaveChangesAsync();
            }
        }
    }
}
