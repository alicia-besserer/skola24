namespace skola24.Interfaces
{
    public interface IAbsenceRepository
    {
        Task<int> GetTotalAbsenceForSchoolAsync(string schoolName);
    }
}
