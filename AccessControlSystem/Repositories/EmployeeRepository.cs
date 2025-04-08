using AccessControlSystem.Models.Contracts;
using AccessControlSystem.Repositories.Contracts;
using System.Xml.Linq;

namespace AccessControlSystem.Repositories;

public class EmployeeRepository : IRepository<IEmployee>
{
    private List<IEmployee> _models;
    public IReadOnlyCollection<IEmployee> Models => _models.AsReadOnly();

    public EmployeeRepository() // constructor wanted?
    {
        _models = new List<IEmployee>();
    }

    public void AddNew(IEmployee model)
    {
        _models.Add(model);
    }

    public IEmployee? GetByName(string modelName)  // string employeeName   // '?' should be ok
    {
        return _models.FirstOrDefault(e => e.Name == modelName);
    }

    public int SecurityCheck(string modelName)  //  string employeeName
    {
        IEmployee? employee = GetByName(modelName);

        if (employee == null)
        {
            return 0;
        }

        var securityLevel = employee.Department.SecurityLevel;

        return securityLevel;
    }
}