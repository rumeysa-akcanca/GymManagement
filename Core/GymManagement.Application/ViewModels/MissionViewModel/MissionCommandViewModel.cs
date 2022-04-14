using System;

namespace GymManagement.Application.ViewModels.MissionViewModel
{
    public class MissionCommandViewModel
    {
        public DateTime EndDateTime { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}