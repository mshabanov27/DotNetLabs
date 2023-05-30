namespace Lab4;


class Position : Component
{
    private int staffCount;
    private double salary;

    public Position(string name, int staffCount, double salary) : base(name)
    {
        this.staffCount = staffCount;
        this.salary = salary;
    }

    public override void Display(int depth)
    {
        Console.WriteLine(new string('-', depth) + name);
    }

    public override int GetTotalStaff()
    {
        return staffCount;
    }

    public override double GetTotalSalary()
    {
        return staffCount * salary;
    }
}
