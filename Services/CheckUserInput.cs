using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_08_SKP.Services
{
    /// <summary>
    /// Статический класс содержащий методы проверки данны вводимых пользователем, а также константы значений задающих условия проверки
    /// </summary>
    static class CheckUserInput
    {
        #region Константы

        /// <summary>
        /// Максимальная длина поля id-номера
        /// </summary>
        public const int maxLengthId = 37;

        /// <summary>
        /// Максимальная длина поля имени/наименования
        /// </summary>
        public const int maxLengthName = 30;

        /// <summary>
        /// Максимальная длина поля возраста сотрудника
        /// </summary>
        public const int maxLengthAge = 8;

        /// <summary>
        /// Максимальная длина поля заработной платы сотрудника
        /// </summary>
        public const int maxLengthWage = 7;

        /// <summary>
        /// Максимальная длина поля даты создания
        /// </summary>
        public const int maxLengthDate = 14;

        /// <summary>
        /// Максимальная длина поля количества сотрудников
        /// </summary>
        public const int maxLengthEmployeesCount = 15;

        /// <summary>
        /// Минимальный размер оплаты труда
        /// </summary>
        public const int mrot = 12_792;

        /// <summary>
        /// Максимаьный зарегистрированный возраст человека
        /// </summary>
        const int maxRegistredAge = 122;

        /// <summary>
        /// Максимаьное допустимое количество сотрудников в департаменте
        /// </summary>
        const int maxNumberOfEmployees = 1_000_000;

        #endregion

        #region Методы

        /// <summary>
        /// Метод проверки существования департаментов
        /// </summary>
        /// <returns>Результат проверки</returns>
        public static bool DepartmentsExists()
        {
            if (Organization.Departments.Count == 0) return false;
            else return true;
        }

        /// <summary>
        /// Проверка вводимого пользователем имени/фамилии/наименования 
        /// </summary>
        /// <param name="name">Имя/фамилия сотрудника или название департамента</param>
        /// <returns>Результат проверки</returns>
        public static bool CheckName(string name)
        {
            if (name.All(Char.IsLetter) && name.Length < maxLengthName && name != null && !CheckEmptyString(name)) return true;
            else return false;            
        }

        /// <summary>
        /// Метод проверки возраста введенного пользователем
        /// </summary>
        /// <param name="input">Ввод пользователя</param>
        /// <param name="age">Значение возраста</param>
        /// <returns>Результат проверки</returns>
        public static bool CheckAge(string input, ref int age)
        {

            bool isNumber = CheckNumber(input, ref age);

            return isNumber && age > 18 && age < CheckUserInput.maxRegistredAge;

        }

        /// <summary>
        /// Метод проверки размера зар.платы введенного пользователем
        /// </summary>
        /// <param name="input">Ввод пользователя</param>
        /// <param name="wage">Размер зар.платы</param>
        /// <returns>Результат проверки</returns>
        public static bool CheckWage(string input, ref int wage)
        {

            bool isNumber = CheckNumber(input, ref wage);
            return isNumber && wage >= mrot;

        }

        /// <summary>
        /// Метод проверки выбранного пользователем департамента
        /// </summary>
        /// <param name="input">Ввод пользователя</param>
        /// <param name="number">Номер департамента</param>
        /// <returns>Результат проверки</returns>
        public static bool CheckDepartment(string input, ref int number)
        {
            bool checkChoiceByUser = CheckNumber(input, ref number);
            return checkChoiceByUser && number > 0 && number <= Organization.Departments.Count;
        }

        /// <summary>
        /// Метод проверки выбранного пользователем работника
        /// </summary>
        /// <param name="input">Ввод пользователя</param>
        /// <param name="number">Номер работника</param>
        /// <returns>Результат проверки</returns>
        public static bool CheckEmployee(string input, Department department, ref int number)
        {
            bool checkChoiceByUser = CheckNumber(input, ref number);
            return checkChoiceByUser && number > 0 && number <= department.Employees.Count;
        }

        /// <summary>
        /// Метод проверки существования в организации единственного департамента
        /// </summary>
        /// <returns>Результат проверки</returns>
        public static bool CheckAloneDepartment()
        {
            if (Organization.Departments.Count == 1) return true;
            else return false;
        }

        /// <summary>
        /// Метод проверки ввода пользователем даты
        /// </summary>
        /// <param name="input">Ввод пользователя</param>
        /// <param name="date">Дата полученная путем преобразования ввода пользователя</param>
        /// <returns>Результат проверки</returns>
        public static bool CheckDate(string input, ref DateTime date)
        {
            return DateTime.TryParse(input, out date);
        }

        /// <summary>
        /// Метод проверки ввода пользователем пути к директории в системе
        /// </summary>
        /// <param name="path">Ввод пользователя</param>
        /// <returns>Результат проверки</returns>
        public static bool CheckPathToDirectory(string path)
        {
            if (!CheckEmptyString(path) && Directory.Exists(path)) return true;
            else return false;
        }

        /// <summary>
        /// Метод проверки существования файла по указанному пути 
        /// </summary>
        /// <param name="path">Путь к файлу</param>
        /// <returns>Результат проверки</returns>
        public static bool CheckFileExists(string path)
        {
            if (File.Exists(path)) return true;
            else return false;
        }

        /// <summary>
        /// Проверка количества сотрудников в департаменте на число большее или равное одному миллиону 
        /// </summary>
        /// <param name="numberOfDepartment"></param>
        /// <returns></returns>
        public static bool CheckNumberOfEmployeesInDepartment(Department department)
        {
            if (department.NumberOfEmployees >= maxNumberOfEmployees) return false;
            else return true;
        }

        /// <summary>
        /// Метод проверки на пустую строку
        /// </summary>
        /// <param name="input">Строка для проверки</param>
        /// <returns>Результат проверки</returns>
        private static bool CheckEmptyString(string input)
        {
            if (input == "" || input == " " || input == null) return true;
            else return false;
        }

        /// <summary>
        /// Метод проверки ввода пользователем числа
        /// </summary>
        /// <param name="number">Ввод пользователя</param>
        /// <returns>Результат проверки</returns>
        private static bool CheckNumber(string input, ref int number)
        {
            return Int32.TryParse(input, out number);
        }

        #endregion

    }
}
