using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_08_SKP
{
    static class Organization
    {
        static private List<Department> _departments = new List<Department>();               

        static public List<Department> Departments { get { return _departments; } set { _departments = value; } }                

    }
}
