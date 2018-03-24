using ShelterApp.Models;
using ShelterApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShelterApp.Services
{
    public interface IApplyService
    {
        IEnumerable<Apply> GetApplications();
        IEnumerable<Apply> GetApplicationsForUser(int id);
        Apply GetApplication(int id);
        void CreateApplication(ApplicationCreateDTO application);
        void UpdateApplicaton(int id, Apply application);
        void DeleteApplication(int id);
    }
}
