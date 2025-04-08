using System.Text;
using AccessControlSystem.Core.Contracts;
using AccessControlSystem.Models;
using AccessControlSystem.Models.Contracts;
using AccessControlSystem.Repositories;
using AccessControlSystem.Utilities.Messages;

namespace AccessControlSystem.Core;

public class Controller : IController
{
    private ICollection<IDepartment> departments;   //  can be a List, an Array, or whatever you choose 
    // need a backing field ?  no

    private SecurityZoneRepository securityZones;
    private EmployeeRepository employees;


    private string[] validDepartmentTypes = new[] { "ITDepartment", "HRDepartment", "FinanceDepartment" };
    private string[] validEmployeeTypes = new[] { "GeneralEmployee", "ITSpecialist" };


    public Controller()
    {
        // init props 
        departments = new List<IDepartment>();
        securityZones = new SecurityZoneRepository();
        employees = new EmployeeRepository();
    }




    public string AddDepartment(string departmentTypeName)
    {
        if (!validDepartmentTypes.Contains(departmentTypeName))
        {
            return string.Format(OutputMessages.InvalidDepartmentType, departmentTypeName);
        }

        IDepartment? existingDepartment = departments
            .FirstOrDefault(d => d.GetType().Name.Equals(departmentTypeName));

        if (existingDepartment != null)
        {
            return string.Format(OutputMessages.DepartmentExists, departmentTypeName);
        }


        IDepartment department;

        if (departmentTypeName == "ITDepartment")
        {
            department = new ITDepartment();
        }
        else if (departmentTypeName == "HRDepartment")
        {
            department = new HRDepartment();
        }
        else  // (departmentTypeName == "FinanceDepartment")
        {
            department = new FinanceDepartment();
        }


        departments.Add(department);

        return string.Format(OutputMessages.DepartmentAdded, departmentTypeName);

    }




    public string AddEmployeeToApplication(string employeeName, string employeeTypeName, int securityId)
    {
        // ?? Each employee must have a unique security ID (handled by the Employee class constructor)

        if (!validEmployeeTypes.Contains(employeeTypeName))
        {
            return string.Format(OutputMessages.InvalidEmployeeType, employeeTypeName);
        }


        IEmployee? existingEmployeeByName = employees.GetByName(employeeName);

        if (existingEmployeeByName != null)
        {
            return string.Format(OutputMessages.EmployeeExistsInApplication, employeeName);
        }


        IEmployee? existingEmployeeById = employees
            .Models.FirstOrDefault(e => e.SecurityId.Equals(securityId));

        if (existingEmployeeById != null)
        {
            return string.Format(OutputMessages.SecurityIdExists, securityId);
        }



        IEmployee employee;

        if (employeeTypeName == "GeneralEmployee")
        {
            employee = new GeneralEmployee(employeeName, securityId);
        }
        else  // (employeeTypeName == "ITSpecialist")
        {
            employee = new ITSpecialist(employeeName, securityId);
        }


        employees.AddNew(employee);

        return string.Format(OutputMessages.EmployeeAddedToApplication, employeeName);

    }




    public string AddEmployeeToDepartment(string employeeName, string departmentTypeName)
    {
        IEmployee? existingEmployee = employees.GetByName(employeeName);

        if (existingEmployee == null)
        {
            return string.Format(OutputMessages.EmployeeNotInApplication, employeeName);
        }

        if (!validDepartmentTypes.Contains(departmentTypeName))
        {
            return string.Format(OutputMessages.InvalidDepartmentType, departmentTypeName);
        }



        string departmentType = departmentTypeName;

        string employeeType = existingEmployee.GetType().Name;   // will need to cast before that ??

        bool allowed = 
            (employeeType == "ITSpecialist" &&
             departmentType == "ITDepartment")
            ||
            (employeeType == "GeneralEmployee" &&
             (departmentType == "HRDepartment" || departmentType == "FinanceDepartment"))
        ;

        if (!allowed)
        {
            return string.Format(OutputMessages.ContractNotAllowed, employeeType, departmentTypeName);
        }



        IDepartment? existingDepartment = departments
            .FirstOrDefault(d => d.GetType().Name.Equals(departmentTypeName));

        if (existingDepartment == null)
        {
            return string.Format(OutputMessages.DepartmentIsNotAvailable, departmentTypeName);
        }



        //existingEmployee
        //existingDepartment

        bool alreadyAssigned = existingEmployee.Department != null;  // ok?
        // or
        //this.departments
        //.Where(d => d.Employees.Contains(employeeName));

        if (alreadyAssigned)
        {
            return string.Format(OutputMessages.EmployeeExistsInDepartment, employeeName);
        }

        bool hasCapacity = existingDepartment.Employees.Count < existingDepartment.MaxEmployeesCount;
        // ok?

        if (!hasCapacity)
        {
            return string.Format(OutputMessages.DepartmentFull, departmentTypeName);
        }



        existingDepartment.ContractEmployee(employeeName);

        existingEmployee.AssignToDepartment(existingDepartment);

        return string.Format(OutputMessages.EmployeeAddedToDepartment, employeeType, departmentTypeName);

    }




    public string AddSecurityZone(string securityZoneName, int accessLevelRequired)
    {
        ISecurityZone? existingSecurityZone = securityZones.GetByName(securityZoneName);

        if (existingSecurityZone != null)
        {
            return string.Format(OutputMessages.SecurityZoneExists, securityZoneName);
        }

        ISecurityZone securityZone = new SecurityZone(securityZoneName, accessLevelRequired);

        securityZones.AddNew(securityZone);

        return string.Format(OutputMessages.SecurityZoneAdded, securityZoneName);

    }




    public string AuthorizeAccess(string securityZoneName, string employeeName)
    {
        ISecurityZone? existingSecurityZone = securityZones.GetByName(securityZoneName);

        if (existingSecurityZone == null)
        {
            return string.Format(OutputMessages.SecurityZoneNotFound, securityZoneName);
        }


        IEmployee? existingEmployee = employees.GetByName(employeeName);

        if (existingEmployee == null)
        {
            return string.Format(OutputMessages.EmployeeNotInApplication, employeeName);
        }


        bool notAssigned = existingEmployee.Department == null;  // ok? correct?
        // or
        //this.departments
        //.Where(d => d.Employees.Contains(employeeName));

        if (notAssigned)
        {
            return string.Format(OutputMessages.AccessDenied, employeeName, securityZoneName);
        }

        // ok?
        bool securityLevelLower = existingEmployee.Department.SecurityLevel < existingSecurityZone.AccessLevelRequired;

        if (securityLevelLower)
        {
            return string.Format(OutputMessages.AccessDenied, employeeName, securityZoneName);
        }


        bool alreadyPresent = existingSecurityZone.AccessLog.Contains(existingEmployee.SecurityId);

        if (alreadyPresent)
        {
            return string.Format(OutputMessages.EmployeeAlreadyAuthorized, employeeName, securityZoneName);
        }



        existingSecurityZone.LogAccessKey(existingEmployee.SecurityId);

        return string.Format(OutputMessages.EmployeeAuthorized, employeeName, securityZoneName);
    }




    public string SecurityReport()
    {
        StringBuilder sb = new StringBuilder();

        sb.Append("Security Report:");
        sb.AppendLine();

        foreach (var zone in securityZones.Models
                     .OrderByDescending(z => z.AccessLevelRequired)
                     .ThenBy(z => z.Name)
                )
        {
            sb.Append($"-{zone.Name} (Access level required: {zone.AccessLevelRequired})");
            sb.AppendLine();

            foreach (IEmployee employee in employees.Models
                         .Where(e => zone.AccessLog.Contains(e.SecurityId)))
            // no sort?
            {

                // correct dashes?
                sb.Append("--");
                sb.Append(employee.ToString());
                sb.AppendLine();
            }
        }

        return sb.ToString().Trim();
    }
}