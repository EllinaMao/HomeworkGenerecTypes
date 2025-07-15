using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    internal class Customer
    {
        public string Name { get; set; }
        public bool HasReservation {  get; set; }
        public DateTime? Reservation {  get; set; }


        public Customer(string name, bool hasReservation = false, DateTime? reservationTime = null)
        {
            Name = name;
            HasReservation = hasReservation;
            Reservation = reservationTime;
        }

        public override string ToString() =>
            HasReservation ? $"{Name} (резервировал на {Reservation.Value:T})" : Name;
    }
}
