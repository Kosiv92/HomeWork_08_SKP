using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HomeWork_08_SKP.Services;

namespace HomeWork_08_SKP
{
    class Employee
    {

        private static int _id = 1;
        
        #region Свойства

        /// <summary>
        /// Идентификатор сотрудника
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Фамилия сотрудника
        /// </summary>
        public string Surname { get; set; }

        /// <summary>
        /// Имя сотрудника
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Возраст сотрудника
        /// </summary>
        public int Age { get; set; }

        /// <summary>
        /// Департамент в котором работает сотрудник
        /// </summary>
        public Department WorkPlace { get; set; }

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
            return $"{Id, -(CheckUserInput.maxLengthId)} {Name, -(CheckUserInput.maxLengthName)} {Surname, -(CheckUserInput.maxLengthName)} {Age, -(CheckUserInput.maxLengthAge)} {WorkPlace.Name, -(CheckUserInput.maxLengthName)} {Wage, -(CheckUserInput.maxLengthWage)}";
        }

        /// <summary>
        /// Метод получения ID для нового сотрудника
        /// </summary>
        /// <returns></returns>
        public static int getIDForNewEmployee()
        {
            int newID = _id;

            _id++;

            return newID;
        }
               

        #endregion
    }
}
