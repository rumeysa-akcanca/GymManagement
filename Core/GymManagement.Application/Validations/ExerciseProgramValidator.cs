using FluentValidation;
using GymManagement.Application.ViewModels.ExerciseProgramViewModel;

namespace GymManagement.Application.Validations
{
    public class ExerciseProgramValidator : AbstractValidator<ExerciseProgramCommandViewModel>
    {
        public ExerciseProgramValidator()
        {
            RuleFor(e => e.ProgramName).NotEmpty();
            RuleFor(e => e.Period).NotNull();
        }
    }
}
