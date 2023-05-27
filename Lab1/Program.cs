using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            var organisations = DataGenerator.GenerateOrganisations();
            var journals = DataGenerator.GenerateJournals();
            var authors = DataGenerator.GenerateAuthors(organisations);
            var articles = DataGenerator.GenerateArticles(journals, authors);

            var journalsAfter2010 = journals.Where(journal => journal.IssueDate.Year > 2010);
            
            PrintObject(journalsAfter2010, "Journals issued after 2010");
            
            var authorsWithSameLetter = authors.Where(a => a.Name[0] == a.SecondName[0]);
            
            PrintObject(authorsWithSameLetter, "Authors who have the same capital letter in their Name and Second name");

            var understandingArticles = from article in articles
                where article.Name.Contains("Understanding")
                select article;
            
            PrintObject(understandingArticles, "Articles that start with the word 'Understanding'");

            var sortedArticles = articles
                .Where(a => a.Name.Contains(':'))
                .OrderBy(a => a.Name)
                .ThenBy(a => a.PublicationDate);
            
            PrintObject(sortedArticles, "Articles that contain ':' sign and are sorted by name and date");
            
            var bigOrganisations = from org in organisations
                where org.EmployeesNumber > 100
                select org;
            
            PrintObject(bigOrganisations, "Organisations, where employees number is over 100");
            
            var articlesInJournalsWithPeriod = articles
                .Where(a => journals
                    .Where(j => j.IssuePeriodDays == 7)
                    .Contains(a.Journal));
            
            PrintObject(articlesInJournalsWithPeriod, "Articles that are published in journals every 7 days");
            
            var authorsInNatureMedicine = articles
                .Where(a => a.Journal.Name == "Nature Medicine")
                .Select(a => a.Authors)
                .SelectMany(a => a)
                .Distinct();
            
            PrintObject(authorsInNatureMedicine, "All authors who have published at least one article in 'Nature Medicine' journal");
            
            var articlesByJournal = articles
                .GroupBy(a => a.Journal)
                .Select(g => new { Title = g.Key.Name, Count = g.Count() });

            PrintObject(articlesByJournal, "The total number of articles published in each journal");
            
            var top5Authors =  (
                from article in articles
                from author in article.Authors
                group author by author into topAuthors
                orderby topAuthors.Count() descending
                select topAuthors.Key
            ).Take(5);
            
            PrintObject(top5Authors, "Top 5 authors with most articles");
            
            var authorsInOrganisation = authors.Where(a => a.Work.Name == "Le Bristol");
            
            PrintObject(authorsInOrganisation, "Authors who work at 'Le Bristol'");

            var orderedJournals = from journal in journals 
                orderby journal.Circulation descending 
                select journal;
            var bestAndWorstJournal = new List<Journal>{orderedJournals.First(), orderedJournals.Last()};
            
            PrintObject(bestAndWorstJournal, "Journal with the biggest circulation, and the smallest");
            
            var articleTitles = from article in articles
                where article.Authors.Any(a => a.Work.Name == "Pine Cliffs")
                select article;
            
            PrintObject(articleTitles, "Articles written by authors who are working at Pine Cliffs");
            
            var journalsSortedByDate = journals
                .Where(j => j.Name.Contains("Nature"))
                .OrderByDescending(j => j.IssueDate);
            
            PrintObject(journalsSortedByDate, "Journals, that contain word 'Nature' in name, sorted by issue date");
            
            var authorInOrganisations = articles
                .Where(a => a.Journal.Name == "New England Journal of Medicine")
                .SelectMany(a => a.Authors)
                .Distinct()
                .Select(a => a.Work)
                .Distinct();

            PrintObject(authorInOrganisations, "Organisations, where author in 'New England Journal of Medicine' worked");
            
            var articlesInRange = articles
                .Where(a => a.PublicationDate.Year >= 2012 && a.PublicationDate.Year <= 2014)
                .OrderBy(a => a.PublicationDate);
            
            PrintObject(articlesInRange, "Articles published between 2012 and 2014");

            var articlesAndOrganisations = from article in articles
                select (article.Name, article.Authors[0].Work.Name);
            
            PrintObject(articlesAndOrganisations, "Articles, and organisation, that published them");

            var journalsFromSameOrganisation = (from article in articles
                where article.Authors.Select(author => author.Work).Distinct().Count() == 1
                select article.Journal).Distinct();
            
            PrintObject(journalsFromSameOrganisation, "Journals with authors from the same organisations");
            
            var articlesWithLargestCirculation = articles
                .Where(a => a.Journal.Circulation == journals.Max(j => j.Circulation))
                .OrderBy(a => a.PublicationDate);
            
            PrintObject(articlesWithLargestCirculation, "Articles that were published on a journal with largest circulation");
            
            var mostEffectiveAuthors = (from author in authors
                where author.Work.EmployeesNumber < 100
                join article in articles on author equals article.Authors[0]
                where article.Journal.Circulation > 4500
                select author).Distinct();
            
            PrintObject(mostEffectiveAuthors, "Authors who work at companies with less than 100 employees, but have journal circularion over 4500");
        }

        static void PrintObject<T>(IEnumerable<T> objects, string descripion)
        {
            Console.WriteLine($"{descripion}:");
            foreach (var obj in objects)
            {
                Console.WriteLine($"{obj};");
            }
            Console.WriteLine("\n");
        }
    }
}