using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4.Interfaces
{
    public interface IStudent
    {
        string FullName { get; }
        int ID { get; }
        string? Group { get; }
    }
}
