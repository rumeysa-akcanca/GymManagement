using System;
using FluentValidation;
using GymManagement.Application.ViewModels.EquipmentViewModel;

namespace GymManagement.Application.Validations
{
    public class EquipmentValidator : AbstractValidator<EquipmentCommandViewModel>
    {
        public EquipmentValidator()
        {
            RuleFor(e => e.Name).NotEmpty().MinimumLength(3);
            RuleFor(e => e.Duration).GreaterThan(Convert.ToByte(1));
        }
    }
}
