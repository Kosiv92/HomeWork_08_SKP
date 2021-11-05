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
        public static void DeleteDepartment(int numberOfDeletedDepartment)
        {
            Organization.Departments = Organization.Departments.Where(n => n != Organization.Departments[numberOfDeletedDepartment - 1]).ToList();
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

            if (department.employeeSort.IsSortedTwice == false)
            {
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
            }
            else
            {
                switch (department.employeeSort.ColumnFirst)
                {
                    case Enums.EmployeeFields.name:
                        switch (department.employeeSort.ColumnSecond)
                        {
                            case Enums.EmployeeFields.surname:
                                if (department.employeeSort.SortBy == Enums.SortType.ASC) sorteredEmployees = department.Employees.OrderBy(n => n.Name).ThenBy(n => n.Surname).ToList();
                                else sorteredEmployees = department.Employees.OrderByDescending(n => n.Name).ThenByDescending(n => n.Surname).ToList();
                                break;
                            case Enums.EmployeeFields.age:
                                if (department.employeeSort.SortBy == Enums.SortType.ASC) sorteredEmployees = department.Employees.OrderBy(n => n.Name).ThenBy(n => n.Age).ToList();
                                else sorteredEmployees = department.Employees.OrderByDescending(n => n.Name).ThenByDescending(n => n.Age).ToList();
                                break;
                            case Enums.EmployeeFields.workplace:
                                if (department.employeeSort.SortBy == Enums.SortType.ASC) sorteredEmployees = department.Employees.OrderBy(n => n.Name).ThenBy(n => n.WorkPlace).ToList();
                                else sorteredEmployees = department.Employees.OrderByDescending(n => n.Name).ThenByDescending(n => n.WorkPlace).ToList();
                                break;
                            case Enums.EmployeeFields.wage:
                                if (department.employeeSort.SortBy == Enums.SortType.ASC) sorteredEmployees = department.Employees.OrderBy(n => n.Name).ThenBy(n => n.Wage).ToList();
                                else sorteredEmployees = department.Employees.OrderByDescending(n => n.Name).ThenByDescending(n => n.Wage).ToList();
                                break;
                        }                        
                        break;

                    case Enums.EmployeeFields.surname:
                        switch (department.employeeSort.ColumnSecond)
                        {
                            case Enums.EmployeeFields.name:
                                if (department.employeeSort.SortBy == Enums.SortType.ASC) sorteredEmployees = department.Employees.OrderBy(n => n.Surname).ThenBy(n => n.Name).ToList();
                                else sorteredEmployees = department.Employees.OrderByDescending(n => n.Surname).ThenByDescending(n => n.Name).ToList();
                                break;
                            case Enums.EmployeeFields.age:
                                if (department.employeeSort.SortBy == Enums.SortType.ASC) sorteredEmployees = department.Employees.OrderBy(n => n.Surname).ThenBy(n => n.Age).ToList();
                                else sorteredEmployees = department.Employees.OrderByDescending(n => n.Surname).ThenByDescending(n => n.Age).ToList();
                                break;
                            case Enums.EmployeeFields.workplace:
                                if (department.employeeSort.SortBy == Enums.SortType.ASC) sorteredEmployees = department.Employees.OrderBy(n => n.Surname).ThenBy(n => n.WorkPlace).ToList();
                                else sorteredEmployees = department.Employees.OrderByDescending(n => n.Surname).ThenByDescending(n => n.WorkPlace).ToList();
                                break;
                            case Enums.EmployeeFields.wage:
                                if (department.employeeSort.SortBy == Enums.SortType.ASC) sorteredEmployees = department.Employees.OrderBy(n => n.Surname).ThenBy(n => n.Wage).ToList();
                                else sorteredEmployees = department.Employees.OrderByDescending(n => n.Surname).ThenByDescending(n => n.Wage).ToList();
                                break;
                        }                        
                        break;

                    case Enums.EmployeeFields.age:
                        switch (department.employeeSort.ColumnSecond)
                        {
                            case Enums.EmployeeFields.name:
                                if (department.employeeSort.SortBy == Enums.SortType.ASC) sorteredEmployees = department.Employees.OrderBy(n => n.Age).ThenBy(n => n.Name).ToList();
                                else sorteredEmployees = department.Employees.OrderByDescending(n => n.Age).ThenByDescending(n => n.Name).ToList();
                                break;
                            case Enums.EmployeeFields.surname:
                                if (department.employeeSort.SortBy == Enums.SortType.ASC) sorteredEmployees = department.Employees.OrderBy(n => n.Age).ThenBy(n => n.Surname).ToList();
                                else sorteredEmployees = department.Employees.OrderByDescending(n => n.Age).ThenByDescending(n => n.Surname).ToList();
                                break;
                            case Enums.EmployeeFields.workplace:
                                if (department.employeeSort.SortBy == Enums.SortType.ASC) sorteredEmployees = department.Employees.OrderBy(n => n.Age).ThenBy(n => n.WorkPlace).ToList();
                                else sorteredEmployees = department.Employees.OrderByDescending(n => n.Age).ThenByDescending(n => n.WorkPlace).ToList();
                                break;
                            case Enums.EmployeeFields.wage:
                                if (department.employeeSort.SortBy == Enums.SortType.ASC) sorteredEmployees = department.Employees.OrderBy(n => n.Age).ThenBy(n => n.Wage).ToList();
                                else sorteredEmployees = department.Employees.OrderByDescending(n => n.Age).ThenByDescending(n => n.Wage).ToList();
                                break;
                        }                        
                        break;

                    case Enums.EmployeeFields.workplace:
                        switch (department.employeeSort.ColumnSecond)
                        {
                            case Enums.EmployeeFields.name:
                                if (department.employeeSort.SortBy == Enums.SortType.ASC) sorteredEmployees = department.Employees.OrderBy(n => n.WorkPlace).ThenBy(n => n.Name).ToList();
                                else sorteredEmployees = department.Employees.OrderByDescending(n => n.WorkPlace).ThenByDescending(n => n.Name).ToList();
                                break;
                            case Enums.EmployeeFields.surname:
                                if (department.employeeSort.SortBy == Enums.SortType.ASC) sorteredEmployees = department.Employees.OrderBy(n => n.WorkPlace).ThenBy(n => n.Surname).ToList();
                                else sorteredEmployees = department.Employees.OrderByDescending(n => n.WorkPlace).ThenByDescending(n => n.Surname).ToList();
                                break;
                            case Enums.EmployeeFields.age:
                                if (department.employeeSort.SortBy == Enums.SortType.ASC) sorteredEmployees = department.Employees.OrderBy(n => n.WorkPlace).ThenBy(n => n.Age).ToList();
                                else sorteredEmployees = department.Employees.OrderByDescending(n => n.WorkPlace).ThenByDescending(n => n.Age).ToList();
                                break;
                            case Enums.EmployeeFields.wage:
                                if (department.employeeSort.SortBy == Enums.SortType.ASC) sorteredEmployees = department.Employees.OrderBy(n => n.WorkPlace).ThenBy(n => n.Wage).ToList();
                                else sorteredEmployees = department.Employees.OrderByDescending(n => n.WorkPlace).ThenByDescending(n => n.Wage).ToList();
                                break;
                        }                        
                        break;

                    case Enums.EmployeeFields.wage:
                        switch (department.employeeSort.ColumnSecond)
                        {
                            case Enums.EmployeeFields.name:
                                if (department.employeeSort.SortBy == Enums.SortType.ASC) sorteredEmployees = department.Employees.OrderBy(n => n.Wage).ThenBy(n => n.Name).ToList();
                                else sorteredEmployees = department.Employees.OrderByDescending(n => n.Wage).ThenByDescending(n => n.Name).ToList();
                                break;
                            case Enums.EmployeeFields.surname:
                                if (department.employeeSort.SortBy == Enums.SortType.ASC) sorteredEmployees = department.Employees.OrderBy(n => n.Wage).ThenBy(n => n.Surname).ToList();
                                else sorteredEmployees = department.Employees.OrderByDescending(n => n.Wage).ThenByDescending(n => n.Surname).ToList();
                                break;
                            case Enums.EmployeeFields.age:
                                if (department.employeeSort.SortBy == Enums.SortType.ASC) sorteredEmployees = department.Employees.OrderBy(n => n.Wage).ThenBy(n => n.Age).ToList();
                                else sorteredEmployees = department.Employees.OrderByDescending(n => n.Wage).ThenByDescending(n => n.Age).ToList();
                                break;
                            case Enums.EmployeeFields.wage:
                                if (department.employeeSort.SortBy == Enums.SortType.ASC) sorteredEmployees = department.Employees.OrderBy(n => n.Wage).ThenBy(n => n.WorkPlace).ToList();
                                else sorteredEmployees = department.Employees.OrderByDescending(n => n.Wage).ThenByDescending(n => n.WorkPlace).ToList();
                                break;
                        }                        
                        break;
                    default:
                        sorteredEmployees = department.Employees;
                        break;
                }
            }

            return sorteredEmployees;
        }
    }
}
