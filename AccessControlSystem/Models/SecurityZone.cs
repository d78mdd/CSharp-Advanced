using AccessControlSystem.Models.Contracts;
using AccessControlSystem.Utilities.Messages;

namespace AccessControlSystem.Models;

public class SecurityZone : ISecurityZone
{
    public string Name { get; }

    public int AccessLevelRequired { get; }


    private List<int> _accessLog;
    public IReadOnlyCollection<int> AccessLog { get; }



    public SecurityZone(string name, int accessLevelRequired)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException(ExceptionMessages.InvalidSecurityZoneName);
        }
        Name = name;

        if (accessLevelRequired < 0)  // < 1 ??
        {
            throw new ArgumentException(ExceptionMessages.InvalidAccessLevel);
        }
        AccessLevelRequired = accessLevelRequired;

        _accessLog = new List<int>();
        AccessLog = _accessLog.AsReadOnly();
    }



    public void LogAccessKey(int securityId)
    {
        _accessLog.Add(securityId);
    }
}