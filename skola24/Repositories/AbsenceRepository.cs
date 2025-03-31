using skola24.Interfaces;
using Microsoft.Data.SqlClient;

namespace skola24.Repositories
{
    public class AbsenceRepository : IAbsenceRepository
    {
        private readonly string _connectionString;
      public AbsenceRepository(IConfiguration configuration) {

            _connectionString = configuration.GetConnectionString("SQLExpress") ?? throw new InvalidOperationException("Missing connection string");
        }
        public async Task<int> GetTotalAbsenceForSchoolAsync(string schoolName)
        {
            using var sqlConnection = new SqlConnection(_connectionString);
            using var sqlCommand = new SqlCommand("sp_CalculateTotalAbsenceForSchool", sqlConnection)
            {
                CommandType = System.Data.CommandType.StoredProcedure
            };
            sqlCommand.Parameters.AddWithValue("@SchoolName", schoolName);
            await sqlConnection.OpenAsync();
            var result = await sqlCommand.ExecuteScalarAsync();

            var totalAbsenceHours = result != DBNull.Value ? Convert.ToInt32(result) : 0;
            return totalAbsenceHours;
        }
    }
}
