namespace AccessControlSystem.Models.Contracts
{
    public interface IEmployee
    {
        string Name { get; }
        IDepartment Department { get; }
        int SecurityId { get; }

        void AssignToDepartment(IDepartment department);
    }
}
