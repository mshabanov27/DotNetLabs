namespace Lab2
{
    public class Author
    {
        public string Surname { get; set; }
        public string Name { get; set; }
        public string SecondName { get; set; }
        public Organisation Work { get; set; }

        public Author(string surname, string name, string secondName, Organisation work)
        {
            Surname = surname;
            Name = name;
            SecondName = secondName;
            Work = work;
        }

        public override string ToString()
        {
            return $"{Name} {Surname} {SecondName}, works at {Work.Name}";
        }
    }
}