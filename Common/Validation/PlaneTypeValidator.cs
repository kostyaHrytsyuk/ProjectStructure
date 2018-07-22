using Common.DTO;
using FluentValidation;

namespace Common.Validation
{
    public class PlaneTypeValidator : AbstractValidator<PlaneTypeDto>
    {
        public PlaneTypeValidator()
        {
            RuleFor(pt => pt.PlaneModel).NotEmpty().MaximumLength(25);
            RuleFor(pt => pt.SeatsNumber).NotEmpty().GreaterThan(0).LessThan(1000);
            RuleFor(pt => pt.Carrying).NotEmpty().GreaterThanOrEqualTo(1000).LessThan(200000);
        }
    }
}
