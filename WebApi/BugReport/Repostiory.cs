using System.Data;
using Dapper;

namespace BugReport.Repository
{
    public class BugReportRepository
    {
        private readonly IDbConnection _connection;

        public BugReportRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public BugReportModel? GetOneById(int id)
        {
            return _connection.QueryFirstOrDefault<BugReportModel>("SELECT id, uuid, title FROM bug_report WHERE id = @id", new { id = id });
        }
    }
    public class BugReportModel
    {
        public int id { get; set; }
        public Guid uuid { get; set; }
        public string title { get; set; }
    }
}
