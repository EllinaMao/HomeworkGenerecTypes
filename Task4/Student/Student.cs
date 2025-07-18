using Task4.Interfaces;

namespace Task4
{
    public class Student : Person, IStudent, IEquatable<Student>
    {
        // Implement IStudent.Group explicitly
        string IStudent.Group => Group;
        public Student(string fullName, int id, string group) : base(fullName, id, group)
        {
        }
        public bool Equals(Student? other)
        {
            if (other is null)
                return false;

            return ID == other.ID;
        }
        public override string ToString()
        {
            return $"Student: {FullName}, ID: {ID}, Group: {Group}";
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as Student);
        }

        public override int GetHashCode()
        {
            return ID.GetHashCode(); // Или: HashCode.Combine(ID)
        }
    }
}
