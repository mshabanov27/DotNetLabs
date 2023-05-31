namespace Lab5;

public interface IComputerComponent
{
    void Accept(IVisitor visitor);
}

public class Cpu : IComputerComponent
{
    public int Power { get; set; }

    public Cpu(int power)
    {
        Power = power;
    }

    public void Accept(IVisitor visitor)
    {
        visitor.VisitCpu(this);
    }
}

public class Memory : IComputerComponent
{
    public int Power { get; set; }

    public Memory(int power)
    {
        Power = power;
    }

    public void Accept(IVisitor visitor)
    {
        visitor.VisitMemory(this);
    }
}

public class Gpu : IComputerComponent
{
    public int Power { get; set; }

    public Gpu(int power)
    {
        Power = power;
    }

    public void Accept(IVisitor visitor)
    {
        visitor.VisitGpu(this);
    }
}

public class Motherboard : IComputerComponent
{
    public int Power { get; set; }

    public Motherboard(int power)
    {
        Power = power;
    }

    public void Accept(IVisitor visitor)
    {
        visitor.VisitMotherboard(this);
    }
}