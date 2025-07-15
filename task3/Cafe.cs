using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{    /*
Задание 3
Создайте приложение, эмулирующее очередь в популярное кафе. Посетители кафе приходят и попадают в очередь, если нет свободного места. При освобождении столика в кафе, первый посетитель очереди занимает его. Если приходит клиент, который резервировал столик на определенное время, он получает зарезервированный столик вне очереди.

При разработке приложения используйте класс Queue<T>.
*/
    internal class Cafe
    {
        Queue<Customer> Queue = new Queue<Customer>();
        List<Table> Tables = new List<Table>();
        private Dictionary<string, Customer> Reservations = new Dictionary<string, Customer>();
        public Cafe(int tableCount)//cколько столиков в кафе, они все пустые, как в классе столик
        {
            Queue.Clear();
            for (int i = 1; i <= tableCount; i++)
                Tables.Add(new Table(i));
        }

        public void ComeCustomer(Customer customer)
        {
            if (customer.HasReservation)
            {
                Reservations[customer.Name] = customer;
            }
            else
            {
                Queue.Enqueue(customer);
            }
            TrySeatCustomers();

        }
        public void ReleaseTable(int tableId)
        {
            var table = Tables.Find(t => t.Id == tableId);
            if (table != null)
            {
                table.IsOccupied = false;
                Console.WriteLine($"Столик #{table.Id} освободился.");
                TrySeatCustomers();
            }
        }

        private void TrySeatCustomers()
        {
            foreach (Table table in Tables)
            {
                if (table.IsOccupied)
                    continue;

                var now = DateTime.Now;

                var reservations = new List<Customer>();
                var keysToRemove = new List<string>();

                foreach (var pair in Reservations)
                {
                    if (pair.Value.Reservation <= now)
                    {
                        reservations.Add(pair.Value);
                        keysToRemove.Add(pair.Key);
                    }
                }

                if (reservations.Count > 0)
                {
                    var customer = reservations[0];
                    Reservations.Remove(customer.Name);
                    table.IsOccupied = true;
                    Console.WriteLine($"{customer} сел за столик #{table.Id} по резервации.");
                    continue;
                }

                if (Queue.Count > 0)
                {
                    var next = Queue.Dequeue();
                    table.IsOccupied = true;
                    Console.WriteLine($"{next} сел за столик #{table.Id} из очереди.");
                }
            }
        }


        public void ShowStatus()
        {
            Console.WriteLine("Очередь:");
            foreach (var c in Queue)
                Console.WriteLine($" - {c}");
            Console.WriteLine("Резервации:");
            foreach (var r in Reservations.Values)
                Console.WriteLine($" - {r}");
            Console.WriteLine("Столики:");
            foreach (var t in Tables)
                Console.WriteLine($" - Столик #{t.Id}: {(t.IsOccupied ? "занят" : "свободен")}");
        }


    }


}

