using Common.DTO;
using FluentValidation;

namespace Common.Validation
{
    public class CrewValidator : AbstractValidator<CrewDto>
    {
        public CrewValidator()
        {
            RuleFor(c => c.PilotId).NotEmpty().GreaterThan(0);
        }
    }
}
