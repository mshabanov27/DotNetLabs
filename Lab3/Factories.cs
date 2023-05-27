namespace Lab3;


abstract class ProductFactory
{
    public abstract Product CreateProduct(string nomenclatureNumber, string name, float price);
    public abstract List<Product> SearchProducts(string keyword, int upperPrice, int lowerPrice);
}


class MotherboardFactory : ProductFactory
{
    private List<Motherboard> motherboards = new List<Motherboard>();

    public override Product CreateProduct(string nomenclatureNumber, string name, float price)
    {
        var motherboard =
            new Motherboard(nomenclatureNumber, name, price);
        motherboards.Add(motherboard);
        return motherboard;
    }
    

    public override List<Product> SearchProducts(string keyword, int upperPrice, int lowerPrice)
    {
        return motherboards.Where(m => m.Name.Contains(keyword))
            .Where(p => p.Price < upperPrice && p.Price > lowerPrice)
            .ToList<Product>();
    }
}


class ProcessorFactory : ProductFactory
{
    private List<Processor> processors = new List<Processor>();

    public override Product CreateProduct(string nomenclatureNumber, string name, float price)
    {
        var processor = new Processor(nomenclatureNumber, name, price);
        processors.Add(processor);
        return processor;
    }

    public override List<Product> SearchProducts(string keyword, int upperPrice, int lowerPrice)
    {
        return processors.Where(p => p.Name.Contains(keyword))
            .Where(p => p.Price < upperPrice && p.Price > lowerPrice)
            .ToList<Product>();
    }
}


class HardDriveFactory : ProductFactory
{
    private List<HardDrive> hardDrives = new List<HardDrive>();

    public override Product CreateProduct(string nomenclatureNumber, string name, float price)
    {
        // Потрібно вказати всі необхідні атрибути при створенні об'єкта
        var hardDrive = new HardDrive(nomenclatureNumber, name, price);
        hardDrives.Add(hardDrive);
        return hardDrive;
    }

    public override List<Product> SearchProducts(string keyword, int upperPrice, int lowerPrice)
    {
        return hardDrives.Where(h => h.Name.Contains(keyword))
            .Where(p => p.Price < upperPrice && p.Price > lowerPrice)
            .ToList<Product>();
    }
}


class MemoryFactory : ProductFactory
{
    private List<Memory> memories = new List<Memory>();

    public override Product CreateProduct(string nomenclatureNumber, string name, float price)
    {
        var memory = new Memory(nomenclatureNumber, name, price);
        memories.Add(memory);
        return memory;
    }

    public override List<Product> SearchProducts(string keyword, int upperPrice, int lowerPrice)
    {
        return memories.Where(m => m.Name.Contains(keyword))
            .Where(p => p.Price < upperPrice && p.Price > lowerPrice)
            .ToList<Product>();
    }
}