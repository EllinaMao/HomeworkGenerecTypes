using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*Задание 1
Создайте приложение для менеджмента сотрудников и паролей. Необходимо хранить следующую информацию:

Логины сотрудников;
Пароли сотрудников.
Для хранения информации используйте Dictionary<T>.

Приложение должно предоставлять такую функциональность:

Добавление логина и пароля сотрудника;+
Удаление логина сотрудника;+
Изменение информации о логине и пароле сотрудника;+
Получение информации о пароле по логину сотрудника.+
*/
namespace Task1
{
    internal class AuthorizationData
    {
        public Dictionary<string, string> employeeData { get; set; }
        public AuthorizationData()
        {
            employeeData = new Dictionary<string, string>();
        }
        public void AddEmployee(string login, string password)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(login))
                {
                    throw new ArgumentException("Логин не может быть пустым.");
                }
                if (string.IsNullOrWhiteSpace(password))
                {
                    throw new ArgumentException("Пароль не может быть пустым.");
                }
                if (employeeData.ContainsKey(login))
                {
                    throw new ArgumentException("Сотрудник с таким логином уже существует.");
                }
                employeeData.Add(login, password);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void RemoveEmployee(string login)
        {
            try
            {
                if (!employeeData.ContainsKey(login))
                {
                    throw new KeyNotFoundException("Сотрудник с таким логином не найден.");
                }
                employeeData.Remove(login);
            }
            catch (KeyNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void UpdateEmployeePassword(string login, string newPassword)
        {
            try
            {
                if (!employeeData.ContainsKey(login))
                {
                    throw new KeyNotFoundException("Сотрудник с таким логином не найден.");
                }
                employeeData[login] = newPassword;
            }
            catch (KeyNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void UpdateEmployeeLogin(string oldLogin, string newLogin)
        {
            try
            {
                if(newLogin == null || newLogin.Trim() == "")
                {
                    throw new ArgumentException("Новый логин не может быть пустым.");
                }
                if (!employeeData.ContainsKey(oldLogin))
                {
                    throw new KeyNotFoundException("Сотрудник с таким логином не найден.");
                }
                if (employeeData.ContainsKey(newLogin))
                {
                    throw new ArgumentException("Сотрудник с новым логином уже существует.");
                }
                string password = employeeData[oldLogin];
                employeeData.Remove(oldLogin);
                employeeData.Add(newLogin, password);
            }
            catch (KeyNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public bool TryGetEmployeePassword(string login, out string? password)
        {
            if (employeeData.TryGetValue(login, out password))
            {
                return true;
            }
            password = null;
            return false;
        }
        public override string ToString()
        {
            int estimatedSize = employeeData.Count * 40;
            StringBuilder sb = new StringBuilder(estimatedSize);
            foreach (var employee in employeeData)
            {
                sb.AppendLine($"Логин: {employee.Key}");
            }
            return sb.ToString();
        }

        public void PrintAllEmployees()
        {
            if (employeeData.Count == 0)
            {
                Console.WriteLine("Сотрудники не найдены.");
            }
            else
            {
                Console.WriteLine("Текущие сотрудники:");
                Console.WriteLine(this.ToString());
            }
        }
    }

}
