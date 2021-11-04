using System;
using System.Collections.Generic;
using System.Linq;

namespace HomeWork_08_SKP.Services
{
    /// <summary>
    /// Статический класс содержащий метод обработки коллекции объектов организационной структуры организации (департаментов, сотрудников)
    /// </summary>
    public static class ModificationOfOrganizationUnits
    {

        /// <summary>
        /// Метод удаления департамента из списка департаментов
        /// </summary>
        /// <param name="departments">Лист департаментов</param>
        /// <returns>Лист департаментов без удаленного департамента</returns>
        public static List<Department> DeleteDepartment(List<Department> departments, out string nameOfDeletedDepartment)
        {            
            int numberOfDeletedDepartment = UserConsoleInputOutput.ChooseNumberOfDepartment(false);

            List<Department> modifiedListOfDepartment = new List<Department>();

            nameOfDeletedDepartment = departments[numberOfDeletedDepartment - 1].Name;

            modifiedListOfDepartment = departments.Where(n => n != departments[numberOfDeletedDepartment - 1]).ToList();            

            Console.ReadKey();

            return modifiedListOfDepartment;
        }

        /// <summary>
        /// Метод удаления работника из списка работников
        /// </summary>
        /// <param name="departmentOfDeletedEmployee">Департамент в котором состоит сотрудник, которого необходимо удалить</param>
        /// <returns>Лист работников без удаленного работника</returns>
        public static List<Employee> DeleteEmployee(Department departmentOfDeletedEmployee, int numberOfEmployeeForDelete)
        {
            List<Employee> modifiedListOfEmployees = new List<Employee>();

            modifiedListOfEmployees = departmentOfDeletedEmployee.Employees.Where(n => n != departmentOfDeletedEmployee.Employees[numberOfEmployeeForDelete]).ToList();

            return modifiedListOfEmployees;
        }

        /// <summary>
        /// Метод сортировки коллекции сотрудников
        /// </summary>
        /// <param name="department">Департамент список сотрудников которого сортируется</param>
        /// <returns></returns>
        public static List<Employee> SortEmployees(Department department)
        {
            List<Employee> sorteredEmployees = new List<Employee>();

            switch (department.employeeSort.ColumnFirst)
            {
                case Enums.EmployeeFields.name:
                    if (department.employeeSort.SortBy == Enums.SortType.ASC) sorteredEmployees = department.Employees.OrderBy(n => n.Name).ToList();
                    else sorteredEmployees = department.Employees.OrderByDescending(n => n.Name).ToList();
                    break;
                case Enums.EmployeeFields.surname:
                    if (department.employeeSort.SortBy == Enums.SortType.ASC) sorteredEmployees = department.Employees.OrderBy(n => n.Surname).ToList();
                    else sorteredEmployees = department.Employees.OrderByDescending(n => n.Surname).ToList();
                    break;
                case Enums.EmployeeFields.age:
                    if (department.employeeSort.SortBy == Enums.SortType.ASC) sorteredEmployees = department.Employees.OrderBy(n => n.Age).ToList();
                    else sorteredEmployees = department.Employees.OrderByDescending(n => n.Age).ToList();
                    break;
                case Enums.EmployeeFields.workplace:
                    if (department.employeeSort.SortBy == Enums.SortType.ASC) sorteredEmployees = department.Employees.OrderBy(n => n.WorkPlace).ToList();
                    else sorteredEmployees = department.Employees.OrderByDescending(n => n.WorkPlace).ToList();
                    break;
                case Enums.EmployeeFields.wage:
                    if (department.employeeSort.SortBy == Enums.SortType.ASC) sorteredEmployees = department.Employees.OrderBy(n => n.Wage).ToList();
                    else sorteredEmployees = department.Employees.OrderByDescending(n => n.Wage).ToList();
                    break;
                    default:
                    sorteredEmployees = department.Employees;
                    break;
            }
            return sorteredEmployees;
        }
    }
}
