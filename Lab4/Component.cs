namespace Lab4;


abstract class Component
{
    protected string name;

    public Component(string name)
    {
        this.name = name;
    }

    public abstract void Display(int depth=0);
    public abstract int GetTotalStaff();
    public abstract float GetTotalSalary();
}