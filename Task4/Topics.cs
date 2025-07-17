using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    public class Topics : ITopic
    {
        public string Name { get; private set; }
        public List<int> Marks { get; set; }

        public int AverageMark
        {
            get
            {
                var allMarks = new List<int>(Marks);
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
            IsCompleted = false;
        }
        public Topics(string name, string teacher, List<int>? marks = null, int? examMark = null)
        {
            Name = name;
            Teacher = teacher;
            Marks = marks ?? new List<int>();
            IsCompleted = Marks.Count > 0 && Marks.Average() > 5;
        }
        public override string ToString()//there was ExamMark
        {
            return $"Topic: {Name}, Average Mark: {AverageMark}, Teacher: {Teacher}, Completed: {IsCompleted}";
        }

        public void AddMark(int mark)
        {
            if (IsCompleted) return;
            if (mark < 0 || mark > 12)
            {
                Marks.Add(mark);
                OnMarksUpdated?.Invoke(this, EventArgs.Empty);
            }
        }

        public void FinishTopic()
        {
            if (Marks.Count == 0) return;
            IsCompleted = true;
            OnTopicCompleted?.Invoke(this, EventArgs.Empty);
        }

    }

}
