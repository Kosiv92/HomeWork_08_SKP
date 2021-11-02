using System;
using System.Runtime.Serialization;
using HomeWork_08_SKP.Services;
using Newtonsoft.Json;

namespace HomeWork_08_SKP
{
    [DataContract(Name = "Employee")]
    public class Employee : OrganizationUnit
    {                

        #region Свойства                

        [DataMember(Name = "Surname")]
        /// <summary>
        /// Фамилия сотрудника
        /// </summary>
        public string Surname { get; set; }                

        [DataMember(Name = "Age")]
        /// <summary>
        /// Возраст сотрудника
        /// </summary>
        public int Age { get; set; }

        [DataMember(Name = "WorkPlace")]
        /// <summary>
        /// Департамент в котором работает сотрудник
        /// </summary>
        public Department WorkPlace { get; set; }

        [DataMember(Name = "Wage")]
        /// <summary>
        /// Размер заработной платы сотрудника
        /// </summary>
        public int Wage { get; set; }

        #endregion

        #region Методы                

        /// <summary>
        /// Метод вывода данных о сотруднике на экран консоли
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{IDNumber,-(CheckUserInput.maxLengthId)} {Name,-(CheckUserInput.maxLengthName)} {Surname,-(CheckUserInput.maxLengthName)} {Age,-(CheckUserInput.maxLengthAge)} {WorkPlace.Name,-(CheckUserInput.maxLengthName)} {Wage,-(CheckUserInput.maxLengthWage)}";
        }

        /// <summary>
        /// Редактирование данных департамента
        /// </summary>
        /// <param name="name">Новое имя сотрудника</param>
        /// <param name="surname">Новая фамилия сотрудника</param>
        /// <param name="age">Новый возраст сотрудника</param>
        /// <param name="department">Новый департамент где работает сотрудник</param>
        /// <param name="wage">Новый размер зар.платы сотрудника</param>
        public void Edit(string name, string surname, int age, Department department, int wage)
        {
            this.Name = name;            
            this.Surname = surname;
            this.Age = age;
            this.WorkPlace = department;
            this.Wage = wage;

        }


        #endregion
    }
}
