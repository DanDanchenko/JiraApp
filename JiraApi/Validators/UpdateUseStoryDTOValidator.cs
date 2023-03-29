using FluentValidation;
using ToDoCosmos.BusinessLogic.Models;

namespace JiraApi.Validators
{
    public class UpdateUserStoryDTOValidator : AbstractValidator<UpdateUserStoryDTO>
    {
        public UpdateUserStoryDTOValidator()
        {
            RuleFor(x => x.Description)
                .NotEmpty()
                .MinimumLength(3);
        }
    }
}
