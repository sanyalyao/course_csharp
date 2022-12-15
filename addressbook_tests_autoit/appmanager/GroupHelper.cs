using System;
using System.Collections.Generic;

namespace addressbook_tests_autoit
{
    public class GroupHelper : HelperBase
    {
        public static string GroupEditorWinTitle = "Group editor";
        public static string DeleteGroupWinTitle = "Delete group";
        public GroupHelper (ApplicationManager manager) : base(manager)
        {

        }

        public List<GroupData> GetGroupList()
        {
            OpenGroupsDialogue();
            List<GroupData> list = new List<GroupData>();
            string count = aux.ControlTreeView(GroupEditorWinTitle, "", "WindowsForms10.SysTreeView32.app.0.2c908d51", "GetItemCount", "#0", "");
            for (int i = 0; i < Int32.Parse(count); i++)
            {
                string item = aux.ControlTreeView(GroupEditorWinTitle, "", "WindowsForms10.SysTreeView32.app.0.2c908d51", "GetText", $"#0|#{i}", "");
                list.Add(new GroupData() { Name = item});
            }
            CloseGroupsDialogue();
            return list;
        }

        internal void ModifyGroup(GroupData modifiedGroup, int index)
        {
            OpenGroupsDialogue();

            if (index == 0)
            {
                aux.Send("{DOWN}");
                aux.ControlClick(GroupEditorWinTitle, "", "WindowsForms10.BUTTON.app.0.2c908d52");
                aux.Send(modifiedGroup.Name);
                aux.Send("{ENTER}");
                aux.ControlClick(GroupEditorWinTitle, "", "WindowsForms10.BUTTON.app.0.2c908d54");
                WindowWait(WinTitle);
            }
            else
            {
                for (int i = 0; i <= index - 1; i++)
                {
                    aux.Send("{DOWN}");
                }
                aux.ControlClick(GroupEditorWinTitle, "", "WindowsForms10.BUTTON.app.0.2c908d52");
                aux.Send(modifiedGroup.Name);
                aux.Send("{ENTER}");
                aux.ControlClick(GroupEditorWinTitle, "", "WindowsForms10.BUTTON.app.0.2c908d54");
                WindowWait(WinTitle);
            }
        }

        public void RemoveGroup(int group)
        {
            OpenGroupsDialogue();
            aux.ControlTreeView(GroupEditorWinTitle, "", "WindowsForms10.SysTreeView32.app.0.2c908d51", "Select", $"#0|#{group}", "");
            aux.ControlClick(GroupEditorWinTitle, "", "WindowsForms10.BUTTON.app.0.2c908d51");
            WindowWait(DeleteGroupWinTitle);
            aux.ControlClick(DeleteGroupWinTitle, "" , "WindowsForms10.BUTTON.app.0.2c908d53");
            WindowWait(GroupEditorWinTitle);
            CloseGroupsDialogue();
            WindowWait(WinTitle);
        }

        public void CreateNewGroup(GroupData newGroup)
        {
            OpenGroupsDialogue();
            WindowWait(GroupEditorWinTitle);
            aux.ControlClick(GroupEditorWinTitle, "", "WindowsForms10.BUTTON.app.0.2c908d53");
            aux.Send(newGroup.Name);
            aux.Send("{ENTER}");
            CloseGroupsDialogue();
            WindowWait(WinTitle);
        }

        public void CloseGroupsDialogue()
        {
            aux.ControlClick(GroupEditorWinTitle, "", "WindowsForms10.BUTTON.app.0.2c908d54");
            WindowWait(WinTitle);
        }

        public void OpenGroupsDialogue()
        {
            aux.ControlClick(WinTitle, "", "WindowsForms10.BUTTON.app.0.2c908d512");
            WindowWait(GroupEditorWinTitle);
        }
    }
}