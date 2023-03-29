using FluentValidation;
using ToDoCosmos.BusinessLogic.Models;

namespace JiraApi.Validators
{
    public class CreateSubtaskDTOValidator : AbstractValidator<CreateSubtaskDTO>
    {
        public CreateSubtaskDTOValidator()
        {
            RuleFor(x => x.Description)
                .NotEmpty()
                .MinimumLength(3);
        }
    }
}
