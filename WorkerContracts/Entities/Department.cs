namespace WorkerContracts.Entities
{
    public class Department
    {
        public string Name { get; private set; }

        public Department(string name)
        {
            Name = name;
        }

        public override string ToString()
        {
            return $"Department {Name}";
        }
    }
}
