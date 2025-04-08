namespace AccessControlSystem.Models;

public class ITSpecialist : Employee
{
    private string[] validDepartments = new[] { "ITDepartment" };


    public ITSpecialist(string name, int securityId) : base(name, securityId)
    {
    }
}