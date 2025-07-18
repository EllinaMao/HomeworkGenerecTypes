using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4.Interfaces
{
    public interface IFilter
    {
        IEnumerable<Student> ByGroup(Dictionary<Student, List<CourseProgress>> dict, string group);
        IEnumerable<Student> ByLowScore(Dictionary<Student, List<CourseProgress>> dict, double threshold);
    }
}
