using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_08_SKP.Services
{
    static class CheckUserInput
    {
        #region Константы
        
        /// <summary>
        /// Максимальная длина поля id-номера
        /// </summary>
        public const int maxLengthId = 7;
        
        /// <summary>
        /// Максимальная длина поля имени/наименования
        /// </summary>
        public const int maxLengthName = 20;

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
            if (name.All(Char.IsLetter) && name.Length < maxLengthName && name != null) return true;
            else
            {
                Console.WriteLine($"Строка должна состоять только из букв и не превышать {maxLengthName} символов. Повторите ввод...");
                return false;
            }
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
            bool checkChoiceByUser = CheckUserInput.CheckNumber(input, ref number);
            return checkChoiceByUser && number > 0 && number <= Organization.Departments.Count;
        }

        /// <summary>
        /// Метод проверки существования в организации единственного департамента
        /// </summary>
        /// <returns>Результат проверки</returns>
        public static bool CheckAloneDepartment()
        {
            if (Organization.Departments.Count == 1)
            {
                Console.WriteLine($"Сотрудник добавлен в департамент {Organization.Departments[0].Name}");
                Console.ReadKey();
                return true;
            }
            else return false;
        }

        /// <summary>
        /// Метод проверки намерения пользователя ввести текущую дату
        /// </summary>
        /// <returns>Результа проверки</returns>
        public static bool CheckChoiceToday()
        {
            bool isToday = false;
            string[] dateMenu = { "Да", "Нет" };
            Console.WriteLine("Установить сегодняшнюю дату?");
            int choiceByUser = Menu.ChooseMenuItem(dateMenu);
            int choiceByUser1 = choiceByUser;
            switch (choiceByUser)
            {
                case 1:
                    isToday = true;
                    break;
                case 2:
                    isToday = false;
                    break;
            }
            return isToday;
        }

        /// <summary>
        /// Метод проверки ввода пользователем даты
        /// </summary>
        /// <param name="input"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        public static bool CheckDate(string input, ref DateTime date)
        {
            return DateTime.TryParse(input, out date);
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
