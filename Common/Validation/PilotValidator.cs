using Common.DTO;
using FluentValidation;

namespace Common.Validation
{
    public class PilotValidator : AbstractValidator<PilotDto>
    {
        public PilotValidator()
        {
            RuleFor(p => p.FirstName).NotEmpty().Matches(@"^[A-Z][a-z]*").MinimumLength(2).MaximumLength(20);
            RuleFor(p => p.LastName).NotEmpty().Matches(@"^[A-Z][a-z]*").MinimumLength(2).MaximumLength(20);
            RuleFor(p => p.BirthDate).NotEmpty();
            RuleFor(p => p.Exp).NotEmpty().GreaterThan(0).LessThanOrEqualTo(100);
        }
    }

}
