namespace AccessControlSystem.Utilities.Messages
{
    public class ExceptionMessages
    {
        //Employee
        public const string InvalidEmployeeName = "Employee name is required.";

        public const string InvalidDepartmentName = "Department value cannot be null or whitespace.";

        public const string InvalidSecurityId = "Security ID must be in the range [100-999].";

        //Department
        public const string InvalidDepartmentCapacity = "Department has reached its maximum employee capacity.";

        public const string EmployeeAlreadyAdded = "Employee is already added to the department.";

        //SecurityZone
        public const string InvalidSecurityZoneName = "Security zone name is required.";

        public const string InvalidAccessLevel = "Required access level cannot be a negative number.";
    }
}
