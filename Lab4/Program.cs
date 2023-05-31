namespace Lab4;


class Program
{
    static void Main(string[] args)
    {
        var company = CreateCompany();
        
        int totalStaff = company.GetTotalStaff();
        float totalSalary = company.GetTotalSalary();
        
        PrintCompany(company, totalStaff, totalSalary);
    }

    static Component CreateCompany()
    {
        Department company = new Department("Big-Big Company");
        
        Department department1 = new Department("Department 1");
        company.Add(department1);
        
        
        Position headmaster = new Position("Headmaster", 5, 1000);
        Position topManager = new Position("Top Manager", 3, 1200);
        department1.Add(headmaster);
        department1.Add(topManager);

        
        Department department1_1 = new Department("Department 1.1");
        Department department1_2 = new Department("Department 1.2");
        department1.Add(department1_1);
        department1.Add(department1_2);

        
        Position journalist = new Position("Journalist", 4, 900);
        Position newspaperEditor = new Position("Newspaper Editor", 2, 1500);
        department1_1.Add(journalist);
        department1_1.Add(newspaperEditor);

        Position administrator = new Position("Administrator", 3, 2500);
        department1_2.Add(administrator);

        return company;
    }
    
    static void PrintCompany(Component company, int totalStaff, float totalSalary)
    {
        Console.WriteLine();
        
        company.Display();

        Console.WriteLine("\nTotal Staff: " + totalStaff);
        Console.WriteLine("Total Salary: " + totalSalary);
    }
}

