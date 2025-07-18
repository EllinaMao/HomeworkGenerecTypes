using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4.Interfaces
{
    public interface ICourseProgress
    {
        string Name { get; }
        double CurrentScore { get; }
        Topics? CurrentTopic { get; }
        public List<Topics> CompletedTopics { get; }

        void SetCurrentTopic(Topics topic);
        void CompleteTopic(Topics topic);
    }
}
