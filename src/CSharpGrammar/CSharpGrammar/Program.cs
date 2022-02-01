using PracticeConsole;
using PracticeConsole.Data; // Gives reference access to the location of classes within the specified namespace
                            // This allows the developer to avoid having to use a fully qualified name every time a
                            // reference is made to a class in the namespace 
using System; // In .net 6 some using statement visible in .net 5 are already implemented in the project and do not
              // need to be explicitly coded.
              // There will be times that you will still need to code using statements to explcitly reference other namespaces

// See https://aka.ms/new-console-template for more information
DisplayString("Hello World!");

//// Fully qualified name
//// PracticeConsole.Data.Employment job = CreateJob();
//Employment Job = CreateJob();
//ResidentAddress Address = CreateAddress();

//// Create a Person
//Person Me = CreatePerson(Job, Address);
//if (Me != null)
//    DisplayPerson(Me);

//ArrayReview(Me);

string pathname = CreateCSVFile();
ReadCSVFile(pathname);

static void DisplayString(string text)
{
    Console.WriteLine(text);
}

static void DisplayPerson(Person person)
{
    DisplayString($"{person.FirstName} {person.LastName}");
    DisplayString($"{person.Address.ToString()}");       

    if (person.EmploymentPositions != null)
    {
        // This loop is a forward moving pre-test loop
        // What is checks is "is there another link element to look at"
        // Yes: use the element
        // No: exit loop
        foreach (var emp in person.EmploymentPositions)
        {
            DisplayString(emp.ToString());
        }

        int empPositionCount = person.EmploymentPositions.Count();

        // A List<T> can actually be manipulated like an array
        // It is a pre-test loop
        for (int i = 0; i < empPositionCount; i++)
        {
            DisplayString(person.EmploymentPositions[i].ToString());
        }

        if (empPositionCount > 0)
        {
            int x = 0;

            // It is a post-test loop
            do
            {
                DisplayString(person.EmploymentPositions[x].ToString());
                x++;
            }
            while (x < empPositionCount);
        }
    }
}

Employment CreateJob()
{
    Employment job = null; // a reference to a variable capable of holding an instance of Employment its initial value will be null

    try
    {
        job = new Employment();
        DisplayString($"Default good job {job.ToString()}");
                
        job = new Employment("Boss", SupervisoryLevel.Supervisor, 5.5);
        DisplayString($"Greedy good job {job.ToString()}");

        // Checking exeptions
        //// Bad data: title
        //job = new Employment("", SupervisoryLevel.Supervisor, 5.5);
        //// Bad data: year
        //job = new Employment("Boss", SupervisoryLevel.Supervisor, -5.5);
    }
    catch (ArgumentException ex) // specific exception message
    {
        DisplayString(ex.Message);
    }
    catch (Exception ex) // general catch all
    {
        DisplayString("Run time error: " + ex.Message);
    }

    return job;
}

ResidentAddress CreateAddress()
{
    ResidentAddress address = new ResidentAddress();
    DisplayString($"Default address {address.ToString()}");
    address = new ResidentAddress(10767, "106 ST NW", null, null, "Edmonton", "AB");
    DisplayString($"Greedy address {address.ToString()}");

    return address;
}

Person CreatePerson(Employment job, ResidentAddress address)
{
    List<Employment> Jobs = new List<Employment>();
    Person thePerson = null;
    
    try
    {
        //// Create a good person using greedy constructor no job list
        //thePerson = new Person("BryanNoJob", "Mendoza", null, address);

        //// Create a good person using greedy constructor with an empty job list
        //thePerson = new Person("BryanEmptyJob", "Mendoza", Jobs, address);

        // Create a good person using greedy constructor with a job list
        Jobs.Add(new Employment("worker", SupervisoryLevel.TeamMember, 2.1));
        Jobs.Add(new Employment("leader", SupervisoryLevel.TeamLeader, 7.8));
        Jobs.Add(job);
        thePerson = new Person("BryanWithJobs", "Mendoza", Jobs, address);

        //// Exception testing
        //// No first name
        //thePerson = new Person(null, "Mendoza", Jobs, address);
        //// No last name
        //thePerson = new Person("Bryan", null, Jobs, address);

        //// Can I change the firstname using an assignment statement the FirstName is a private set
        //// You are NOT allowed to use a private ser on the receiving side of an assignment statement
        //// THIS WILL NOT COMPILE
        //thePerson.FirstName = "NewName";

        // Can I use a behaviour (method) to change the contents of a private set property?
        thePerson.ChangeName("Lowand", "Behold");

        // Can I add another job after the person instance was created
        thePerson.AddEmployment(new("DP IT", SupervisoryLevel.DepartmentHead, 0.8));
        //thePerson.AddEmployment(new Employment("DP IT", SupervisoryLevel.DepartmentHead, 0.8));

        // Can I change the public field address directly
        ResidentAddress oldAddress = thePerson.Address;
        oldAddress.City = "Vancouver";
        thePerson.Address = oldAddress;
    }
    catch (ArgumentException ex) //specific exception message
    {
        DisplayString(ex.Message);
    }
    catch (Exception ex) // general catch all
    {
        DisplayString("Run time error: " + ex.Message);
    }

    return thePerson;
}

void ArrayReview(Person person)
{
    // Declare a single-dimensional array size 5
    // In this declaration the value in each element is set to the datatype's deafult (numeric -> 0)
    int [] array1 = new int [5]; //one can use a literal fro the size
    PrintArray(array1, 5, "Declare int array size 5");
    
    // Declare and set array elements
    int[] array2 = new int[] { 1, 2, 4, 8, 16 };
    PrintArray(array2, 5, "Declare int array size using a list of supplied values");

    // Alternate syntax
    // Size of the array can be determined using the method .Count() of the array collection using the inherited class
    // IEnumerable (Array class derived from the base class IEnumerable which is derived from its base class Collections)
    // Size of the array can be determined using the read-only property (just has a get{})

    int[] array3 = { 1, 3, 6, 12, 24 };
    PrintArray(array3, array3.Count(), "Declare int array size using a list of supplied values");

    // Traversing to an array altering elements remember that the array when declared is physically created in memory
    // each element (cell) has a given value, even if it is the datatype's default when you are "adding" to an array you
    // are really just altering the elemnet value

    // Logical counter for your array to indicate the "valid meaningful" value for processing
    int lsArray1 = 0;
    int larray2 = array2.Count(); //IEnumerable method
    int larray3 = 0; //Array read-only property

    Random random = new Random();
    int randomValue = 0;
    while (lsArray1 < array1.Length)
    {
        randomValue = random.Next(0, 100);
        array1[lsArray1] = randomValue;
        lsArray1++;
    }
    PrintArray(array2, 5, "Array loaded with random values");

    // Alteran element randomly selected to a new value
    int anyPosition = random.Next(0, array1.Length);
    randomValue = random.Next(0, 100);
    array1[anyPosition] = randomValue;
    PrintArray(array1, lsArray1, "Randomly replace an array value");

    // Remove an element value from an array
    // Move all array elements in positions greater than the element that the removed element position, "up one"
    // Assume we are removing element 3 (index 2)
    int logicalElementNumber = 3; //index of value is logical position - 1
    for (int i = --logicalElementNumber; i < array1.Length; i++)
    {
        array1[i] = array1[i + 1];
    }
    lsArray1--;
    array1[array1.Length - 1] = 0;
    PrintArray(array1, array1.Length, "Remove an array value");
}

void PrintArray(int [] array, int size, string text)
{
    Console.WriteLine($"\ntext\n");

    // Items represents an element in array
    // Array is your collection (array [])
    // Processing will be start (0) to end (size-1)
    foreach (var item in array)
    {
        Console.WriteLine($"{item},");
    }
    Console.WriteLine();

    // Using the for loop this display output the array back to front
    for (int i = size - 1; i >= 0; i--)
    {
        Console.WriteLine($"{array[i]},");
    }
    Console.WriteLine();
}

string CreateCSVFile()
{
    string pathname = "../../../Employment.dat";
    try
    {
        List<Employment> Jobs = new List<Employment>();
        Jobs.Add(new Employment("trainee", SupervisoryLevel.Entry, 0.5));
        Jobs.Add(new Employment("worker", SupervisoryLevel.TeamMember, 3.5));
        Jobs.Add(new Employment("worker", SupervisoryLevel.TeamMember, 2.1));
        Jobs.Add(new Employment("leader", SupervisoryLevel.TeamLeader, 7.8));
        Jobs.Add(new Employment("worker", SupervisoryLevel.Supervisor, 6.0));
        Jobs.Add(new Employment("worker", SupervisoryLevel.DepartmentHead, 2.1));

        // Create a list of comma-separate value strings the contents of each strng will be 3 values of Employment
        // in .Net Core when declaring an instance of a class, it is now not necessary to specify the class name after the new. 
        List<string> csvLines = new();

        // Place all the instances of Employment into the List<String>
        foreach (var item in Jobs)
        {
            // Item represents an instance of Employment in the collection Jobs .ToString() is the override method
            // in Employment that returns call Employment instance value as comma-separate values
            csvLines.Add(item.ToString());
        }

        // Write to a csv file requires the System.IO namespaces
        // Writing a file will default the output to the folder that contains the executing .exe file
        // There are several ways to output this file such as using StreamWriter and using the File class
        // Within the File class there is a method that outputs a list of strings all within one command.
        // There is NO NEED for a StreamWriter instance.
        // The pathname of the method at minimum MUST be the filename.
        // The pathname can redirect the default location by using relative addressing with the filename.

        File.WriteAllLines(pathname, csvLines);
        Console.WriteLine($"\nCheck out the CSV file at: {Path.GetFullPath(pathname)}");
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }

    return Path.GetFullPath(pathname);
}

void ReadCSVFile(string pathName)
{
    // Reading a CSV file is similar to writing. One can read ALL lines at one time. There is no need for a StreamReader.
    // One concern would be the size of the expected input file.
    try
    {
        string[] csvFileInput = File.ReadAllLines(pathName);
        Console.WriteLine("\n\nContents of CSV Employment file:\n");
        foreach (var item in csvFileInput)
        {
            Console.WriteLine(item);
        }
    }
    catch (IOException ex)
    {
        Console.WriteLine($"Reading CSV file error: {ex.Message}");
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}