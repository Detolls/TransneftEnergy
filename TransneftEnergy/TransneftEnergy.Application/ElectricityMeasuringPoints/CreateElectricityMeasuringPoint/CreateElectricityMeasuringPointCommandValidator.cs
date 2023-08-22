using FluentValidation;

namespace TransneftEnergy.Application.ElectricityMeasuringPoints.CreateElectricityMeasuringPoint
{
    public sealed class CreateElectricityMeasuringPointCommandValidator : AbstractValidator<CreateElectricityMeasuringPointCommand>
    {
        public CreateElectricityMeasuringPointCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .MaximumLength(256);
        }
    }
}
