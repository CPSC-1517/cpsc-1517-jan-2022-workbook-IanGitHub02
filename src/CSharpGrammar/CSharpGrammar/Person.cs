using PracticeConsole.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeConsole
{
    public class Person
    {
        // Example of a composite class
        // A composite class uses other classes in its definition
        // A composite class is recognized with the phrase "has a" class
        // This class of Person "has a" resident address

        // An inherited class extends another class in its definition
        // An inherited class is recognized with the phrase "is a" class
        // Assume a general class called Transportation
        // Then we can "extend" this class to more specific classes
        //  public class Vehicle : Transportation
        //  public class Bike : Transportation
        //  public class Boat : Transportation

        // Each instance of this class will represent an individual
        // This class will define the following characteristics of a person
        // First Name, Last Name, the current resident address, list of employment position

        private string _FirstName;
        private string _LastName;

        public string FirstName
        {
            get { return _FirstName; }
            set
            {
                if (Utilities.IsEmpty(value))
                {
                    throw new ArgumentNullException("First Name is required.");
                }

                _FirstName = value;
            }
        }

        public string LastName
        {
            get { return _LastName; }
            set
            {
                if (Utilities.IsEmpty(value))
                {
                    throw new ArgumentNullException("Last Name is required.");
                }

                _LastName = value;
            }
        }

        // Composite actually uses the other class as a property/field within the definition of the class being defined
        public ResidentAddress Address;

        // Composition
        public List<Employment> EmploymentPositions { get; set; }

        //public Person()
        //{
        //    // If an instance of List<T> is not created and assigned then the property will have an initial value of null
        //    EmploymentPositions = new List<Employment>();

        //    // Option 1: Assign default value to the strings
        //    // Since FirstName and LastName need to have values you can assign default literal to the properties
        //    FirstName = "unknown";
        //    LastName = "unknown";
        //}

        // Option 2:
        // DO NOT code a "Default" constructor
        // Code ONLY the "Greedy" constructor
        // If only a greedy constructor exists for the class, the ONLY way to possibly create an instance for the class within
        // the program is to use the constructor when the class instance is created

        public Person(string firstName, string lastName, List<Employment> employmentPositions, ResidentAddress address)
        {
            FirstName = firstName;
            LastName = lastName;

            if (employmentPositions != null)
            {
                EmploymentPositions = employmentPositions;
            }
            else
            {
                // Allows an null value and the class to habe an empty List<T>
                EmploymentPositions = new List<Employment>();
            }

            Address = address;
        }
    }
}
