using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task4.Interfaces;

namespace Task4.System
{
    public class StudentFilter : IFilter
    {
        public IEnumerable<Student> ByGroup(Dictionary<Student, List<CourseProgress>> dict, string group)
        {
            return dict.Keys.Where(s => s.Group == group);
        }
        public IEnumerable<Student> ByLowScore(Dictionary<Student, List<CourseProgress>> dict, double threshold)
        {
            return dict.Where(kvp => kvp.Value.Any(c => c.CurrentScore < threshold)).Select(kvp => kvp.Key);
        }
    }


}
