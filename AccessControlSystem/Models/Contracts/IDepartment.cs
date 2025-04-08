namespace AccessControlSystem.Models.Contracts
{
    public interface IDepartment
    {
        int SecurityLevel { get; }

        IReadOnlyCollection<string> Employees { get; }

        int MaxEmployeesCount { get; }



        void ContractEmployee(string employeeName);
    }
}
