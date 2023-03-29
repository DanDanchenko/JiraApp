using FluentValidation;
using ToDoCosmos.BusinessLogic.Models;

namespace JiraApi.Validators
{
    public class ChangeSubtaskStatusDTOValidator : AbstractValidator<ChangeSubtaskStatusDTO>
    {
        public ChangeSubtaskStatusDTOValidator()
        {
            RuleFor(x => x.Status)
                .NotEmpty()
                .MinimumLength(3);
        }
    }
}
