using ShelterApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShelterApp.Services
{
    public interface IStudyService
    {
        IEnumerable<Study> GetStudies();
        Study GetStudy(long id);
        void CreateStudy(Study study);
        void UpdateStudy(long id, Study study);
        void DeleteStudy(long id);
    }
}
