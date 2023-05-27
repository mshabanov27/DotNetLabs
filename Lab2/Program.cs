using System.Globalization;
using System.Xml;
using System.Xml.Linq;


namespace Lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            var organisations = DataGenerator.GenerateOrganisations();
            var journals = DataGenerator.GenerateJournals();
            var authors = DataGenerator.GenerateAuthors(organisations);
            var articles = DataGenerator.GenerateArticles(journals, authors);

            XmlWorker.WriteXmlFile(articles);
            
            XmlDocument doc = new XmlDocument();
            doc.Load("articles.xml");

            XDocument xmldoc = XDocument.Load("articles.xml");
            bool errors = XmlWorker.ValidateArticles("articlesSchema.xsd", xmldoc);
            
            if (errors)
                Console.WriteLine("Articles document did not validate");
            else
            {
                XmlWorker.PrintXmlArcticles(doc);
                
                StartQueries(xmldoc);
            }
        }

        static void StartQueries(XDocument xmldoc)
        {
            var understandingArticles = from article in xmldoc.Descendants("article")
                where article.Element("name").Value.Contains("Understanding")
                select article.Element("name").Value;

            PrintObject(understandingArticles, "Articles with the word 'Understanding' in the name");

            var kimberlyArticles = from article in xmldoc.Descendants("article")
                where article.Descendants("author").Any(author => author.Element("name").Value == "Kimberly")
                select new
                {
                    Name = article.Element("name").Value,
                    PublicationDate = DateTime.ParseExact(article.Element("publicationDate").Value, "dd.MM.yyyy",
                        CultureInfo.InvariantCulture)
                };

            PrintObject(kimberlyArticles, "Articles authored by Kimberly Ramirez");

            var circulationOver4000 = (from journal in xmldoc.Descendants("journal")
                where int.Parse(journal.Element("circulation").Value) > 7000
                select new
                {
                    Name = journal.Element("name").Value,
                    IssueDate = DateTime.ParseExact(journal.Element("issueDate").Value, "dd.MM.yyyy",
                        CultureInfo.InvariantCulture),
                    Circulation = journal.Element("circulation").Value
                }).Distinct();

            PrintObject(circulationOver4000, "Journals with circulation greater than 7000");

            var anassaBefore2010 = from author in xmldoc.Descendants("author")
                where author.Element("organisation")
                          .Element("name").Value == "Anassa"
                      && DateTime.ParseExact(author.Ancestors("article")
                              .First()
                              .Element("publicationDate")
                              .Value, "dd.MM.yyyy", CultureInfo.InvariantCulture)
                          .Year < 2010
                select new
                {
                    Name = author.Element("name").Value,
                    Surname = author.Element("surname").Value
                };

            PrintObject(anassaBefore2010, "Authors who work for Anassa and have published an article before 2010");

            var rAuthors = from article in xmldoc.Descendants("article")
                where article.Descendants("author").Any(a => a.Element("surname").Value.StartsWith("R"))
                select new
                {
                    Name = article.Element("name").Value,
                    PublicationDate = article.Element("publicationDate").Value
                };

            PrintObject(rAuthors, "Articles whose authors' surnames start with letter R");

            var fromIssueToPublication = from article in xmldoc.Descendants("article")
                let publicationDate = DateTime.ParseExact(article.Element("publicationDate").Value, "dd.MM.yyyy",
                    CultureInfo.InvariantCulture)
                let issueDate = DateTime.ParseExact(article.Element("journal").Element("issueDate").Value, "dd.MM.yyyy",
                    CultureInfo.InvariantCulture)
                select new
                {
                    Name = article.Element("name").Value,
                    DaysSinceIssue = (int) (publicationDate - issueDate).TotalDays
                };

            PrintObject(fromIssueToPublication,
                "Article names and the number of days between its publication date and the issue date of the journal it was published in");

            var smallAuthors = from article in xmldoc.Descendants("article")
                where int.Parse(article.Element("journal").Element("circulation").Value) < 5000
                from author in article.Descendants("author")
                select $"{author.Element("name").Value} {author.Element("surname").Value}";

            PrintObject(smallAuthors,
                "Authors who have written articles for journals with a circulation of fewer than 5000");

            var articleCounts = from article in xmldoc.Descendants("article")
                group article by article.Element("journal").Element("name").Value
                into journalGroup
                select new {Journal = journalGroup.Key, Count = journalGroup.Count()};

            PrintObject(articleCounts, "Number of articles published in each journal");

            var mostRecentAuthor = (from article in xmldoc.Descendants("article")
                let publicationDate = DateTime.ParseExact(article.Element("publicationDate").Value, "dd.MM.yyyy",
                    CultureInfo.InvariantCulture)
                orderby publicationDate descending
                select new
                {
                    Name = article.Descendants("author").First().Element("name").Value,
                    Surname = article.Descendants("author").First().Element("surname").Value
                }).FirstOrDefault();

            Console.WriteLine($"Author who published the most recent article: \n{mostRecentAuthor}\n");

            var authorsMoreJournals = from article in xmldoc.Descendants("article")
                from author in article.Descendants("author")
                group author by new
                {
                    Name = author.Element("name").Value,
                    SecondName = author.Element("secondName").Value,
                    Surname = author.Element("surname").Value
                }
                into authorGroup
                where authorGroup.Select(author => author.Parent.Parent.Element("journal").Element("name").Value)
                    .Distinct().Count() > 1
                select $"{authorGroup.Key.Name} {authorGroup.Key.SecondName} {authorGroup.Key.Surname}";

            PrintObject(authorsMoreJournals,
                "Names of the authors who have published articles in more than one journal");

            var journalsByPeriod = from article in xmldoc.Descendants("article")
                group article.Element("journal").Element("name").Value by article.Element("journal")
                    .Element("issuePeriodDays").Value
                into g
                select new {Period = g.Key, Journals = String.Join("; ", g.Distinct().ToArray())};

            PrintObject(journalsByPeriod, "Journals, grouped by their issue period in days");

            var ascendingAuthors = from article in xmldoc.Descendants("article")
                let authorCount = article.Descendants("author").Count()
                orderby authorCount ascending
                select new {Name = article.Element("name").Value, AuthorCount = authorCount};

            PrintObject(ascendingAuthors, "Number of authors for each article in ascending order");


            var articlesByJournal = from article in xmldoc.Descendants("article")
                group article by article.Element("journal").Element("name").Value
                into journalGroup
                select new
                {
                    JournalName = journalGroup.Key,
                    Articles = String.Join("; ",
                        journalGroup.ToList().Select(groupJournals => groupJournals.Element("name").Value))
                };

            PrintObject(articlesByJournal, "Articles grouped by the name of the journal they were published in");

            var countYears = (from article in xmldoc.Descendants("article")
                group article by article.Element("publicationDate").Value.Substring(6)
                into yearGroup
                select new {Year = yearGroup.Key, Count = yearGroup.Count()}).OrderBy(years => years.Year);

            PrintObject(countYears, "The count of articles published in each year");

            var bothJournals = (from author in xmldoc.Descendants("author")
                    join article in xmldoc.Descendants("article") on author.Element("name").Value equals article
                        .Descendants("author").First().Element("name").Value
                    group article by author
                    into authorGroup
                    where authorGroup.Select(article => article.Element("journal").Element("name").Value).Distinct()
                        .Count() >= 2
                    select $"{authorGroup.Key.Element("name").Value} {authorGroup.Key.Element("surname").Value}")
                .Distinct();

            PrintObject(bothJournals, "Authors who have published articles in at least two different journals");
        }
        
        static void PrintObject<T>(IEnumerable<T> objects, string description)
        {
            Console.WriteLine($"{description}:");
            foreach (var obj in objects)
            {
                Console.WriteLine($"{obj};");
            }
            Console.WriteLine("\n");
        }
    }
}