namespace ZoneControlPanel
{
    public class Employee
    {
        private string fullName;
        private string position;
        private int accessStamp;

        public Employee(string fullName, string position, int accessStamp)
        {
            FullName = fullName;
            Position = position;
            AccessStamp = accessStamp;
        }

        public string FullName { get => fullName; set => fullName = value; }

        public string Position { get => position; set => position = value; }

        public int AccessStamp { get => accessStamp; set => accessStamp = value; }

        public override string ToString()
        {
            return $"{AccessStamp} - ({Position}: {FullName})";
        }
    }
}
