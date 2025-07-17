using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    public class Topics : ITopic, IEquatable<Topics>
    {
        public string Name { get; private set; }
        public List<int> Marks { get; set; }
        //public int ExamMark { get; private set; }

        public int AverageMark
        {
            get
            {
                var allMarks = new List<int>(Marks);
                //if (ExamMark >= 0)
                //    allMarks.Add(ExamMark);
                return allMarks.Count > 0 ? (int)allMarks.Average() : 0;
            }
        }
        public string Teacher { get; set; }
        public bool IsCompleted { get; private set; }

        public event EventHandler? OnTopicCompleted;
        public event EventHandler? OnMarksUpdated;
        public Topics()
        {
            Name = "Default Topic";
            Marks = new List<int>();
            Teacher = "Default Teacher";
            //ExamMark = -1;
            IsCompleted = false;
        }
        public Topics(string name, string teacher, List<int>? marks = null, int? examMark = null)
        {
            Name = name;
            Teacher = teacher;
            Marks = marks ?? new List<int>();
            //ExamMark = examMark ?? -1;
            //IsCompleted = ExamMark > 6 && Marks.Count > 0;
            IsCompleted = Marks.Count > 0 && Marks.Average() > 5;
        }
        public override string ToString()//there was ExamMark
        {
            return $"Topic: {Name}, Average Mark: {AverageMark}, Teacher: {Teacher}, Completed: {IsCompleted}";
        }
        public void Exam(int mark)
        {
            if (mark < 0 || mark >= 12)
                throw new ArgumentException("Оценка должна быть выше 0 и 12.");

            //ExamMark = mark;
            //IsCompleted = ExamMark > 5 && Marks.Count > 0;
            IsCompleted = mark > 5 && Marks.Count > 0;
            OnMarksUpdated?.Invoke(this, EventArgs.Empty);

            if (IsCompleted) {
                OnTopicCompleted?.Invoke(this, EventArgs.Empty);
            }
        }

        public bool Equals(Topics? other)
        {
            if (other is null)
                return false;
            return Name == other.Name && Teacher == other.Teacher;
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as Topics);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Teacher);
        }
    }

}

