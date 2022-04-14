using FluentValidation;
using GymManagement.Domain.Entities;

namespace GymManagement.Application.Validations
{
    public class EmployeeDetailValidator : AbstractValidator<EmployeeDetail>
    {
        public EmployeeDetailValidator()
        {
            RuleFor(e => e.FirstName).NotEmpty().MinimumLength(2);
            RuleFor(e => e.LastName).NotEmpty();
            RuleFor(e => e.InsuranceNumber).MinimumLength(10).MaximumLength(12);
            RuleFor(e => e.Salary).GreaterThanOrEqualTo(4200);
        }
    }
}
