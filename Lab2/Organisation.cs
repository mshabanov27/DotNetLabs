namespace Lab2
{
    public class Organisation
    {
        public string Name { get; set; }
        public int EmployeesNumber { get; set; }
        
        public Organisation(string name, int employeesNumber)
        {
            Name = name;
            EmployeesNumber = employeesNumber;
        }

        public override string ToString()
        {
            return $"Name: {Name}, {EmployeesNumber} employees";
        }
    }
}