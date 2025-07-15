using Task3;

namespace task3
{
    /*
Задание 3
Создайте приложение, эмулирующее очередь в популярное кафе. Посетители кафе приходят и попадают в очередь, если нет свободного места. При освобождении столика в кафе, первый посетитель очереди занимает его. Если приходит клиент, который резервировал столик на определенное время, он получает зарезервированный столик вне очереди.

При разработке приложения используйте класс Queue<T>.
*/
    internal class Program
    {
        static void Main(string[] args)
        {
            Cafe cafe = new Cafe(5);
            cafe.ComeCustomer(new Customer("Мария"));
            cafe.ComeCustomer(new Customer("Борис", true, DateTime.Now.AddSeconds(-10)));
            cafe.ComeCustomer(new Customer("Варя"));
            cafe.ComeCustomer(new Customer("Мария"));
            cafe.ComeCustomer(new Customer("Мария"));
            cafe.ComeCustomer(new Customer("Мария"));
            cafe.ComeCustomer(new Customer("Галина", true, DateTime.Now.AddMinutes(1)));


            cafe.ShowStatus();

            Console.WriteLine("\n--- Освобождаем столик #1 ---");
            cafe.ReleaseTable(1);

            Console.WriteLine("\n--- Освобождаем столик #2 ---");
            cafe.ReleaseTable(2);

            cafe.ShowStatus();




        }
    }
}
