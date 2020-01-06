using System;

namespace Task3
{
    public class StudentTestInfo : IComparable<StudentTestInfo>
    {
        public string StudentName { get; }

        public string StudentSurname { get; }

        public string TestName { get; }

        public DateTime TestDate { get; }

        public double Grade { get; }

        public StudentTestInfo(string studentName, string studentSurname, string testName, DateTime testDate, double grade)
        {
            StudentName = studentName;
            StudentSurname = studentSurname;
            TestName = testName;
            TestDate = testDate;
            Grade = grade;
        }

        protected bool Equals(StudentTestInfo other)
        {
            return StudentName == other.StudentName && StudentSurname == other.StudentSurname && TestName == other.TestName && TestDate.Equals(other.TestDate) && Grade.Equals(other.Grade);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((StudentTestInfo) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (StudentName != null ? StudentName.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (StudentSurname != null ? StudentSurname.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (TestName != null ? TestName.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ TestDate.GetHashCode();
                hashCode = (hashCode * 397) ^ Grade.GetHashCode();
                return hashCode;
            }
        }

        public override string ToString()
        {
            return $"Date: {TestDate} | Grade: {Grade} | Name: {StudentName} | Surname: {StudentSurname} | Test: {TestName}";
        }

        public int CompareTo(StudentTestInfo other)
        {
            if (ReferenceEquals(this, other)) return 0;
            if (ReferenceEquals(null, other)) return 1;
            var testDateComparison = TestDate.CompareTo(other.TestDate);
            if (testDateComparison != 0) return testDateComparison;
            var testNameComparison = string.Compare(TestName, other.TestName, StringComparison.Ordinal);
            if (testNameComparison != 0) return testNameComparison;
            var studentSurnameComparison = string.Compare(StudentSurname, other.StudentSurname, StringComparison.Ordinal);
            if (studentSurnameComparison != 0) return studentSurnameComparison;
            var gradeComparison = Grade.CompareTo(other.Grade);
            if (gradeComparison != 0) return gradeComparison;
            return string.Compare(StudentName, other.StudentName, StringComparison.Ordinal);
        }
    }
}