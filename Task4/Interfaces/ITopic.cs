using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4.Interfaces
{
    public interface ITopic
    {
        string Name { get; }
        int AverageMark { get; }
        bool IsCompleted { get; }
        string Teacher { get; }
        //void Exam(int mark);
    }

}
