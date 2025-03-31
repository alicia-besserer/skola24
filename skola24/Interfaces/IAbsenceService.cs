using skola24.DTO;

namespace skola24.Interfaces
{
    public interface IAbsenceService
    {
        Task<TotalAbsenceDTO> GetAbsenceForSchoolAsync(string schoolName);
    }
}
