namespace Lab4;


class Program
{
    static void Main(string[] args)
    {
        // Створення структури підрозділів і посад

        // Підрозділ 1
        Department division1 = new Department("Division 1");

        // Підрозділ 1.1
        Department department1_1 = new Department("Department 1.1");
        division1.Add(department1_1);

        // Посади в підрозділі 1.1
        Position position1_1_1 = new Position("Position 1.1.1", 5, 1000);
        Position position1_1_2 = new Position("Position 1.1.2", 3, 1200);
        department1_1.Add(position1_1_1);
        department1_1.Add(position1_1_2);

        // Підрозділ 1.2
        Department department1_2 = new Department("Department 1.2");
        division1.Add(department1_2);

        // Посади в підрозділі 1.2
        Position position1_2_1 = new Position("Position 1.2.1", 4, 900);
        Position position1_2_2 = new Position("Position 1.2.2", 2, 1500);
        department1_2.Add(position1_2_1);
        department1_2.Add(position1_2_2);

        // Виведення штатного розкладу для підрозділу 1
        division1.Display(0);

        // Розрахунок загальної кількості штатних одиниць та сумарного окладу
        int totalStaff = division1.GetTotalStaff();
        double totalSalary = division1.GetTotalSalary();
        Console.WriteLine("Total Staff: " + totalStaff);
        Console.WriteLine("Total Salary: " + totalSalary);

        Console.ReadLine();
    }
}

