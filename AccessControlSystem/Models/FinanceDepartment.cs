namespace AccessControlSystem.Models;

public class FinanceDepartment : Department
{
    public override int SecurityLevel { get; protected set; } // ok?

    public override int MaxEmployeesCount { get; protected set; }  // ok ?



    // ok ?
    public FinanceDepartment()  // : base() ?
    {
        SecurityLevel = 4;
        MaxEmployeesCount = 3;
    }
}