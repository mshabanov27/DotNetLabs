namespace Lab3;


abstract class Product
{
    public string NomenclatureNumber { get; }
    public string Name { get; }
    public float Price { get; }

    protected Product(string nomenclatureNumber, string name, float price)
    {
        NomenclatureNumber = nomenclatureNumber;
        Name = name;
        Price = price;
    }
}


class Motherboard : Product
{
    public string SocketType { get; }
    public string Chipset { get; }
    public int ProcessorCount { get; }
    public string MemoryType { get; }
    public int SystemBusFrequency { get; }

    public Motherboard(string nomenclatureNumber, string name, float price) : base(nomenclatureNumber, name, price)
    {
        SocketType = "SocketType";
        Chipset = "Chipset";
        ProcessorCount = 4;
        MemoryType = "MemoryType";
        SystemBusFrequency = 200;
    }
    
    public Motherboard(string nomenclatureNumber, string name, float price, string socketType, string chipset,
        int processorCount, string memoryType, int systemBusFrequency) : base(nomenclatureNumber, name, price)
    {
        SocketType = socketType;
        Chipset = chipset;
        ProcessorCount = processorCount;
        MemoryType = memoryType;
        SystemBusFrequency = systemBusFrequency;
    }

    public override string ToString()
    {
        string characteristics = "";
        characteristics += $"Product: Motherboard \nNomenclature Number: {NomenclatureNumber} \nName: {Name} \n";
        characteristics += $"Price: {Price} \nSocket Type: {SocketType} \nChipset: {Chipset} \nProcessor Count: {ProcessorCount}\n";
        characteristics += $"Memory Type: {MemoryType} \nSystem Bus Frequency: {SystemBusFrequency} \n";
        return characteristics;
    }
}


class Processor : Product
{
    public string SocketType { get; }
    public int CoreCount { get; }
    public int ClockSpeed { get; }

    public Processor(string nomenclatureNumber, string name, float price) : base(nomenclatureNumber, name, price)
    {
        SocketType = "SocketType";
        CoreCount = 8;
        ClockSpeed = 3000;
    }
    
    public Processor(string nomenclatureNumber, string name, float price, string socketType, int coreCount, int clockSpeed) 
        : base(nomenclatureNumber, name, price)
    {
        SocketType = socketType;
        CoreCount = coreCount;
        ClockSpeed = clockSpeed;
    }

    public override string ToString()
    {
        string characteristics = "";
        characteristics += $"Product: Processor \nNomenclature Number: {NomenclatureNumber} \nName: {Name} \n";
        characteristics += $"Price: {Price} \nSocket Type: {SocketType} \nCore Count: {CoreCount} \nClock Speed: {ClockSpeed} \n";
        return characteristics;
    }
}


class HardDrive : Product
{
    public int Capacity { get; }
    public int Speed { get; }
    public string Interface { get; }

    public HardDrive(string nomenclatureNumber, string name, float price): base(nomenclatureNumber, name, price)
    {
        Capacity = 1000;
        Speed = 7200;
        Interface = "SATA";
    }
    
    public HardDrive(string nomenclatureNumber, string name, float price, int capacity, int speed, string interfaceType)
        : base(nomenclatureNumber, name, price)
    {
        Capacity = capacity;
        Speed = speed;
        Interface = interfaceType;
    }

    public override string ToString()
    {
        string characteristics =  "";
        characteristics += $"Product: Hard Drive \nNomenclature Number: {NomenclatureNumber} \nName: {Name} \n";
        characteristics += $"Price: {Price} \nCapacity: {Capacity} \nSpeed: {Speed} \nInterface: {Interface}";
        return characteristics;
    }
}


class Memory : Product
{
    public int Capacity { get; }
    public string Type { get; }
    public int Frequency { get; }
    public int ModuleCount { get; }

    public Memory(string nomenclatureNumber, string name, float price) : base(nomenclatureNumber, name, price)
    {
        Capacity = 16;
        Type = "DDR4";
        Frequency = 3200;
        ModuleCount = 2;
    }
    
    public Memory(string nomenclatureNumber, string name, float price, int capacity, string type, int frequency, int moduleCount) 
        : base(nomenclatureNumber, name, price)
    {
        Capacity = capacity;
        Type = type;
        Frequency = frequency;
        ModuleCount = moduleCount;
    }

    public override string ToString()
    {
        string characteristics = "";
        characteristics += $"Product: Memory \nNomenclature Number: {NomenclatureNumber} \nName: {Name} \n";
        characteristics += $"Price: {Price} \nCapacity: {Capacity} \nType: {Type} \nFrequency: {Frequency} \nModule Count: {ModuleCount} \n";
        return characteristics;
    }
}