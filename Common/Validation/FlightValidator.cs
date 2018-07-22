using Common.DTO;
using FluentValidation;

namespace Common.Validation
{
    public class FlightValidator : AbstractValidator<FlightDto>
    {
        public FlightValidator()
        {
            RuleFor(f => f.FlightNumber).NotEmpty().Matches(@"[A-Z]{2}[0-9]{4}").MinimumLength(6).MaximumLength(6);
            RuleFor(f => f.DepartureAirport).NotEmpty().MinimumLength(3).MaximumLength(3);
            RuleFor(f => f.DepartureTime).NotEmpty();
            RuleFor(f => f.DestinationAirport).NotEmpty().MinimumLength(3).MaximumLength(3);
            RuleFor(f => f.ArrivalTime).NotEmpty();
        }
    }
}
