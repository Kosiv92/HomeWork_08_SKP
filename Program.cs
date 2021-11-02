using System;
using System.Collections.Generic;

namespace HomeWork_08_SKP
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(155, 35);

            //Test_1();

            Menu.ShomMainMenu();                        

            #region Проверка импорта/экспорта данных
            //string path = "D:\\Departments.xml";
            //XMLSerializer.DataContractSerializeDepartment(Organization.Departments, path);
            //XMLSerializer.DataContractDeserializeDepartment(path);
            //ListToConsole.PrintListDepartments();
            //Console.WriteLine();
            //ListToConsole.PrintListEmployees();
            //Console.ReadKey();
            #endregion

        }

        /// <summary>
        /// Метод тестового заполнения структуры организации
        /// </summary>
        static void Test_1()
        {

            for (int i = 1; i <= 5; i++)
            {
                Department newDepartment = new Department();

                newDepartment.Name = $"Department №{i}";

                newDepartment.DateOfCreation = DateTime.Today;

                for (int y = 1; y <= 2; y++)
                {
                    Employee newEmployee = new Employee();

                    newEmployee.Name = $"Emp №{y}";

                    newEmployee.Surname = $"Dep №{i}";

                    newEmployee.Age = 20 + i + y;

                    newEmployee.WorkPlace = newDepartment;

                    newDepartment.Employees.Add(newEmployee);
                }

                Organization.Departments.Add(newDepartment);

            }

        }


    }
}
