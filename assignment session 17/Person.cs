using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment_session_17
{
    internal struct  Person
    {
        #region Atrributes
        public int Age;
        public string Name;
        #endregion
        #region Constructors
        public Person(string name, int age)
        {
            Name=name;
            Age=age;
        
   
        }


        #endregion

        #region Methods
   
        public override string ToString()
        {
            return $"Name:{Name}\nAge:{Age} ";
        }





        #endregion






    }
}
