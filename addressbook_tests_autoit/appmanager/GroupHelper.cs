using System;
using System.Collections.Generic;

namespace addressbook_tests_autoit
{
    public class GroupHelper : HelperBase
    {
        public static string GroupWinTitle = "Group editor";
        public static string WinDeleteGroup = "Delete group";
        public GroupHelper (ApplicationManager manager) : base(manager)
        {

        }

        public List<GroupData> GetGroupList()
        {
            OpenGroupsDialogue();
            List<GroupData> list = new List<GroupData>();
            string count = aux.ControlTreeView(GroupWinTitle, "", "WindowsForms10.SysTreeView32.app.0.2c908d51", "GetItemCount", "#0", "");
            for (int i = 0; i < Int32.Parse(count); i++)
            {
                string item = aux.ControlTreeView(GroupWinTitle, "", "WindowsForms10.SysTreeView32.app.0.2c908d51", "GetText", $"#0|#{i}", "");
                list.Add(new GroupData() { Name = item});
            }
            CloseGroupsDialogue();
            return list;
        }

        public void RemoveGroup(int group)
        {
            OpenGroupsDialogue();
            aux.ControlTreeView(GroupWinTitle, "", "WindowsForms10.SysTreeView32.app.0.2c908d51", "Select", $"#0|#{group}", "");
            aux.ControlClick(GroupWinTitle, "", "WindowsForms10.BUTTON.app.0.2c908d51");
            aux.WinWait(WinDeleteGroup);
            aux.ControlClick(WinDeleteGroup, "" , "WindowsForms10.BUTTON.app.0.2c908d53");
            aux.WinWait(GroupWinTitle);
            CloseGroupsDialogue();
        }

        public void CreateNewGroup(GroupData newGroup)
        {
            OpenGroupsDialogue();
            aux.ControlClick(GroupWinTitle, "", "WindowsForms10.BUTTON.app.0.2c908d53");
            aux.Send(newGroup.Name);
            aux.WinWait("","",2);
            aux.Send("{ENTER}");
            CloseGroupsDialogue();
        }

        public void CloseGroupsDialogue()
        {
            aux.ControlClick(GroupWinTitle, "", "WindowsForms10.BUTTON.app.0.2c908d54");
            aux.WinWait(WinTitle);
        }

        public void OpenGroupsDialogue()
        {
            aux.ControlClick(WinTitle, "", "WindowsForms10.BUTTON.app.0.2c908d512");
            aux.WinWait(GroupWinTitle);
        }
    }
}