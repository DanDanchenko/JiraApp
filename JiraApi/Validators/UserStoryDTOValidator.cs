using FluentValidation;
using ToDoCosmos.BusinessLogic.Models;
namespace JiraApi.Validators
{
    public class CreateUserStoryDTOValidator : AbstractValidator<CreateUserStoryDTO>
    {
        public CreateUserStoryDTOValidator()
        {
            RuleFor(x => x.Description)
                .NotEmpty()
                .MinimumLength(3);
        }
    }
}
