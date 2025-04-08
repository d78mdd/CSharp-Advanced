using AccessControlSystem.Models.Contracts;
using AccessControlSystem.Utilities.Messages;

namespace AccessControlSystem.Models;

public abstract class Department : IDepartment
{
    public abstract int SecurityLevel { get; protected set; } // set in child classes   /// abstract?

    private List<string> _employees;
    public IReadOnlyCollection<string> Employees { get; }

    public abstract int MaxEmployeesCount { get; protected set; } // set in child classes   /// abstract?



    protected Department()
    {
        _employees = new List<string>();
        Employees = _employees.AsReadOnly();
    }



    public void ContractEmployee(string employeeName)
    {
        if (_employees.Count == MaxEmployeesCount)
        {
            throw new ArgumentException(ExceptionMessages.InvalidDepartmentCapacity);
        }

        if (_employees.Contains(employeeName))
        {
            throw new ArgumentException(ExceptionMessages.EmployeeAlreadyAdded);
        }

        _employees.Add(employeeName);
    }
}