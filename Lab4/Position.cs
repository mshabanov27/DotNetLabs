namespace Lab4;


class Position : Component
{
    private int staffCount;
    private float salary;

    public Position(string name, int staffCount, float salary) : base(name)
    {
        this.staffCount = staffCount;
        this.salary = salary;
    }

    public override void Display(int depth=0)
    {
        Console.WriteLine(String.Concat(Enumerable.Repeat('-', depth)) + name);
    }

    public override int GetTotalStaff()
    {
        return staffCount;
    }

    public override float GetTotalSalary()
    {
        return staffCount * salary;
    }
}
