using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace HomeWork_08_SKP
{
    /// <summary>
    /// Класс содержит методы для сериализации/десирализации структуры предприятия в json-формат
    /// </summary>
    static class JSONSerializer
    {
        /// <summary>
        /// Метод сериализации списка департаментов в JSON-файл
        /// </summary>
        /// <param name="path">Путь к файлу в который будет произведено сохранение</param>
        public static void JSONSerializeDepartments(string path)
        {
            string json = JsonConvert.SerializeObject(Organization.Departments);

            File.WriteAllText(path, json);
        }

        /// <summary>
        /// Метод десериализации списка департаментов из JSON-файла
        /// </summary>
        /// <param name="path">Путь к файлу с сериализованными файлами</param>
        public static void JSONDeserializeDepartments(string path)
        {
            string json = File.ReadAllText(path);

            Organization.Departments = JsonConvert.DeserializeObject<List<Department>>(json);
        }

    }
}
