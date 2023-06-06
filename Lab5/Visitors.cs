namespace Lab5;


public interface IVisitor
{
    void VisitCpu(Cpu cpu);
    void VisitMemory(Memory memory);
    void VisitGpu(Gpu gpu);
    void VisitMotherboard(Motherboard motherboard);
}


public class PowerVisitor : IVisitor
{
    private int _totalPower;

    public void VisitCpu(Cpu cpu)
    {
        _totalPower += cpu.Power;
    }

    public void VisitMemory(Memory memory)
    {
        _totalPower += memory.Power;
    }

    public void VisitGpu(Gpu gpu)
    {
        _totalPower += gpu.Power;
    }
    
    public void VisitMotherboard(Motherboard motherboard)
    {
        _totalPower += motherboard.Power;
    }

    public int GetTotalPower()
    {
        return _totalPower;
    }
}