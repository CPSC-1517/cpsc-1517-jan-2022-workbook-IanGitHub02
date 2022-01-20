using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeConsole.Data
{
    // struct is another developer defined data type look like a class definition
    // struct however is a value storage where as class is a reference type storage
    // struct can have fields, properties, constructors, and behaviours
    // struct came first before class
    public struct ResidentAddress
    {
        public int Number;
        public string Address1;
        public string Address2;
        private string _Unit;
        private string _City;
        public string ProvinceState;

        public string Unit
        {
            get { return _Unit; }
            set { _Unit = value; }
        }

        public string City
        {
            get { return _City; }
            set { _City = value; }
        }

        public ResidentAddress(int Number, string Address1, string Address2, string Unit, string City, string ProvinceState)
        {
            // Concern: parameter name is exactly the same as the struct/class field/property
            //
            // Solution: use the keyword this. on your instance item
            //
            // The keyword this reference to the instance that you are currently accessing in your program
            
            this.Number = Number;
            this.Address1 = Address1;
            this.Address2 = Address2;
            _Unit = Unit;
            _City = City;
            this.ProvinceState = ProvinceState;
        }

        // Note that no "default" constructor was created because I wish the program to assign the address will all necessary
        // data at creation time
    }
}
