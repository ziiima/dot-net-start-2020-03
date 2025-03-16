using Microsoft.AspNetCore.Mvc;
using System;
using BugReport.Repository;

namespace BugReport.Controllers
{
    [ApiController]
    [Route("/bug-reports")]
    public class BugReportController : ControllerBase
    {
        private readonly IServiceProvider _serviceProvider; // IServiceProvider をフィールドとして保持

        public BugReportController(IServiceProvider serviceProvider) // コンストラクタでインジェクション
        {
            _serviceProvider = serviceProvider;
        }

        [HttpGet]
        public IActionResult GetBugReports()
        {
            var repository = _serviceProvider.GetService<BugReportRepository>();
            int id = 1;
            BugReportModel bugReport = repository.GetOneById(id);
            return Ok(bugReport);
        }
    }
}
