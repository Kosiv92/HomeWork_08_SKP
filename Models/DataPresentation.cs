using HomeWork_08_SKP.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_08_SKP
{
    class DataPresentation
    {
        /// <summary>
        /// Параметры сортировки сотрудников
        /// </summary>
        class EmployeeCollectionSort
        {
            /// <summary>
            /// Поле объекта Employee (Сотрудник) по которому будет происходить сортировка
            /// </summary>
            EmployeeFields Field { get; set; }                        

            /// <summary>
            /// Тип сортировки (возрастание/убывание)
            /// </summary>
            SortType TypeOfSort { get; set; }

        }

        /// <summary>
        /// Параметры сортировки департаментов
        /// </summary>
        class DepartmentCollectionsSort
        {
            /// <summary>
            /// Поле объекта Department (департамент) по которому будет происходить сортировка
            /// </summary>
            DepartmentFields Field { get; set; }

            /// <summary>
            /// Тип сортировки (возрастание/убывание)
            /// </summary>
            SortType TypeOfSort { get; set; }
        }

    }
}
