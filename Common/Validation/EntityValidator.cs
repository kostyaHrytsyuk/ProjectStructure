using Common.DTO;
using FluentValidation;

namespace Common.Validation
{
    public class EntityValidator : AbstractValidator<BaseDto> 
    {
        public EntityValidator()
        {
            RuleFor(e => e.Id).Empty();
        }
    }
}
