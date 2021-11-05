using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HomeWork_08_SKP.Services;
using HomeWork_08_SKP.Enums;
namespace HomeWork_08_SKP
{
    /// <summary>
    /// Статический класс содержащий методы взаимодействия с пользователем посредством командной строки
    /// </summary>
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
        /// Метод получения от пользователя данных и редактирования департамента
        /// </summary>
        public static void EditExistsDepartment(List<Department> departments)
        {
            Console.WriteLine("Укажите департамент, который необходимо отредактировать:");
            Department departmentForChange = departments[ChooseNumberOfDepartment(false) - 1];
            Console.WriteLine($"Вы выбрали департамент \"{departmentForChange.Name}\" для редактирования");
            string nameOfDepartment = InputName("новое имя департамента");
            Console.WriteLine($"Текущая дата создания департамента - {departmentForChange.DateOfCreation}. Укажите новую дату создания департамента.");
            DateTime dateOfCreation = InputDateOfCreate();
            departmentForChange.Edit(nameOfDepartment, dateOfCreation);
            Console.WriteLine("Редактирование департамента произведено успешно");
            Console.ReadKey();
        }

        /// <summary>
        /// Метод получения от пользователя данных и редактирования департамента
        /// </summary>
        /// <param name="departments">Список департаментов в одном из которых состоит сотрудник</param>
        public static void EditExistsEmployee(List<Department> departments)
        {
            Console.WriteLine("Укажите департамент, в котором состоит сотрудник которого необходимо отредактировать:");
            int numberOfDeletedEmployee = ChooseNumberOfDepartment(false) - 1;
            Department oldDepartmentOfEmployee = departments[numberOfDeletedEmployee];
            Console.WriteLine($"Выберите сотрудника из списка сотрудников департамента \"{oldDepartmentOfEmployee.Name}\":");
            Employee employeeForEdit = oldDepartmentOfEmployee.Employees[ChooseNumberOfEmployee(oldDepartmentOfEmployee) - 1];
            Console.WriteLine($"Вы выбрали департамент сотрудника \n{employeeForEdit} для редактирования");
            string name = InputName("новое имя сотрудника");
            string surname = InputName("новую фамилию сотрудника");
            int age = InputAgeEmployee();
            Department newDepartmentOfEmployee = ChooseDepartmentForEmployee();
            int wage = InputWageEmployee();
            employeeForEdit.Edit(name, surname, age, newDepartmentOfEmployee, wage);
            oldDepartmentOfEmployee.Employees = ModificationOfOrganizationUnits.DeleteEmployee(oldDepartmentOfEmployee, numberOfDeletedEmployee);
            newDepartmentOfEmployee.Employees.Add(employeeForEdit);
            Console.WriteLine("Редактирование сотрудника успешно произведено");
            Console.ReadKey();
        }

        /// <summary>
        /// Метод выбора сотрудника в департаменте и его удаления
        /// </summary>        
        public static void DeleteEmployeeFromDepartment()
        {
            Console.WriteLine("Укажите порядковый номер департамента, в котором находится работает сотрудник:");

            Department departmentOfDeletedEmployee = Organization.Departments[UserConsoleInputOutput.ChooseNumberOfDepartment(true) - 1];

            int choiceByUser = 0;

            List<Employee> modifiedListOfEmployees = new List<Employee>();

            Console.WriteLine("Укажите порядковый номер сотрудника, которого необходимо удалить:");

            choiceByUser = UserConsoleInputOutput.ChooseNumberOfEmployee(departmentOfDeletedEmployee);

            string nameOfDeletedEmployee = departmentOfDeletedEmployee.Employees[choiceByUser - 1].Name + " " + departmentOfDeletedEmployee.Employees[choiceByUser - 1].Surname;

            departmentOfDeletedEmployee.Employees = ModificationOfOrganizationUnits.DeleteEmployee(departmentOfDeletedEmployee, choiceByUser - 1);

            Console.WriteLine($"Работник {nameOfDeletedEmployee} успешно удален");

            Console.ReadKey();
        }

        /// <summary>
        /// Метод выбора департамента в организации и его удаления
        /// </summary>
        public static void DeleteDepartmentFromOrganization()
        {
            Console.WriteLine("Укажите порядковый номер департамента, который необходимо удалить:");

            int numberOfDeletedDepartment = UserConsoleInputOutput.ChooseNumberOfDepartment(false);

            string nameOfDeletedDepartment = Organization.Departments[numberOfDeletedDepartment - 1].Name;

            ModificationOfOrganizationUnits.DeleteDepartment(numberOfDeletedDepartment);

            Console.WriteLine($"Департамент {nameOfDeletedDepartment} успешно удален");
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
            else if (!CheckUserInput.CheckNumberOfEmployeesInDepartment(Organization.Departments[0]))
            {
                Console.WriteLine($"В единственном существующем департаменте максимально возможное количество сотрудников (>={CheckUserInput.maxLengthEmployeesCount}). Создайте новый департамент для добавления новых сотрудников.");
            }
            else
            {
                Employee newEmployee = new Employee();

                newEmployee.Name = InputName("имя сотрудника");

                newEmployee.Surname = InputSurnameEmployee();

                newEmployee.Age = InputAgeEmployee();

                Console.WriteLine();

                Department departmentOfEmployee = ChooseDepartmentForEmployee();

                newEmployee.WorkPlace = departmentOfEmployee;

                newEmployee.Wage = InputWageEmployee();

                //newEmployee.Id = Employee.getIDForNewEmployee();

                departmentOfEmployee.Employees.Add(newEmployee);

                Console.WriteLine("Новый сотрудник успешно добавлен!");

            }
            Console.ReadKey();
        }

        /// <summary>
        /// Метод проверки намерения пользователя ввести текущую дату
        /// </summary>
        /// <returns>Результа проверки</returns>
        public static bool InputTodayDate()
        {
            bool isToday = false;
            string[] dateMenu = { "Задать дату создания департамента настоящим днем", "Установить дату создания департамента вручную" };
            int choiceByUser = Menu.ChooseMenuItem(dateMenu);
            int choiceByUser1 = choiceByUser;
            switch (choiceByUser)
            {
                case 0:
                    isToday = true;
                    break;
                case 1:
                    isToday = false;
                    break;
            }
            return isToday;
        }

        /// <summary>
        /// Метод ввода пути к файлу с сериализованными данными пользователем
        /// </summary>
        /// <param name="type">Тип используемой сериализации (true - XML, false - JSON)</param>
        /// <returns>Путь к файлу</returns>
        public static string InputPathToDirectory(SerializeType type, bool isUpload)
        {
            if (!isUpload)
            {
                Console.Write("Структура организации будет сохранена в файл \"Departments\". " +
           "\nУкажите директорию в которой необходимо создать файл с сериализованными данными в формате - \"D:\\MyFiles\": ");
            }
            else
            {
                Console.Write("Структура организации будет загружена из файла \"Departments\". " +
           "\nУкажите директорию в которой находится файл с сериализованными данными в формате - \"D:\\MyFiles\": ");
            }

            string path;

            bool check = false;

            do
            {
                path = Console.ReadLine();
                check = CheckUserInput.CheckPathToDirectory(path);
                if (!check)
                {
                    Console.WriteLine("Директория указана неверно. Введите путь к папке в формате - \"D:\\MyFiles\": ");
                    Console.ReadKey();
                }
                else
                {
                    path = AddFileName(path, type);
                    if (isUpload)
                    {
                        check = CheckUserInput.CheckFileExists(path);
                        if (!check)
                        {
                            Console.WriteLine("Файл \"Departments\" отсутствует по указанному пути. Введите путь к папке, содержащей файл:");
                        }
                    }
                }

            } while (!check);

            ///Локальный метод для добавления имени файла в полный путь к файлу
            static string AddFileName(string path, SerializeType type)
            {
                string typeByUser;

                switch (type)
                {
                    case SerializeType.XML:
                        typeByUser = "Departments.xml";
                        break;
                    case SerializeType.JSON:
                        typeByUser = "Departments.json";
                        break;
                    default:
                        typeByUser = null;
                        break;
                }

                return path + typeByUser;

            }

            return path;
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
                if (!check) Console.WriteLine($"Строка должна содержать только буквы и не превышать {CheckUserInput.maxLengthName} символов");
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

            //если существует только один департамент то новый сотрудник автоматически добавляется в него
            if (CheckUserInput.CheckAloneDepartment())
            {

                Console.WriteLine($"Пользователь добавлен в единственный существующий департамент - {Organization.Departments[0].Name}");
                Console.ReadKey();
                return Organization.Departments[0];
            }

            Console.WriteLine("Введите номер департамента в который необходимо добавить сотрудника:");



            return Organization.Departments[ChooseNumberOfDepartment(true) - 1];

        }

        /// <summary>
        /// Метод выбора порядкового номера департамента пользователелм
        /// </summary>
        /// <param name="isAddEmployee">Используется ли метод для добавления нового пользователя в департамент</param>
        /// <returns>Порядковый номер департамента</returns>
        public static int ChooseNumberOfDepartment(bool isAddEmployee)
        {

            ListToConsole.PrintListDepartments(Organization.Departments);

            int choiceByUser = 0; //выбранный пользователем департамент

            bool checkChoiceByUser = false; //булево правильности ввода пользователя

            Console.Write("Введите число: ");

            //проверка ввода пользователем номера департамента
            do
            {
                checkChoiceByUser = CheckUserInput.CheckDepartment(Console.ReadLine(), ref choiceByUser);

                if (!checkChoiceByUser)
                {
                    Console.WriteLine($"Некорректный ввод. Пожалуйста введите число больше нуля но не превышающее количества существующих департаментов - {Organization.Departments.Count}:");
                    Console.ReadKey();
                    continue;
                }

                checkChoiceByUser = CheckUserInput.CheckNumberOfEmployeesInDepartment(Organization.Departments[choiceByUser - 1]);
                if (!checkChoiceByUser && isAddEmployee)
                {
                    Console.WriteLine($"В выбранном департаменте максимально допустимое количество сотрудников. Выберите другой департамент.");
                    Console.ReadKey();
                }

            } while (!checkChoiceByUser);

            return choiceByUser;
        }

        /// <summary>
        /// Метод выбора порядкового номера работника в департаменте пользователелм
        /// </summary>
        /// <param name="department">Департамент среди работников которого производится выбор</param>
        /// <returns>Порядковый номер сотрудника</returns>
        public static int ChooseNumberOfEmployee(Department department)
        {
            int choiceByUser = 0; //выбранный пользователем департамент

            bool checkChoiceByUser = false; //булево правильности ввода пользователя

            ListToConsole.PrintEmployeesOfDepartment(department, false);

            Console.Write("Введите число: ");

            do
            {
                checkChoiceByUser = CheckUserInput.CheckEmployee(Console.ReadLine(), department, ref choiceByUser);

                if (!checkChoiceByUser)
                {
                    Console.WriteLine($"Некорректный ввод. Пожалуйста введите число больше нуля но не превышающее количества работников в департаменте - {department.Employees.Count}:");
                    Console.ReadKey();
                }

            } while (!checkChoiceByUser);

            return choiceByUser;

        }

        /// <summary>
        /// Выбор пользователем списка сотрудников для вывода на экран консоли
        /// </summary>
        public static void ChooseListOfEmployeesToPrint()
        {
            string[] employeeMenu = { "Глобальный список", "Список определенного департамента" };
            Console.WriteLine("Укажите список сотрудников для вывода на экран консоли:");
            int choiceOfUser = Menu.ChooseMenuItem(employeeMenu);
            switch (choiceOfUser)
            {
                case 0:
                    ListToConsole.PrintListAllEmployees();
                    break;
                case 1:
                    SetConditionOfPrintEmployees();
                    break;
            };
        }

        /// <summary>
        /// Настройка условий вывода в окно консоли списка сотрудников департамента
        /// </summary>
        public static void SetConditionOfPrintEmployees()
        {
            Console.WriteLine("Укажите номер департамента список сотрудников которого необходимо вывести в окно консоли:");
            Department department = Organization.Departments[ChooseNumberOfDepartment(false) - 1];
            bool isSortOn = TurnOnSort();
            if (isSortOn)
            {
                department.employeeSort = new EmployeeSort();
                SetConditionOfSortEmployees(department);
            }
            ListToConsole.PrintEmployeesOfDepartment(department, isSortOn);
        }

        /// <summary>
        /// Настройка условий фильтрации списка сотрудников
        /// </summary>
        /// <param name="department"></param>
        public static void SetConditionOfSortEmployees(Department department)
        {
            string[] countOfColumns = { "Произвести сортировку по одному полю", "Произвести сортировку по двум полям" };
            int choiceByUser = Menu.ChooseMenuItem(countOfColumns);

            department.employeeSort.IsSortedTwice = choiceByUser switch
            {
                0 => false,
                1 => true
            };

            department.employeeSort.ColumnFirst = ChooseColumnOfDepartment(department, "первому");

            if (department.employeeSort.IsSortedTwice == true)
            {
                do
                {
                    department.employeeSort.ColumnSecond = ChooseColumnOfDepartment(department, "второму");
                    if (department.employeeSort.ColumnFirst == department.employeeSort.ColumnSecond)
                    {
                        Console.WriteLine("Поля по которым будет производиться последовательная сортировка должны отличаться. Попробуйте снова");
                        Console.ReadKey();
                    }
                    else break;
                } while (true);
            }

            string[] sortType = { "Использовать прямую сортировку (по-возрастанию)", "Использовать обратную сортировку (по-убыванию)" };
            choiceByUser = Menu.ChooseMenuItem(sortType);
            department.employeeSort.SortBy = choiceByUser switch
            {
                0 => SortType.ASC,
                1 => SortType.DESC
            };

        }

        /// <summary>
        /// Метод выбора поля сотрудника по которому будет производиться сортировка
        /// </summary>
        /// <param name="department">Департамент содержащий сортируемых сотрудников</param>
        public static EmployeeFields ChooseColumnOfDepartment(Department department, string kindOfField)
        {
            string[] employeeColumns = { $"Произвести сортировку по {kindOfField} полю - \"Имя\"", $"Произвести сортировку по {kindOfField} полю - \"Фамилия\"", $"Произвести сортировку по {kindOfField} полю - \"Возраст\"", $"Произвести сортировку по {kindOfField} полю - \"Департамент\"", $"Произвести сортировку по {kindOfField} полю - \"Зар.плата\"" };
            int choiceByUser = Menu.ChooseMenuItem(employeeColumns);

            EmployeeFields field = choiceByUser switch
            {
                0 => EmployeeFields.name,
                1 => EmployeeFields.surname,
                2 => EmployeeFields.age,
                3 => EmployeeFields.workplace,
                4 => EmployeeFields.wage
            };
            return field;
        }


        /// <summary>
        /// Метод включения/выключения пользователем сортировки списка сотрудников 
        /// </summary>
        /// <returns>Булево: Истина - сорт. вкл; Ложь - сорт. выкл</returns>
        public static bool TurnOnSort()
        {
            string[] sortMenu = { "Включить сортировку списка сотрудников", "Не включать сортировку списка сотрудников" };
            int choiceOfUser = Menu.ChooseMenuItem(sortMenu);
            bool isSortOn = choiceOfUser switch
            {
                0 => true,
                1 => false,
                _ => false
            };
            return isSortOn;
        }

        /// <summary>
        /// Метод ввода возраста сотрудника пользователем
        /// </summary>
        /// <returns></returns>
        static int InputAgeEmployee()
        {
            int age = 0;
            bool checkInputByUser = false;

            Console.Write("Введите возраст сотрудника: ");

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

            if (InputTodayDate()) date = DateTime.Today;
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
