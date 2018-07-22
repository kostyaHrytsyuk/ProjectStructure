using Common.DTO;
using FluentValidation;

namespace Common.Validation
{
    public class PlaneValidator : AbstractValidator<PlaneDto>
    {
        public PlaneValidator()
        {
            RuleFor(p => p.Name).NotEmpty();
            RuleFor(p => p.PlaneTypeId).NotEmpty().GreaterThan(0);            
            RuleFor(p => p.ReleaseDate).NotEmpty();
        }
    }
}
