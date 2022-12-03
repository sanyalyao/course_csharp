using NUnit.Framework;
using System.Collections.Generic;

namespace mantis_tests
{
    [TestFixture]
    public class ProjectCreationTests : AuthTestBase
    {
        [Test]
        public void CreateProject()
        {
            ProjectData newProject = new ProjectData()
            {
                ProjectName = GenerateRandomString(5)
            };
            app.Navigation.OpenManageMenu();
            app.Navigation.OpenManageProjectsPage();
            List<ProjectData> oldProjects = app.API.GetProjects(adminAccount);
            app.Project.CreateNewProject(newProject);
            List<ProjectData> newProjects = app.API.GetProjects(adminAccount);
            oldProjects.Add(newProject);
            oldProjects.Sort();
            newProjects.Sort();
            Assert.AreEqual(oldProjects, newProjects);
        }
    }
}
