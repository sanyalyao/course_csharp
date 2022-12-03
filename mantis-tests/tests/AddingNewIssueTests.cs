using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace mantis_tests
{
    [TestFixture]
    public class AddingNewIssueTests : TestBase
    {
        [Test]
        public void CreateIssue()
        {
            AccountData account = new AccountData()
            {
                Name = "administrator",
                Password = "root"
            };
            ProjectData project = new ProjectData()
            {
                Id = "22"
            };
            IssueData issueData = new IssueData()
            {
                Category = "General",
                Summary = "summary text",
                Description = "description text"
            };
            app.API.CreateNewIssue(account, issueData, project);
        }
    }
}
