using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_08_SKP
{
    interface IOrganizationObjectStructure
    {
        /// <summary>
        /// Имя объекта
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Добавление объекта
        /// </summary>
        void Add();

        /// <summary>
        /// Удаление объекта
        /// </summary>
        void Remove();

        /// <summary>
        /// Редактирование объекта
        /// </summary>
        void Edit();

    }
}
