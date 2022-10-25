using OpenQA.Selenium;
using System.Linq;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    public class GroupHelper : HelperBase
    {
        public GroupHelper(ApplicationManager manager) : base(manager)
        {
        }
        public GroupHelper Create(GroupData group)
        {
            manager.Navigator.GoToGroupsPage();
            InitNewGroupCreation();
            FillGroupForm(group);
            SubmitGroupCreation();
            ReturnToGroupsPage();
            return this;
        }

        public List<GroupData> GetGroupList()
        {
            manager.Navigator.GoToGroupsPage();
            List<GroupData> groupList = new List<GroupData>();
            ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("span.group"));
            foreach (IWebElement element in elements)
            {
                groupList.Add(new GroupData(element.Text));
            }
            return groupList;
        }

        public void Remove(GroupData group)
        {
            manager.Navigator.GoToGroupsPage();
            if (IsGroupPresent(group).Select(x => x.Key).Single())
            {
                SelectGroup(IsGroupPresent(group).Select(x => x.Value).Single());
                RemoveGroup();
                ReturnToGroupsPage();
            }
        }

        public void Modify(GroupData newGroup, GroupData oldGroup)
        {
            manager.Navigator.GoToGroupsPage();
            if (IsGroupPresent(oldGroup).Select(x => x.Key).Single())
            {
                SelectGroup(IsGroupPresent(oldGroup).Select(x => x.Value).Single());
                InitGroupModification();
                FillGroupForm(newGroup);
                SubmitGroupModification();
                ReturnToGroupsPage();
            }
        }

        public GroupHelper SubmitGroupModification()
        {
            driver.FindElement(By.Name("update")).Click();
            return this;
        }

        public GroupHelper InitGroupModification()
        {
            driver.FindElement(By.Name("edit")).Click();
            return this;
        }

        public GroupHelper ReturnToGroupsPage()
        {
            driver.FindElement(By.LinkText("group page")).Click();
            return this;
        }
        public GroupHelper InitNewGroupCreation()
        {
            driver.FindElement(By.Name("new")).Click();
            return this;
        }
        public GroupHelper SubmitGroupCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
            return this;
        }
        public GroupHelper FillGroupForm(GroupData group)
        {
            Type(By.Name("group_name"), group.Name);
            Type(By.Name("group_header"), group.Header);
            Type(By.Name("group_footer"), group.Footer);
            return this;
        }      

        public GroupHelper RemoveGroup()
        {
            driver.FindElement(By.Name("delete")).Click();
            return this;
        }
        public GroupHelper SelectGroup(int number)
        {
            driver.FindElement(By.XPath($"//div[@id='content']/form/span[{number}]/input")).Click();
            return this;
        }

        public Dictionary<bool, int> IsGroupPresent(GroupData group)
        {
            manager.Navigator.GoToGroupsPage();
            IList<IWebElement> groupElements = driver.FindElement(By.Id("content")).FindElements(By.ClassName("group"));
            Dictionary<bool, int> result = new Dictionary<bool, int>();
            bool trueOrFalse = false;
            int numberOfGroup = 0;
            for (int i = 0; i < groupElements.Count(); i++)
            {
                if (groupElements[i].Text.ToLower() == group.Name.ToLower())
                {
                    trueOrFalse = true;
                    numberOfGroup = i + 1;
                }
            }
            result.Add(trueOrFalse, numberOfGroup);
            return result;
        }
    }
}
