using FluentValidation;
using ToDoCosmos.BusinessLogic.Models;

namespace JiraApi.Validators
{
    public class UpdateSubtaskDTOValidator : AbstractValidator<UpdateSubtaskDTO>
    {

        public UpdateSubtaskDTOValidator()
        {
            RuleFor(x => x.Description)
                .NotEmpty()
                .MinimumLength(3);
        }
    }
}
