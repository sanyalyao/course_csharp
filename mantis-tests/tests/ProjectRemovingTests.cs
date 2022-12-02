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
            app.Navigation.OpenManageMenu();
            app.Navigation.OpenManageProjectsPage();
            if (app.Project.GetProjects().Count() == 0)
            {
                app.Project.CreateNewProject(new ProjectData(GenerateRandomString(5)));
            }
            List<ProjectData> oldProjects = app.Project.GetProjects();
            app.Project.RemoveProject(0);
            List<ProjectData> newProjects = app.Project.GetProjects();
            oldProjects.RemoveAt(0);
            oldProjects.Sort();
            newProjects.Sort();
            Assert.AreEqual(oldProjects, newProjects);
        }
    }
}
