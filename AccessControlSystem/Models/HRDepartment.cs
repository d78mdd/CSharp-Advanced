namespace AccessControlSystem.Models;

public class HRDepartment : Department
{
    public override int SecurityLevel { get; protected set; } // ok?

    public override int MaxEmployeesCount { get; protected set; }  // ok ?



    // ok ?
    public HRDepartment()  // : base() ?
    {
        SecurityLevel = 3;
        MaxEmployeesCount = 5;
    }
}