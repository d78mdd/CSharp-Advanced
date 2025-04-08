namespace AccessControlSystem.Models.Contracts
{
    public interface ISecurityZone
    {
        string Name { get; }

        int AccessLevelRequired { get; }

        IReadOnlyCollection<int> AccessLog { get; }



        void LogAccessKey(int securityId);
    }
}
