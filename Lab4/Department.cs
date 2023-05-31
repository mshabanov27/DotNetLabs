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

    public override void Display(int depth=0)
    {
        Console.WriteLine(String.Concat(Enumerable.Repeat('-', depth)) + name);

        foreach (Component component in children)
        {
            component.Display(depth + 3);
        }
    }

    public override int GetTotalStaff()
    {
        int totalStaff = 0;

        foreach (Component component in children)
            totalStaff += component.GetTotalStaff();

        return totalStaff;
    }

    public override float GetTotalSalary()
    {
        float totalSalary = 0;

        foreach (Component component in children)
            totalSalary += component.GetTotalSalary();

        return totalSalary;
    }
}