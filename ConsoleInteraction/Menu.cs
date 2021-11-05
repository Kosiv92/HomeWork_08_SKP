using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HomeWork_08_SKP.Services;


namespace HomeWork_08_SKP
{
    /// <summary>
    /// Класс содержащий методы реализации пользовательского меню
    /// </summary>
    static class Menu
    {
        /// <summary>
        /// Метод выбора пункта меню
        /// </summary>
        /// <param name="menuItems">Массив содержащий пункты меню</param>
        /// <returns>Возвращает число обозначающее выбранный пользователем пункт меню</returns>
        public static int ChooseMenuItem(string[] menuItems)
        {
            int visibleChoice = 0; //счетчик выбранного пользователем пункта меню

            ConsoleKeyInfo buttonPressed; //нажимаемая пользователем клавиша

            while (true) //цикл использования меню
            {
                Console.Clear();

                for (int i = 0; i < menuItems.Length; i++) //цикл для определения положения выбора пользователя
                {
                    if (i == visibleChoice)
                        Console.Write(
                            "> "); //отображение положения пользователя в меню если счетчик совпадает с номером строки
                    else
                        Console.Write(
                            "  "); //отображение пробела (пустого места) в меню если счетчик не совпадает с номером строки
                    Console.WriteLine(menuItems[i]); //отображение пунктов меню
                }

                buttonPressed = Console.ReadKey();

                if (buttonPressed.Key == ConsoleKey.UpArrow && visibleChoice != 0)
                    visibleChoice--; //уменьшение счетчика если нажата клавиша "вверх" и счетчик не находится в максимально верхнем положении
                if (buttonPressed.Key == ConsoleKey.DownArrow && visibleChoice != menuItems.Length - 1)
                    visibleChoice++; //увеличение счетчика если нажата клавиша "вниз" и счетчик не находится в максимально нижнем положении

                if (buttonPressed.Key == ConsoleKey.Enter) break;
            }

            return visibleChoice;
        }

        /// <summary>
        /// Реализация главного меню программы
        /// </summary>
        public static void ShomMainMenu()
        {
            while (true)
            {

                //массив пунктов главного меню
                string[] menu = { "Департаменты", "Сотрудники", "Сохранение/загрузка данных", "Выход" };

                int choiceByUser = ChooseMenuItem(menu);

                switch (choiceByUser)
                {

                    case 0:
                        ShowDepartmentMenu();   //переход в меню работы с департаментами
                        break;

                    case 1:
                        ShowEmployeeMenu(); //переход в меню работы с сотрудниками
                        break;

                    case 2:
                        ShowRepositoryMenu();   //переход в меню работы с файлами
                        break;

                    case 3:
                        Environment.Exit(0);
                        break;

                }

            }
        }

        /// <summary>
        /// Реализация для работы с департаментами
        /// </summary>
        static void ShowDepartmentMenu()
        {
            string[] menu = { "Добавить департамент", "Редактировать департамент", "Удалить департамент", "Показать все департаменты", "Назад" };

            int choiceByUser = ChooseMenuItem(menu);

            switch (choiceByUser)
            {
                case 0:
                    UserConsoleInputOutput.CreateNewDepartment();
                    break;
                case 1:
                    UserConsoleInputOutput.EditExistsDepartment(Organization.Departments);                    
                    break;
                case 2:                   
                    string nameOfDeletedDepartment = "";
                    Console.WriteLine("Укажите порядковый номер департамента, который необходимо удалить:");
                    Organization.Departments = ModificationOfOrganizationUnits.DeleteDepartment(Organization.Departments, out nameOfDeletedDepartment);
                    Console.WriteLine($"Департамент {nameOfDeletedDepartment} успешно удален");
                    Console.ReadKey();
                    break;
                case 3:
                    ListToConsole.PrintListDepartments(Organization.Departments);
                    Console.ReadKey();
                    break;
            }




        }

        /// <summary>
        /// Реализация для работы с сотрудниками
        /// </summary>
        static void ShowEmployeeMenu()
        {
            string[] menu = { "Добавить сотрудника", "Редактировать сотрудника", "Удалить сотрудника", "Показать сотрудников", "Назад" };

            int choiceByUser = ChooseMenuItem(menu);

            switch (choiceByUser)
            {
                case 0:
                    UserConsoleInputOutput.CreateNewEmployee();
                    break;
                case 1:
                    UserConsoleInputOutput.EditExistsEmployee(Organization.Departments);
                    break;
                case 2:                    
                    Console.WriteLine("Укажите порядковый номер департамента, в котором находится работает сотрудник:");
                    Department departmentOfDeletedEmployee = Organization.Departments[UserConsoleInputOutput.ChooseNumberOfDepartment(true) - 1];
                    UserConsoleInputOutput.DeleteEmployeeFromDepartment(departmentOfDeletedEmployee);                             
                    break;
                case 3:
                    UserConsoleInputOutput.ChooseListOfEmployeesToPrint();                    
                    Console.ReadKey();
                    break;                    
            }

        }

        /// <summary>
        /// Реализация для работы файлами
        /// </summary>
        static void ShowRepositoryMenu()
        {
            string[] menu = { "Сохранить данные в формате XML", "Загрузить данные из файла XML","Сохранить данные в формате JSON", "Загрузить данные из файла JSON", "Назад" };

            string path;
            int choiceByUser = ChooseMenuItem(menu);

            switch (choiceByUser)
            {
                case 0:
                    path = UserConsoleInputOutput.InputPathToDirectory(Enums.SerializeType.XML, false);
                    XMLSerializer.DataContractSerializeDepartments(Organization.Departments, path);
                    Console.WriteLine($"Данные успешно сохранены в файл {path}");
                    Console.ReadKey();
                    break;
                case 1:
                    path = UserConsoleInputOutput.InputPathToDirectory(Enums.SerializeType.XML, true);
                    XMLSerializer.DataContractDeserializeDepartment(path);
                    Console.WriteLine("Данные успешно загружены");
                    Console.ReadKey();
                    break;
                case 2:
                    path = UserConsoleInputOutput.InputPathToDirectory(Enums.SerializeType.JSON, false);
                    JSONSerializer.JSONSerializeDepartments(path);
                    Console.WriteLine($"Данные успешно сохранены в файл {path}");
                    Console.ReadKey();
                    break;
                case 3:
                    path = UserConsoleInputOutput.InputPathToDirectory(Enums.SerializeType.JSON, true);
                    JSONSerializer.JSONDeserializeDepartments(path);
                    Console.WriteLine("Данные успешно загружены");
                    Console.ReadKey();
                    break;
                case 4: break;
            }
        }
                
    }
}
