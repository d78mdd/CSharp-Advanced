using AccessControlSystem.Core.Contracts;
using AccessControlSystem.IO.Contracts;
using AccessControlSystem.IO;

namespace AccessControlSystem.Core
{
    public class Engine : IEngine
    {
        private IReader reader;
        private IWriter writer;
        private IController controller;

        public Engine()
        {
            reader = new Reader();
            writer = new Writer();
            controller = new Controller();
        }
        public void Run()
        {
            while (true)
            {
                string[] input = reader.ReadLine().Split();
                if (input[0] == "Exit")
                {
                    Environment.Exit(0);
                }
                try
                {
                    string result = string.Empty;

                    if (input[0] == "AddDepartment")
                    {
                        string departmentTypeName = input[1];

                        result = controller
                            .AddDepartment(departmentTypeName);
                    }
                    else if (input[0] == "AddEmployeeToApplication")
                    {
                        string employeeName = input[1];
                        string employeeTypeName = input[2];
                        int securityId = int.Parse(input[3]);

                        result = controller
                            .AddEmployeeToApplication(employeeName, employeeTypeName, securityId);
                    }
                    else if (input[0] == "AddEmployeeToDepartment")
                    {
                        string employeeName = input[1];
                        string departmentTypeName = input[2];

                        result = controller
                            .AddEmployeeToDepartment(employeeName, departmentTypeName);
                    }
                    else if (input[0] == "AddSecurityZone")
                    {
                        string securityZoneName = input[1];
                        int accessLevelRequired = int.Parse(input[2]);

                        result = controller
                            .AddSecurityZone(securityZoneName, accessLevelRequired);
                    }
                    else if (input[0] == "AuthorizeAccess")
                    {
                        string securityZoneName = input[1];
                        string employeeName = input[2];

                        result = controller
                            .AuthorizeAccess(securityZoneName, employeeName);
                    }
                    else if (input[0] == "SecurityReport")
                    {
                        result = controller.SecurityReport();
                    }
                    writer.WriteLine(result);
                    writer.WriteText(result);
                }
                catch (Exception ex)
                {
                    writer.WriteLine(ex.Message);
                    writer.WriteText(ex.Message);
                }
            }
        }
    }
}
