using Common.DTO;
using FluentValidation;

namespace Common.Validation
{
    public class DepartureValidator : AbstractValidator<DepartureDto>
    {
        public DepartureValidator()
        {
            RuleFor(d => d.FlightNumber).NotEmpty().Matches(@"[A-Z]{2}[0-9]{4}").MinimumLength(6).MaximumLength(6);
        }
    }
}
