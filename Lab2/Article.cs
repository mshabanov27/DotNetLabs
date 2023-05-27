namespace Lab2
{
    public class Article
    {
        public string Name { get; set; }
        private List<Author> _authors = new List<Author>();
        public Journal Journal { get; set; }
        public DateOnly PublicationDate { get; set; }

        public Article(string name, Journal journal, DateOnly publicationDate, Author author)
        {
            Name = name;
            Journal = journal;
            PublicationDate = publicationDate;
            AddAuthor(author);
        }

        public List<Author> Authors
        {
            get => _authors;
        }

        public void AddAuthor(Author author)
        {
            _authors.Add(author);
        }
        
        public void RemoveAuthor(Author author)
        {
            _authors.Remove(author);
        }

        public override string ToString()
        {
            string authorsStr = "";
            foreach (var author in _authors)
                authorsStr += $"{author.Name} {author.Surname}, ";
                
            return $"Name: {Name}, Authors: {authorsStr}Journal: {Journal.Name}, Date: {PublicationDate}";
        }
    }
}