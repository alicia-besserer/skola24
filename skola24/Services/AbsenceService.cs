using skola24.DTO;
using skola24.Interfaces;

namespace skola24.Services
{
    public class AbsenceService : IAbsenceService
    {
        private readonly IAbsenceRepository _absenceRepository;

        public AbsenceService(IAbsenceRepository absenceRepository)
        {
            _absenceRepository = absenceRepository;

        }

        public async Task<TotalAbsenceDTO> GetAbsenceForSchoolAsync(string schoolName)
        {
           var totalAbsenceHours = await _absenceRepository.GetTotalAbsenceForSchoolAsync(schoolName);
            var totalAbsenceObject = new TotalAbsenceDTO { SchoolName = schoolName, TotalAbsence = totalAbsenceHours};

            return totalAbsenceObject;
        }
    }
}
