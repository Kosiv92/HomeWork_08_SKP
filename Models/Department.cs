using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HomeWork_08_SKP.Services;

namespace HomeWork_08_SKP
{
    class Department
    {
        //Поле хранящее список сотрудников департамента
        private List<Employee> _employees = new List<Employee>();

        #region Свойства

        /// <summary>
        /// Наименование департамента
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Дата создания департамента
        /// </summary>
        public DateTime DateOfCreation { get; set; }              

        /// <summary>
        /// Свойство доступа к списку сотрудников департамента
        /// </summary>
        public List<Employee> Employees { get{ return _employees; } }

        /// <summary>
        /// Количество сотрудников департамента
        /// </summary>
        public int NumberOfEmployees { get { return _employees.Count; } }               

        #endregion

        #region Методы

        public override string ToString()
        {
            return $"{Name, -(CheckUserInput.maxLengthName)} {DateOfCreation.ToString("d"), -(CheckUserInput.maxLengthDate)} {NumberOfEmployees, -(CheckUserInput.maxLengthEmployeesCount)}";
        }

        public void Edit()
        {
            throw new NotImplementedException();
        }

        public void Remove()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
