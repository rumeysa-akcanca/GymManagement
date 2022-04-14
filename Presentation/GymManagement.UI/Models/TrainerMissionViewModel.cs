using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GymManagement.Application.ViewModels.MissionViewModel;
using GymManagement.Application.ViewModels.TrainerViewModel;

namespace GymManagement.UI.Models
{
    public class TrainerMissionViewModel
    {
        public IEnumerable<TrainerQueryViewModel> Trainers { get; set; }
        public IEnumerable<MissionQueryViewModel> Missions { get; set; }

    }
}
