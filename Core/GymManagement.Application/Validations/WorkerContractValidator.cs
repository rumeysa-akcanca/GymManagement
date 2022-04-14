using FluentValidation;
using GymManagement.Domain.Entities;

namespace GymManagement.Application.Validations
{
    public class WorkerContractValidator :AbstractValidator<WorkerContract>
    {
        public WorkerContractValidator()
        {
            RuleFor(w => w.Duration).NotEmpty();
            RuleFor(w => w.UpdateDate).NotEmpty();
            RuleFor(w => w.EndDate).NotEmpty();
        }
    }
}
