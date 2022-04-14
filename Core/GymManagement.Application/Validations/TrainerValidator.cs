using FluentValidation;
using GymManagement.Application.ViewModels.TrainerViewModel;

namespace GymManagement.Application.Validations
{
    public class TrainerValidator :AbstractValidator<TrainerCommandViewModel>
    {
        public TrainerValidator()
        {
            RuleFor(e => e.EmployeeDetail).NotNull();
            RuleFor(e => e.WorkerContract).NotNull();
        }
    }
}
