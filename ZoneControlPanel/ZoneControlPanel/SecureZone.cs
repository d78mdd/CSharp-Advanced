namespace ZoneControlPanel
{
    public class SecureZone
    {
        private List<int> accessLog;
        private string name;

        public SecureZone(string name)
        {
            Name = name;
            this.AccessLog = new List<int>();
        }

        public string Name { get => name; set => name = value; }

        public List<int> AccessLog { get => accessLog; set => accessLog = value; }

        public void GrantAccess(Employee employee)
        {
            AccessLog.Add(employee.AccessStamp);
        }
    }
}
