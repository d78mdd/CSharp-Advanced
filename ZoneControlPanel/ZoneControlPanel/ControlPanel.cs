using System.Text;

namespace ZoneControlPanel
{
    public class ControlPanel
    {
        private List<Employee> employees;
        private List<SecureZone> secureZones;

        public ControlPanel(string[] secureZones)
        {
            this.secureZones = new List<SecureZone>();
            this.employees = new List<Employee>();

            foreach (string secureZone in secureZones)
            {
                this.secureZones.Add(new SecureZone(secureZone));
            }
        }



        public IReadOnlyCollection<Employee> Employees => this.employees.AsReadOnly();

        public IReadOnlyCollection<SecureZone> SecureZones => this.secureZones.AsReadOnly();





        public void AddEmployee(Employee employee)
        {
            if (employees.Select(e => e.FullName).Contains(employee.FullName))
            {
                return;
            }
            employees.Add(employee);
        }

        public bool AuthorizeEmployee(string employeeFullName, string secureZoneName)
        {
            Employee? employee = employees.Find(e => e.FullName == employeeFullName);
            SecureZone? secureZone = secureZones.Find(s => s.Name == secureZoneName);

            if (employee == null || secureZone == null)
            {
                return false;
            }

            if(secureZone.AccessLog.Contains(employee.AccessStamp))
            {
                throw new InvalidOperationException("Access stamp already exists in AccessLog list.");
            }

            secureZone.GrantAccess(employee);
            return true;
        }

        public string SecureZonesStatus(string secureZoneName)
        {
            SecureZone? secureZone = secureZones.Find(s => s.Name == secureZoneName);
            if (secureZone == null)
            {
                return "Secure zone not found";
            }
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Secure zone: {secureZone.Name}");
            sb.AppendLine("Access log:");
            foreach (int accessStamp in secureZone.AccessLog)
            {
                Employee? employee = employees.Find(e => e.AccessStamp == accessStamp);
                if (employee != null)
                {
                    sb.AppendLine(employee.ToString().TrimEnd());
                }
            }
            return sb.ToString().TrimEnd();
        }
    }
}
