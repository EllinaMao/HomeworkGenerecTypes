namespace Task4
{
    internal class Student : IStudent, IEquatable<Student>
    {
        public string FullName { get; set; }
        private int _id;
        public int ID => _id;
        public string Group { get; set; }

        public Student(string fullName, int id, string group)
        {
            FullName = fullName;
            _id = id;
            Group = group;
        }

        public override string ToString()
        {
            return $"Student: {FullName}, ID: {ID}, Group: {Group}";
        }

        public bool Equals(Student? other)
        {
            if (other is null)
                return false;

            return ID == other.ID;
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
