using System;
using System.Collections.Generic;
using HomeWork_08_SKP.Services;

namespace HomeWork_08_SKP
{
    /// <summary>
    /// Статический класс содержащий методы вывода на консоль коллекций объектов (департаментов, сотрудников)
    /// </summary>
    static class ListToConsole
    {
        /// <summary>
        /// Вывод департаментов в окно консоли
        /// </summary>
        /// <param name="objects">Список содержащий объекты организации - сотрудников/департаменты</param>
        static public void PrintListDepartments(List<Department> departments)
        {

            string[] titles = { "№п/п", "ID-номер", "Название", "Дата создания", "Кол-во сотруд." };
            Console.WriteLine($"{titles[0],-5} {titles[1],-(CheckUserInput.maxLengthId)} {titles[2],-(CheckUserInput.maxLengthName)} {titles[3],-(CheckUserInput.maxLengthDate)} {titles[4],-(CheckUserInput.maxLengthEmployeesCount)} ");

            int numberOfDepartment = 1;

            foreach (var department in departments)
            {
                Console.WriteLine($"{Convert.ToString(numberOfDepartment),-5} {department}");
                numberOfDepartment++;
            }

        }

        /// <summary>
        /// Вывод сотрудников в окно консоли
        /// </summary>
        /// <param name="employees"></param>
        static public void PrintListAllEmployees()
        {

            string[] titles = { "ID-номер", "Имя", "Фамилия", "Возраст", "Департамент", "Зар.плата" };
            Console.WriteLine($"{titles[0],-(CheckUserInput.maxLengthId)} {titles[1],-(CheckUserInput.maxLengthName)} {titles[2],-(CheckUserInput.maxLengthName)} {titles[3],-(CheckUserInput.maxLengthAge)} {titles[4],-(CheckUserInput.maxLengthName)} {titles[5],-(CheckUserInput.maxLengthWage)}");

            foreach (var department in Organization.Departments)
            {
                foreach (var employee in department.Employees)
                {
                    Console.WriteLine(employee);
                }
            }

        }

        /// <summary>
        /// Вывод в окно консоли сотрудников указанного департамента
        /// </summary>
        /// <param name="department">Указанный департамент</param>
        static public void PrintEmployeesOfDepartment(Department department, bool isSorted)
        {
            string[] titles = { "№п/п", "ID-номер", "Имя", "Фамилия", "Возраст", "Департамент", "Зар.плата" };
            Console.WriteLine($"{titles[0],-5} {titles[1],-(CheckUserInput.maxLengthId)} {titles[2],-(CheckUserInput.maxLengthName)} {titles[3],-(CheckUserInput.maxLengthName)} {titles[4],-(CheckUserInput.maxLengthAge)} {titles[5],-(CheckUserInput.maxLengthName)} {titles[6],-(CheckUserInput.maxLengthWage)}");

            List<Employee> employeesToPrint = new List<Employee>();

            if (!isSorted)
            {
                employeesToPrint = department.Employees;
            }
            else
            {                
                employeesToPrint = ModificationOfOrganizationUnits.SortEmployees(department);                
            }

            int numberOfEmployee = 1;

            foreach (var employee in employeesToPrint)
            {
                Console.WriteLine($"{Convert.ToString(numberOfEmployee),-5} {employee}");
                numberOfEmployee++;
            }


        }

    }
}
