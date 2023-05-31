namespace Lab5;


public class Program
{
    public static void Main()
    {
        var computer = CreateComputer();
        int totalPower = CalculateTotalPower(computer);
        PrintTotalPower(totalPower);
    }

    static List<IComputerComponent> CreateComputer()
    {
        var computer = new List<IComputerComponent>
        {
            new Cpu(power: 100),
            new Memory(power: 50),
            new Gpu(power: 300),
            new Motherboard(power: 250)
        };

        return computer;
    }

    static int CalculateTotalPower(List<IComputerComponent> computer)
    {
        var powerVisitor = new PowerVisitor();

        foreach (var component in computer)
        {
            component.Accept(powerVisitor);
        }

        return powerVisitor.GetTotalPower();
    }

    static void PrintTotalPower(int totalPower)
    {
        Console.WriteLine("Total power consumption: " + totalPower + " watts");
    }
}
