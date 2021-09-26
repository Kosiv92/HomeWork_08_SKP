using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HomeWork_08_SKP.Services;

namespace HomeWork_08_SKP
{
    class UserConsoleInputOutput
    {
        /// <summary>
        /// Метод получения данных о новом департаменте
        /// </summary>
        public static void CreateNewDepartment()
        {
            Console.Clear();

            Department newDepartment = new Department();

            newDepartment.Name = InputName("наименование департамента");

            newDepartment.DateOfCreation = InputDateOfCreate();

            Organization.Departments.Add(newDepartment);
        }

        /// <summary>
        /// Метод получения данных о новом сотруднике от пользователя
        /// </summary>
        /// <returns>Новый сотрудник</returns>
        public static void CreateNewEmployee()
        {
            Guid guid = Guid.NewGuid();
            
            Console.Clear();

            if (!CheckUserInput.DepartmentsExists())
            {
                Console.WriteLine("В организации не создан ни один департамент. \nПеред тем как добавлять сотрудника создайте департамент в котором он будет числится.");
               
            }
            else
            {
                Employee newEmployee = new Employee();

                newEmployee.Name = InputName("имя сотрудника");

                newEmployee.Surname = InputSurnameEmployee();

                newEmployee.Age = InputAgeEmployee();

                newEmployee.WorkPlace = ChooseDepartmentForEmployee();

                newEmployee.Wage = InputWageEmployee();

                string employeeData =$"{newEmployee.Name}{newEmployee.Surname}{newEmployee.Age}{newEmployee.WorkPlace}{newEmployee.Wage}";

                newEmployee.Id = guid.ToString(employeeData).Substring(0,6);                                

                newEmployee.WorkPlace.Employees.Add(newEmployee);                               

                Console.WriteLine("Новый сотрудник успешно добавлен!");
                
            }
            Console.ReadKey();
        }

        /// <summary>
        /// Метод ввода имени сотрудника пользователем
        /// </summary>
        /// <returns>Имя сотрудника</returns>
        static string InputName(string purpose)
        {
            Console.Write($"Введите {purpose}: ");

            string name;
            bool check = false;
            do
            {
                name = Console.ReadLine();
                check = CheckUserInput.CheckName(name);
                Console.WriteLine();
            } while (!check);

            return name;
        }

        /// <summary>
        /// Метод ввода фамилии сотрудника пользователем
        /// </summary>
        /// <returns>Фамилия сотрудника</returns>
        static string InputSurnameEmployee()
        {
            Console.Write("Введите фамилию сотрудника: ");

            string surname;
            bool check = false;
            do
            {
                surname = Console.ReadLine();
                check = CheckUserInput.CheckName(surname);
            } while (!check);

            return surname;
        }

        /// <summary>
        /// Метод выбора департамента сотрудника пользователем
        /// </summary>
        /// <returns></returns>
        static Department ChooseDepartmentForEmployee()
        {
            int countDepartments = Organization.Departments.Count;

            //если существует только один департамент то новый сотрудник автоматически добавляется в него
            if (CheckUserInput.CheckAloneDepartment()) return Organization.Departments[0];

            Console.WriteLine("Введите номер департамента в который необходимо добавить сотрудника:");

            //вывод в консоль списка департаментов
            for (int i = 0; i < countDepartments; i++)
            {
                Console.WriteLine($"{i + 1}. {Organization.Departments[i].Name}");
            }

            int choiceByUser = 0; //выбранный пользователем департамент

            bool checkChoiceByUser = false; //булево правильности ввода пользователя

            //проверка ввода пользователем номера департамента
            do
            {
                checkChoiceByUser = CheckUserInput.CheckDepartment(Console.ReadLine(), ref choiceByUser);

                if (!checkChoiceByUser)
                {
                    Console.WriteLine($"Некорректный ввод. Пожалуйста введите число больше нуля но не превышающее количества существующих департаментов - {Organization.Departments.Count}:");
                    Console.ReadKey();
                }
                else checkChoiceByUser = true;

            } while (!checkChoiceByUser);

            return Organization.Departments[choiceByUser + 1];

        }

        /// <summary>
        /// Метод ввода возраста сотрудника пользователем
        /// </summary>
        /// <returns></returns>
        static int InputAgeEmployee()
        {
            int age = 0;
            bool checkInputByUser = false;

            Console.WriteLine("Введите возраст сотрудника: ");

            do
            {
                string inputByUser = Console.ReadLine();
                checkInputByUser = CheckUserInput.CheckAge(inputByUser, ref age);
                if (checkInputByUser) continue;
                else
                {
                    Console.WriteLine($"Некорректный ввод. Пожалуйста введите корректный возраст сотрудника. Все сотрудники должны быть совершеннолетними:");
                    Console.ReadKey();
                }

            } while (!checkInputByUser);

            return age;

        }

        /// <summary>
        /// Метод ввода зар.платы сотрдуника пользователем
        /// </summary>
        /// <returns></returns>
        static int InputWageEmployee()
        {
            int wage = 0;
            bool checkInputByUser = false;

            Console.WriteLine("Введите размер заработной платы сотрудника: ");

            do
            {
                string inputByUser = Console.ReadLine();
                checkInputByUser = CheckUserInput.CheckWage(inputByUser, ref wage);
                if (checkInputByUser) continue;
                else
                {
                    Console.WriteLine($"Некорректный ввод. Пожалуйста введите корректный размер зар.платы сотрудника. " +
                        $"Зар.плата не может составлять менее прожиточного минимуму - {CheckUserInput.mrot} руб.");
                    Console.ReadKey();
                }

            } while (!checkInputByUser);

            return wage;
        }

        /// <summary>
        /// Метод ввода даты создания департамента
        /// </summary>
        /// <returns></returns>
        static DateTime InputDateOfCreate()
        {
            DateTime date = DateTime.MinValue;

            bool checkChoiceByUser = false;

            Console.WriteLine("Укажите дату создания департамента: ");

            Console.ReadKey();

            if (CheckUserInput.CheckChoiceToday()) date = DateTime.Today;
            else
            {
                Console.Write("Введите дату в формате ДД.ММ.ГГГГ:");
                do
                {
                    string inputByUser = Console.ReadLine();
                    checkChoiceByUser = CheckUserInput.CheckDate(inputByUser, ref date);
                    if (!checkChoiceByUser)
                    {
                        Console.Write("Некорректный ввод. Необходимо ввести дату в формате ДД.ММ.ГГГГ. Попробуйте снова:");
                        Console.ReadKey();
                    }
                } while (!checkChoiceByUser);
            }

            return date;

        }



    }
}
