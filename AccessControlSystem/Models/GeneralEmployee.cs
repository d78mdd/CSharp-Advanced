namespace AccessControlSystem.Models;

public class GeneralEmployee : Employee
{
    private string[] validDepartments = new[] { "HRDepartment", "FinanceDepartment" };

    public GeneralEmployee(string name, int securityId) : base(name, securityId)
    {
    }
}