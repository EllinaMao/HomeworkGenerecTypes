using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    internal class Table
    {
        public int Id { get; }
        public bool IsOccupied { get; set; }

        public Table(int id)
        {
            Id = id;
            IsOccupied = false;
        }
    }
}
