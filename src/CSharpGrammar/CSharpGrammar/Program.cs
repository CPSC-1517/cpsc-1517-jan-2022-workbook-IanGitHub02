using PracticeConsole.Data; // Gives reference access to the location of classes within the specified namespace
                            // This allows the developer to avoid having to use a fully qualified name every time a
                            // reference is made to a class in the namespace 
using System; // In .net 6 some using statement visible in .net 5 are already implemented in the project and do not
              // need to be explicitly coded.
              // There will be times that you will still need to code using statements to explcitly reference other namespaces

// See https://aka.ms/new-console-template for more information
DisplayString("Hello World!");

// Fully qualified name
// PracticeConsole.Data.Employment job = CreateJob();
Employment Job = CreateJob();
ResidentAddress Address = CreateAddress();


static void DisplayString(string text)
{
    Console.WriteLine(text);
}

Employment CreateJob()
{
    Employment job = null; // a reference to a variable capable of holding an instance of Employment its initial value will be null

    try
    {
        job = new Employment();
        DisplayString($"Good job {job.ToString()}");
        // Checking exeptions
        job = new Employment("Boss", SupervisoryLevel.Supervisor, 5.5);
        DisplayString($"Greedy good job {job.ToString()}");
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