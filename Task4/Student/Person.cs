using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task4.Interfaces;

namespace Task4
{
    public class Person
    {
        public string FullName { get; set; }
        private int _id;
        public int ID => _id;
        public virtual string Group { get; set; }

        public Person(string fullName, int id, string group)
        {
            FullName = fullName;
            _id = id;
            Group = group;
        }
        public override string ToString()
        {
            return $"{FullName} (ID: {ID}, Group: {Group})";
        }
    }
}
