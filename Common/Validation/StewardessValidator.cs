using Common.DTO;
using FluentValidation;

namespace Common.Validation
{
    public class StewardessValidator : AbstractValidator<StewardessDto>
    {
        public StewardessValidator()
        {
            RuleFor(s => s.FirstName).NotEmpty().Matches(@"[A-Z][a-z]*").MinimumLength(2).MaximumLength(20);
            RuleFor(s => s.LastName).NotEmpty().Matches(@"[A-Z][a-z]*").MinimumLength(2).MaximumLength(20);
            RuleFor(s => s.BirthDate).NotEmpty();
        }
    }
}
