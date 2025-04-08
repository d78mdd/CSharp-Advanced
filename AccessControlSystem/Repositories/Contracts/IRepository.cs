namespace AccessControlSystem.Repositories.Contracts
{
    public interface IRepository<T> where T : class
    {
        IReadOnlyCollection<T> Models { get; }




        void AddNew(T model);

        T? GetByName(string modelName);   // string employeeName   // '?' should be ok

        int SecurityCheck(string modelName);
    }
}
