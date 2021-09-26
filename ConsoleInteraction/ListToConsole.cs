using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HomeWork_08_SKP.Services;

namespace HomeWork_08_SKP
{
    static class ListToConsole
    {
        /// <summary>
        /// Вывод департаментов в окно консоли
        /// </summary>
        /// <param name="objects">Список содержащий объекты организации - сотрудников/департаменты</param>
        static public void PrintListDepartments()
        {
            string[] titles = { "Название", "Дата создания", "Кол-во сотруд." };
            Console.WriteLine($"{titles[0],-(CheckUserInput.maxLengthName)} {titles[1],-(CheckUserInput.maxLengthDate)} {titles[2],-(CheckUserInput.maxLengthEmployeesCount)} ");

            foreach (var department in Organization.Departments)
            {
                Console.WriteLine(department);
            }
            Console.ReadKey();
        }

        /// <summary>
        /// Вывод сотрудников в окно консоли
        /// </summary>
        /// <param name="employees"></param>
        static public void PrintListEmployees()
        {
            Console.Clear();

            string[] titles = { "id", "Имя", "Фамилия", "Возраст", "Департамент", "Зар.плата" };
            Console.WriteLine($"{titles[0],-(CheckUserInput.maxLengthId)} {titles[1],-(CheckUserInput.maxLengthName)} {titles[2],-(CheckUserInput.maxLengthName)} {titles[3],-(CheckUserInput.maxLengthAge)} {titles[4],-(CheckUserInput.maxLengthName)} {titles[5],-(CheckUserInput.maxLengthWage)}");

            foreach (var department in Organization.Departments)
            {
                foreach (var employee in department.Employees)
                {
                    Console.WriteLine(employee);
                }
            }

            Console.ReadKey();
        }               

    }
}
