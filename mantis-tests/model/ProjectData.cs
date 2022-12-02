using System;

namespace mantis_tests
{
    public class ProjectData : IComparable<ProjectData>, IEquatable<ProjectData>
    {
        public string ProjectName;

        public ProjectData(string projectName)
        {
            ProjectName = projectName;
        }

        public int CompareTo(ProjectData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            return ProjectName.CompareTo(other.ProjectName);
        }

        public bool Equals(ProjectData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, null))
            {
                return true;
            }
            return ProjectName.Equals(other.ProjectName);
        }

        public override int GetHashCode()
        {
            return ProjectName.GetHashCode();
        }
    }
}
