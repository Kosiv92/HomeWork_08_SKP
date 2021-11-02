using System;
using System.Runtime.Serialization;

namespace HomeWork_08_SKP
{
    /// <summary>
    /// Абстрактный класс организационной единицы организации (тестирование наследования)
    /// </summary>
    [DataContract(Name = "AbstractObject", IsReference = true)]
    public abstract class OrganizationUnit
    {
        [DataMember(Name = "ID")]
        readonly Guid _idNumber = Guid.NewGuid();  
        
        public Guid IDNumber
            {
                get{return _idNumber;} 
            }

        [DataMember(Name = "Name")]
        public string Name { get; set; }                

    }
}
