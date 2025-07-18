using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task4.Interfaces;

namespace Task4.System
{
    internal class StudentSorter
    {
        public IEnumerable<Student> ByAverageScore(Dictionary<Student, List<CourseProgress>> dict)
        {
            return dict.OrderByDescending(kvp => kvp.Value.Average(cp => cp.CurrentScore)).Select(kvp => kvp.Key);
        }
    }
}
