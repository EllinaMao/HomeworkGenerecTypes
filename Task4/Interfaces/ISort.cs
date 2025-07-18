using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4.Interfaces
{
    internal interface ISort
    {
        public IEnumerable<Student> ByAverageScore(Dictionary<Student, List<CourseProgress>> dict);
    }
}
