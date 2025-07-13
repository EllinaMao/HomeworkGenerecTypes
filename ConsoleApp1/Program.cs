namespace Task1
{
    /*Задание 1
Создайте приложение для менеджмента сотрудников и паролей. Необходимо хранить следующую информацию:

Логины сотрудников;
Пароли сотрудников.
Для хранения информации используйте Dictionary<T>.

Приложение должно предоставлять такую функциональность:

Добавление логина и пароля сотрудника;
Удаление логина сотрудника;
Изменение информации о логине и пароле сотрудника;
Получение информации о пароле по логину сотрудника.*/
    internal class Program
    {
        static void Main(string[] args)
        {
            {
                var menu = new Menu();
                var authData = new AuthorizationData();
                bool running = true;

                while (running)
                {
                    var action = menu.ShowMainMenu();

                    switch (action)
                    {
                        case Menu.MenuOptions.AddEmployee:
                            Console.Write("Введите логин: ");
                            string loginAdd = Console.ReadLine();
                            if (string.IsNullOrWhiteSpace(loginAdd))
                            {
                                Console.WriteLine("Логин не может быть пустым.");
                                Console.WriteLine("Нажмите любую клавишу для продолжения...");
                                Console.ReadKey();
                                continue;
                            }
                            Console.Write("Введите пароль: ");
                            if (string.IsNullOrWhiteSpace(Console.ReadLine()))
                            {
                                Console.WriteLine("Пароль не может быть пустым.");
                                Console.WriteLine("Нажмите любую клавишу для продолжения...");
                                Console.ReadKey();
                                continue;
                            }
                            string passwordAdd = Console.ReadLine();
                            authData.AddEmployee(loginAdd, passwordAdd);
                            break;

                        case Menu.MenuOptions.RemoveEmployee:
                            Console.Write("Введите логин сотрудника для удаления: ");
                            string loginRemove = Console.ReadLine();
                            authData.RemoveEmployee(loginRemove);
                            break;

                        case Menu.MenuOptions.UpdateEmployeeInfo:
                            Console.Write("Введите текущий логин: ");
                            string oldLogin = Console.ReadLine();
                            Console.Write("Изменить логин? (y/n): ");
                            var changeLogin = Console.ReadLine();
                            if (changeLogin.ToLower() == "y")
                            {
                                Console.Write("Введите новый логин: ");
                                string newLogin = Console.ReadLine();
                                authData.UpdateEmployeeLogin(oldLogin, newLogin);
                            }
                            Console.Write("Изменить пароль? (y/n): ");
                            var changePassword = Console.ReadLine();
                            if (changePassword.ToLower() == "y")
                            {
                                Console.Write("Введите новый пароль: ");
                                string newPassword = Console.ReadLine();
                                authData.UpdateEmployeePassword(oldLogin, newPassword);
                            }
                            break;

                        case Menu.MenuOptions.GetPasswordByLogin:
                            Console.Write("Введите логин сотрудника: ");
                            string loginGet = Console.ReadLine();
                            if (authData.TryGetEmployeePassword(loginGet, out string? password))
                            {
                                Console.WriteLine($"Пароль: {password}");
                            }
                            else
                            {
                                Console.WriteLine("Сотрудник не найден.");
                            }
                            break;

                        case Menu.MenuOptions.ShowAllEmployees:
                            authData.PrintAllEmployees();
                            break;
                        case Menu.MenuOptions.Exit:
                            running = false;
                            break;
                    }

                    if (running)
                    {
                        Console.WriteLine("\nНажмите любую клавишу, чтобы продолжить...");
                        Console.ReadKey(true);
                    }
                }

                Console.WriteLine("Программа завершена.");
            }
        }
    }
    }
