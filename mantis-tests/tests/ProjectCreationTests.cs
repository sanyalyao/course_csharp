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
            ProjectData newProject = new ProjectData(GenerateRandomString(5));
            app.Navigation.OpenManageMenu();
            app.Navigation.OpenManageProjectsPage();
            List<ProjectData> oldProjects = app.Project.GetProjects();
            app.Project.CreateNewProject(newProject);
            List<ProjectData> newProjects = app.Project.GetProjects();
            oldProjects.Add(newProject);
            oldProjects.Sort();
            newProjects.Sort();
            Assert.AreEqual(oldProjects, newProjects);
        }
    }
}
