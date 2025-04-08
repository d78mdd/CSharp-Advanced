using AccessControlSystem.Models.Contracts;
using AccessControlSystem.Utilities.Messages;

namespace AccessControlSystem.Models;

public abstract class Employee : IEmployee
{
    public string Name { get; }

    public IDepartment Department { get; private set; } // need protected setter?

    public int SecurityId { get; }


    protected Employee(string name, int securityId)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException(ExceptionMessages.InvalidEmployeeName);
        }
        Name = name;

        if (securityId < 100 || securityId > 999)
        {
            throw new ArgumentException(ExceptionMessages.InvalidSecurityId);
        }

        SecurityId = securityId;
    }



    public void AssignToDepartment(IDepartment department)
    {
        this.Department = department;  // correct ?
    }

    public override string ToString()
    {
        return $"Employee: {Name}, Department: {Department.GetType().Name}, Security ID: {SecurityId}";
    }
}