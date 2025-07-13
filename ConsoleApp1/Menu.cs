using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class Menu
    {
    public enum MenuOptions
    {
        AddEmployee = 1,
        RemoveEmployee,
        UpdateEmployeeInfo,
        GetPasswordByLogin,
        ShowAllEmployees,
            Exit
    }
        public void ShowMenu()
        {
            Console.WriteLine("Добро пожаловать в систему управления сотрудниками!");
            Console.WriteLine("Пожалуйста, выберите опцию:");
            Console.WriteLine("1. Добавить сотрудника");
            Console.WriteLine("2. Удалить сотрудника");
            Console.WriteLine("3. Обновить информацию о сотруднике");
            Console.WriteLine("4. Получить пароль по логину");
            Console.WriteLine("5. Просмотреть всех");
            Console.WriteLine("6. Выход");
        }
        public void HideMenu()
        {
            Console.WriteLine("Нажмите любую клавишу для выхода...");
            Console.Clear();
            Console.ReadKey();
        }

        public MenuOptions ShowMainMenu()
        {
            while (true)
            {
            Console.Clear();
            ShowMenu();
            var key = Console.ReadKey(true);
                switch (key.Key)
                {
                    case ConsoleKey.D1:
                        return MenuOptions.AddEmployee;
                    case ConsoleKey.D2:
                        return MenuOptions.RemoveEmployee;
                    case ConsoleKey.D3:
                        return MenuOptions.UpdateEmployeeInfo;
                    case ConsoleKey.D4:
                        return MenuOptions.GetPasswordByLogin;
                    case ConsoleKey.D5:
                        return MenuOptions.ShowAllEmployees;
                    case ConsoleKey.D6:
                    case ConsoleKey.Escape:
                        HideMenu();
                        return MenuOptions.Exit;
                    default:
                        Console.WriteLine("Неверная опция, попробуйте еще раз.");
                        break;
                }
            };
        }


    }
}
