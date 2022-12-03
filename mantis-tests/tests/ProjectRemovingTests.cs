using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace mantis_tests
{
    [TestFixture]
    public class ProjectRemovingTests : AuthTestBase
    {
        [Test]
        public void RemoveProject()
        {
            if (app.API.GetProjects(adminAccount).Count() == 0)
            {
                ProjectData newProject = new ProjectData()
                {
                    ProjectName = GenerateRandomString(5)
                };
                app.API.CreateNewProject(adminAccount, newProject);
            }
            List<ProjectData> oldProjects = app.API.GetProjects(adminAccount);
            app.Navigation.OpenManageMenu();
            app.Navigation.OpenManageProjectsPage();
            app.Project.RemoveProject(0);
            List<ProjectData> newProjects = app.API.GetProjects(adminAccount);
            oldProjects.RemoveAt(0);
            oldProjects.Sort();
            newProjects.Sort();
            Assert.AreEqual(oldProjects, newProjects);
        }
    }
}
