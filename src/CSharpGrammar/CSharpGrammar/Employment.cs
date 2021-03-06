using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeConsole.Data
{

    public class Employment
    {
        // An instance of this class will hold data about a person's employment
        // The code of this class is the definition of that data
        // The characteristics (data) of the class
        // Title, SupervisoryLevel, Years of Employement within the company

        // The 4 components of a class definition are
        // - data fields
        // - property
        // - constructor
        // - behaviour (method)

        // Data fields
        // - are storage area in your class
        // - these are treated as variables
        // - these may be public, private, public readonly
        private string _Title;
        private double _Years;

        // Properties
        // These are access techniques to retrieve or set data in your class without directly touching the storage data field

        // Fully implemented property
        // a) a declared stroage area (data field)
        // b) a declared property signature
        // c) a coded get "method"
        // d) an optional coded set "method"

        // When:
        // a) if you are storing the associate data in an explicitly declared data field
        // b) if you are during validation access incoming data
        // c) creating a property that generates output from other data sources
        //    within the class (readonly properties); this property would have only a get method
        public string Title
        {
            get
            {
                // Accessor
                // - the get "method" will return the contents of a data field(s) as an expression
                return _Title;
            }
            set
            {
                // Mutator
                // - the set "method" receives an incoming value and places it in the associated data field
                //   during the setting, you might wish to validate the incoming data
                //   during the setting, you might wish to do some type of logical processing using the data to set another field
                // - the incoming piece of data is referred to using the keyword "value"

                // Ensure that the incoming data is not null or empty or just whitespace
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Title is a required piece of data.");
                }

                // Data is considered valid
                _Title = value;
            }
        }

        // Auto-implemented property

        // these properties differ only in syntax
        // each property is responsible for a single piece of data
        // this properties do NOT reference a declared private data member
        // the system generates an internal storage area of the return data type
        // the system manages the internal storage for the accessor and mutator
        // this is NO additional logic applied to the data value

        // Using an enum for this field will AUTOMATICALLY restrict the values this property can contain
        public SupervisoryLevel Level { get; set; }

        // This property Years could be coded as either a fully implemented property or as an auto-implmented property
        public double Years
        {
            get { return _Years; }
            set
            {
                if (!Utilities.IsPositive(value))
                {
                    throw new ArgumentNullException("Year cannot be a negative value.");
                }
                _Years = value;
            }
        }

        // Constructors
        // is to initialize the physical object (instance) during its creation
        // the result of creation is ensure that the coder gets an instance in a known state
        //
        // if your class definition has NO constructor coded, then the data members /
        // auto implemented properties are set to the C# default data type value
        //
        // You can code one or more constructors in your class definition
        // IF YOU CODE A CONSTRUCTOR FOR THE CLASS, YOU ARE RESPONSIBLE FOR ALL
        // CONSTRUCTORS USED BY THE CLASS!!!
        //
        // Generally, if you are going to code your own constructor(s) you code two types
        // Default: this constructor does NOT take in any parameters (it mimics the default system constructor)
        // Greedy:  this constructor has list of parameters, on for each property, declare
        //          for incoming data
        //
        // Syntax: accesstype classname([list of parameters]) {constructor code body}
        //
        // IMPORTANT: The constructor DOES NOT have a return datatype
        //            You DO NOT call a constructor directly, called using the new operator
        //
        // Default constructor
        public Employment()
        {
            // Constructor body
            // a) empty
            // b) you COULD assign literal values to your properties with this constructor
            Level = SupervisoryLevel.TeamMember;
            Title = "Unknown";
        }

        // Greedy constructor
        public Employment(string title, SupervisoryLevel level, double years)
        {
            // Constructor body
            // a) a parameter for each property
            // b) you COULD do validation within the constructor instead of the property
            // c) validation for public readonly data members
            //    validation for a property with a private set

            Title = title;
            Level = level;
            Years = years;
        }

        // Behaviours (aka methods)
        // Behaviours are no different than methods elsewhere

        //Syntax accesstype [static] returndatatype BehaviourName([list of parameters]) { code body }

        // There maybe times you wish to obtain all the data in your instance all at once for display
        // Generally to accomplish this, your class overrides the .ToString() method of classes

        public override string ToString()
        {
            // comma separate value string (csv)
            // The string is being created using String interpolation
            // $"string characters {fieldName} ....."
            return $"{Title},{Level},{Years}";

            //// Straight concatenation of strings
            //return Title + "," + Level + "," + Years.ToString();
        }

        public void SetEmployeeResponsibilityLevel(SupervisoryLevel level)
        {
            // You could do validation within this method to ensure acceptable value
            if (level < 0)
                throw new Exception("Responsibility Level must be positive");
            Level = level;
        }

        // The following method will receive a CSV string of values that represents an instance of Employment that method will
        // validate that there are sufficient values for an instance will use primitive datatype .Person() to convert an individual
        // values. Will return a load instance of the Employment class
        // Will use the FormatException() if insufficient data is supplied

        // As the instance is loaded on the return, the Employment constructor will be used thus any error generated by the
        // cnstructor shall still be created

        // This method will NOT retain any data
        // This method will be a shared method (static)
        public static Employment Parse(string text)
        {
            // text is a string of CSV values
            // value1,value2,value3,.....
            // Step 1: Separate the string of values into individual values
            //         The result will be an array of strings
            //         Each array element represents a value
            //         The string class method .Split(delimiter) is use for this function
            //         A delimeter can be any C# recognized character
            //         In a CSV string, the delimeter character is a comma
            string[] parts = text.Split(',');

            // Step 2: Verify that sufficient values exist to create the Employment instance
            if (parts.Length != 3)
            {
                throw new FormatException($"String is not expected format, Missing value. {text}");
            }

            // Step 3: Return a new instance of the Employment class
            //         Create a new instance of the return statement
            //         As the instance is being created, the Employment constructor will be used
            //         ANY validation occuring during the constructor execution will still be doen, whether the logic is in the
            //         constructor OR in the individual property
            //         Use the primitive .Parse() methods already in their class

            return new Employment(parts[0],
                                  (SupervisoryLevel)Enum.Parse(typeof(SupervisoryLevel), parts[1]),
                                  double.Parse(parts[2]));
        }

        // The TryParse() method will receive a string and output an instance of Employment via an output parameter.
        // The method will return a boolean value indicating if the action with the method was successful
        // The action within the method will be to call .Parse() mehtod
        // This is the same concept of Parsing primitive datatypes already in C#
        // bool int.TryParse(text, output variable) --> int int.Parse(string)
        public static bool TryParse(string text, out Employment result)
        {
            // Create an initialized output return value
            result = null;
            bool valid = false;
            try
            {
                // The logic of the try is to do the Parse
                result = Parse(text);
                valid = true;
            }
            catch (FormatException ex)
            {
                throw new FormatException(ex.Message);
            }
            catch (ArgumentException ex)
            {
                throw new ArgumentException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception($"Tryparse Employment: {ex.Message}");
            }

            return valid;
        }
    }
}