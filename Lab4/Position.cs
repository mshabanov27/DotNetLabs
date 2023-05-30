namespace Lab4;


class Department : Component
{
    private List<Component> children = new List<Component>();

    public Department(string name) : base(name)
    {
    }

    public void Add(Component component)
    {
        children.Add(component);
    }

    public void Remove(Component component)
    {
        children.Remove(component);
    }

    public override void Display(int depth)
    {
        Console.WriteLine(new string('-', depth) + name);

        foreach (Component component in children)
        {
            component.Display(depth + 2);
        }
    }

    public override int GetTotalStaff()
    {
        int totalStaff = 0;

        foreach (Component component in children)
        {
            totalStaff += component.GetTotalStaff();
        }

        return totalStaff;
    }

    public override double GetTotalSalary()
    {
        double totalSalary = 0;

        foreach (Component component in children)
        {
            totalSalary += component.GetTotalSalary();
        }

        return totalSalary;
    }
}