using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using HomeWork_08_SKP.Services;

namespace HomeWork_08_SKP
{
    
    static class Organization
    {
        /// <summary>
        /// Название организации
        /// </summary>
        static public string Name = "MyOrganization";
        
        /// <summary>
        /// Поле хранящее коллекцию депаратментов организации
        /// </summary>
        static private List<Department> _departments = new List<Department>();               
        
        /// <summary>
        /// Свойство доступа к коллекции департаментов
        /// </summary>
        static public List<Department> Departments { get { return _departments; } set { _departments = value; } }
                 
    }        
}
