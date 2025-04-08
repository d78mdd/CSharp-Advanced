namespace AccessControlSystem.Models;

public class ITDepartment : Department
{
    public override int SecurityLevel { get; protected set; } // ok?

    public override int MaxEmployeesCount { get; protected set; }  // ok ?



    // ok ?
    public ITDepartment()  // : base() ?
    {
        SecurityLevel = 5;
        MaxEmployeesCount = 8;
    }
}