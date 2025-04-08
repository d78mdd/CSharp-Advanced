namespace AccessControlSystem.Utilities.Messages
{
    public class OutputMessages
    {
        //Common
        public const string InvalidDepartmentType = "{0} is not a valid department type.";

        public const string EmployeeNotInApplication = "{0} is not added to the application.";

        //AddDepartment
        public const string DepartmentExists = "{0} is already created.";

        public const string DepartmentAdded = "{0} is successfully created.";

        //AddEmployeeToApplication
        public const string InvalidEmployeeType = "{0} is not a valid employee type.";

        public const string EmployeeExistsInApplication = "{0} is already added to the application.";

        public const string EmployeeAddedToApplication = "{0} is successfully added to the application.";

        public const string SecurityIdExists = "Security ID {0} is already taken.";


        //AddEmployeeToDepartment
        public const string DepartmentIsNotAvailable = "{0} is not available.";

        public const string DepartmentFull = "{0} is full.";

        public const string EmployeeExistsInDepartment = "{0} is already added to department.";

        public const string ContractNotAllowed = "{0} cannot be added to {1}.";

        public const string EmployeeAddedToDepartment = "{0} is successfully assigned to {1}.";

        //AddSecurityZone
        public const string SecurityZoneExists = "{0} is already created.";

        public const string SecurityZoneAdded = "{0} is successfully created.";

        //AurhorizeAccess
        public const string SecurityZoneNotFound = "{0} is not found.";

        public const string AccessDenied = "{0} is denied access to {1}.";

        public const string EmployeeAlreadyAuthorized = "{0} is already authorized to access {1}.";

        public const string EmployeeAuthorized = "{0} is authorized to access {1}.";
    }
}
