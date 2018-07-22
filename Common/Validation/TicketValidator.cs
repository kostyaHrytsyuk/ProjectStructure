using Common.DTO;
using FluentValidation;

namespace Common.Validation
{
    public class TicketValidator : AbstractValidator<TicketDto>
    {
        public TicketValidator()
        {
            RuleFor(t => t.FlightId).NotEmpty().GreaterThan(0);
            RuleFor(t => t.FlightNumber).NotEmpty().Matches(@"[A-Z]{2}[0-9]{4}").MinimumLength(6).MaximumLength(6);
            RuleFor(t => t.Price).NotEmpty().GreaterThan(0);
        }
    }
}
