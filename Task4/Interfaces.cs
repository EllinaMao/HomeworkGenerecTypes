using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    public interface ICourseProgress
    {
        string Name { get; }
        double CurrentScore { get; }
        Topics? CurrentTopic { get; }
        public List<Topics> CompletedTopics { get;}

        void SetCurrentTopic(Topics topic);
        void CompleteTopic(Topics topic);
    }

    public interface ITopic
    {
        string Name { get; }
        int AverageMark { get; }
        bool IsCompleted { get; }
        string Teacher { get; }
        //void Exam(int mark);
    }

    public interface IStudent
    {
        string FullName { get; }
        int ID { get; }
        string Group { get; }
    }

}
