using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Xml;


namespace HomeWork_08_SKP
{

    /// <summary>
    /// Класс содержит методы для сериализации/десирализации структуры предприятия в xml-формат
    /// </summary>
    static class XMLSerializer
    {               
        
        /// <summary>
        /// Метод сериализации списка департаментов в XML-файл через DataContractSerializer
        /// </summary>
        /// <param name="ConcreteDepartmentList">Список департаментов</param>
        /// <param name="path">Путь к файлу в который будет произведено сохранение</param>
        public static void DataContractSerializeDepartments(List<Department> ConcreteDepartmentList, string path)
        {
            DataContractSerializer xmlDataSerializerOfDepartments = new DataContractSerializer(typeof(List<Department>));

            Stream saveToFile = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write);

            xmlDataSerializerOfDepartments.WriteObject(saveToFile, ConcreteDepartmentList);

            saveToFile.Close();
        }

        /// <summary>
        /// Метод десериализации списка департаментов из XML-файла в программу через DataContractSerializer
        /// </summary>
        /// <param name="path">Путь к файлу с данными сохраненными в xml формате</param>
        public static void DataContractDeserializeDepartment(string path)
        {
            List<Department> newDepartments = new List<Department>();

            DataContractSerializer xmlDeserializerOfDepartments = new DataContractSerializer(typeof(List<Department>));

            Stream loadFromFile = new FileStream(path, FileMode.Open, FileAccess.Read);

            XmlDictionaryReader readFile = XmlDictionaryReader.CreateTextReader(loadFromFile, new XmlDictionaryReaderQuotas());

            newDepartments = xmlDeserializerOfDepartments.ReadObject(readFile, true) as List<Department>;

            loadFromFile.Close();

            Organization.Departments.AddRange(newDepartments);
        }
        
    }
}
