namespace Lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductFactory motherboardFactory = new MotherboardFactory();
            ProductFactory processorFactory = new ProcessorFactory();
            ProductFactory hardDriveFactory = new HardDriveFactory();
            ProductFactory memoryFactory = new MemoryFactory();
            
            List<Product> products = CreateProducts(motherboardFactory, processorFactory, hardDriveFactory, memoryFactory);
            List<ProductFactory> factories = new List<ProductFactory>()
                {motherboardFactory, processorFactory, hardDriveFactory, memoryFactory};
            
            string keyword = "Processor";
            
            List<Product> searchResults = SearchProducts(factories, keyword, 500, 250);
            PrintProducts(searchResults, keyword);
        }

        static List<Product> CreateProducts(ProductFactory motherboardFactory, ProductFactory processorFactory, 
                                            ProductFactory hardDriveFactory, ProductFactory memoryFactory)
        {
            List<Product> products = new List<Product>();
            Random rand = new Random();
            for (int i = 0; i < 15; i++)
            {
                string zeros = String.Concat(Enumerable.Repeat("0", 4 - i.ToString().Length));
                products.Add(motherboardFactory.CreateProduct($"MB{zeros}{i}", $"Motherboard {i}", rand.NextInt64(50, 950)));
                products.Add(processorFactory.CreateProduct($"CPU{zeros}{i}", $"Processor {i}", rand.NextInt64(50, 950)));
                products.Add(hardDriveFactory.CreateProduct($"HD{zeros}{i}", $"Hard Drive {i}", rand.NextInt64(50, 950)));
                products.Add(memoryFactory.CreateProduct($"MEM{zeros}{i}", $"Memory {i}", rand.NextInt64(50, 950)));
            }
            
            return products;
        }

        static List<Product> SearchProducts(List<ProductFactory> factories, string keyword, int upperPrice = Int32.MaxValue, int lowerPrice = 0)
        {
            List<Product> searchResults = new List<Product>();

            foreach (var factory in factories)
            {
                searchResults.AddRange(factory.SearchProducts(keyword, upperPrice, lowerPrice));
            }

            return searchResults;
        }

        static void PrintProducts(List<Product> searchResults, string keyword)
        {
            Console.WriteLine($"Search Results for '{keyword}'");
            if (searchResults.Count > 0)
                foreach (var product in searchResults)
                    Console.WriteLine(product);
            else
                Console.WriteLine("No results found.");
        }
    }
}