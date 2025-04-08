namespace AccessControlSystem.Core.Contracts
{
    public interface IController
    {
        string AddDepartment(string departmentTypeName);

        string AddEmployeeToApplication(string employeeName, string employeeTypeName, int securityId);

        string AddEmployeeToDepartment(string employeeName, string departmentTypeName);

        string AddSecurityZone(string securityZoneName, int accessLevelRequired);

        string AuthorizeAccess(string securityZoneName, string employeeName);

        string SecurityReport();
    }
}
