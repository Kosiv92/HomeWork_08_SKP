using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using HomeWork_08_SKP.Services;
using Newtonsoft.Json;
using HomeWork_08_SKP.Enums;

namespace HomeWork_08_SKP
{
    
    [JsonObject(IsReference = true)]
    [DataContract(Name = "Department")]    
    public class Department : OrganizationUnit
    {
        //Поле хранящее список сотрудников департамента
        private List<Employee> _employees = new List<Employee>(); 
        
        //Поле хранящее ссылку на вспомогательный объет хранящий настройки для сортировки коллекции сотрудников данного департамента
        [JsonIgnore]
        public EmployeeSort employeeSort;

        #region Свойства                

        [DataMember(Name = "DateOfCreation")]
        /// <summary>
        /// Дата создания департамента
        /// </summary>
        public DateTime DateOfCreation { get; set; }

        [DataMember(Name = "Employees")]
        /// <summary>
        /// Свойство доступа к списку сотрудников департамента
        /// </summary>
        public List<Employee> Employees { get { return _employees; } set => _employees = value; }

        [JsonIgnore] 
        /// <summary>
        /// Количество сотрудников департамента
        /// </summary>
        public int NumberOfEmployees { get { return _employees.Count; } }

        #endregion

        #region Методы                

        /// <summary>
        /// Переопределение метода вывода данного объекта в окно консоли
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{IDNumber,-(CheckUserInput.maxLengthId)} {Name, -(CheckUserInput.maxLengthName)} {DateOfCreation.ToString("d"), -(CheckUserInput.maxLengthDate)} {NumberOfEmployees, -(CheckUserInput.maxLengthEmployeesCount)}";
        }

        /// <summary>
        /// Редактирование данных департамента
        /// </summary>
        /// <param name="name">Новое имя департамента</param>
        /// <param name="dateOfEdit">Новая дата создания/реорганизации департамента</param>
        public void Edit(string name, DateTime dateOfEdit)
        {
            this.Name = name;

            this.DateOfCreation = dateOfEdit;
        }

        #endregion
    }

    /// <summary>
    /// Вспомогательный класс для хранения настроек сортировки списка сотрудников
    /// </summary>
    public class EmployeeSort
    {
        /// <summary>
        /// Поле класса сотрудник по которому будет происходить сортировка списка сотрудников если сортировка происходит только по одному полю
        /// </summary>
        public EmployeeFields ColumnFirst { get; set; }

        /// <summary>
        /// Поле класса сотрудник по которому будет происходить дополнительная сортировка списка сотрудников если сортировка происходит по двум полям
        /// </summary>
        public EmployeeFields ColumnSecond { get; set; }
        
        /// <summary>
        /// Тип сортировки (по возрастанию/по убыванию)
        /// </summary>
        public SortType SortBy { get; set; }
        
        /// <summary>
        /// Будет ли производиться сортировка по двум полям
        /// </summary>
        public bool IsSortedTwice { get; set; }

    }
}
