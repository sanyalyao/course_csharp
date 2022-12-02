using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;

namespace mantis_tests
{
    public class ProjectHelper : HelperBase
    {
        public ProjectHelper(ApplicationManager manager) : base(manager)
        {
        }

        public void CreateNewProject(ProjectData project)
        {
            driver.FindElement(By.CssSelector("button[type='submit']")).Click();
            Type(By.Id("project-name"), project.ProjectName);
            driver.FindElement(By.CssSelector("input[value='Add Project']")).Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(d => d.FindElements(By.LinkText("Manage Projects")).Count() > 0);
        }

        internal List<ProjectData> GetProjects()
        {
            List<ProjectData> projects = new List<ProjectData>();
            var elements = driver.FindElements(By.ClassName("table-responsive"))[0].FindElement(By.TagName("tbody")).FindElements(By.TagName("tr"));
            foreach (IWebElement element in elements)
            {
                projects.Add(new ProjectData(element.FindElement(By.TagName("a")).Text));
            }
            return projects;
        }

        internal void RemoveProject(int index)
        {
            driver.FindElements(By.ClassName("table-responsive"))[0].FindElement(By.TagName("tbody")).FindElements(By.TagName("tr"))[index].FindElement(By.TagName("a")).Click();
            driver.FindElement(By.CssSelector("input[value='Delete Project']")).Click();
            driver.FindElement(By.CssSelector("input[value='Delete Project']")).Click();
        }
    }
}
