using FluentValidation;
using ToDoListApi.Models;

namespace ToDoListApi.Validators
{
    public class TaskDtoValidator : AbstractValidator<TaskDto>
    {
        public TaskDtoValidator() 
        {
            RuleFor(t => t.Title)
                .NotEmpty()
                .WithMessage("Title is required!")
                .MaximumLength(70)
                .WithMessage("Title is too long.");

            RuleFor(t => t.Description)
                .MaximumLength(500)
                .WithMessage("Description is too long.");

            RuleFor(t => t.Status)
                .NotNull()
                .IsInEnum()
                .WithMessage("{PropertyName} has a range of values ​​that does not include {PropertyValue}");
        }
    }
}
