using FluentValidation;
using GymManagement.Application.ViewModels.MissionViewModel;

namespace GymManagement.Application.Validations
{
    public class MissionValidator :AbstractValidator<MissionCommandViewModel>
    {
        public MissionValidator()
        {
            RuleFor(m => m.Description).MinimumLength(25).NotEmpty();
            RuleFor(m => m.Title).NotEmpty();
            RuleFor(m => m.EndDateTime).NotEmpty();
        }
    }
}
