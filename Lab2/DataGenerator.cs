using System;
using System.Collections.Generic;

namespace Lab2
{
    public static class DataGenerator
    {
        public static List<Organisation> GenerateOrganisations()
        {
            Random random = new Random();
            List<Organisation> organisations = new List<Organisation>
            {
                new Organisation("Paphos", random.Next(5, 150)),
                new Organisation("The Idle Rocks", random.Next(5, 150)),
                new Organisation("Le Bristol", random.Next(5, 150)),
                new Organisation("Herbert Samuel", random.Next(5, 150)),
                new Organisation("Waldorf Astoria", random.Next(5, 150)),
                new Organisation("Matild Palace", random.Next(5, 150)),
                new Organisation("Four Seasons", random.Next(5, 150)),
                new Organisation("Gleneagles", random.Next(5, 150)),
                new Organisation("Hotel Balkan", random.Next(5, 150)),
                new Organisation("Pine Cliffs", random.Next(5, 150)),
                new Organisation("Anassa", random.Next(5, 150)),
                new Organisation("Conrad Bosphorus", random.Next(5, 150))
            };
            return organisations;
        }

        public static List<Journal> GenerateJournals()
        {
            Random random = new Random();
            List<Journal> journals = new List<Journal>
            {
                new Journal("Cancer Clinicians", random.Next(4, 14),
                    new DateOnly(random.Next(2000, 2015), random.Next(1, 12), random.Next(1, 25)),
                    random.Next(5, 100) * 100),
                new Journal("Molecular Cell Biology", random.Next(4, 14),
                    new DateOnly(random.Next(2000, 2015), random.Next(1, 12), random.Next(1, 25)),
                    random.Next(5, 100) * 100),
                new Journal("Quarterly Economics", random.Next(4, 14),
                    new DateOnly(random.Next(2000, 2015), random.Next(1, 12), random.Next(1, 25)),
                    random.Next(5, 100) * 100),
                new Journal("Cell", random.Next(4, 14),
                    new DateOnly(random.Next(2000, 2015), random.Next(1, 12), random.Next(1, 25)),
                    random.Next(5, 100) * 100),
                new Journal("MMWR Reports", random.Next(4, 14),
                    new DateOnly(random.Next(2000, 2015), random.Next(1, 12), random.Next(1, 25)),
                    random.Next(5, 100) * 100),
                new Journal("New England Medicine", random.Next(4, 14),
                    new DateOnly(random.Next(2000, 2015), random.Next(1, 12), random.Next(1, 25)),
                    random.Next(5, 100) * 100),
                new Journal("Nature Medicine", random.Next(4, 14),
                    new DateOnly(random.Next(2000, 2015), random.Next(1, 12), random.Next(1, 25)),
                    random.Next(5, 100) * 100),
                new Journal("Nature Reviews Materials", random.Next(4, 14),
                    new DateOnly(random.Next(2000, 2015), random.Next(1, 12), random.Next(1, 25)),
                    random.Next(5, 100) * 100),
                new Journal("Computer Vision Proceedings", random.Next(4, 14),
                    new DateOnly(random.Next(2000, 2015), random.Next(1, 12), random.Next(1, 25)),
                    random.Next(5, 100) * 100),
                new Journal("Nature Reviews Genetics", random.Next(4, 14),
                    new DateOnly(random.Next(2000, 2015), random.Next(1, 12), random.Next(1, 25)),
                    random.Next(5, 100) * 100)
            };
            return journals;
        }

        public static List<Author> GenerateAuthors(List<Organisation> organisations)
        {
            List<Author> authors = new List<Author>();
            string[,] names =
            {
                {"Smith", "James", "Richard"},
                {"Johnson", "Mary", "Susan"},
                {"Williams", "John", "Joseph"},
                {"Brown", "Jennifer", "Jessica"},
                {"Jones", "Michael", "Thomas"},
                {"Garcia", "Linda", "Sarah"},
                {"Miller", "David", "Charles"},
                {"Davis", "Elizabeth", "Karen"},
                {"Rodriguez", "William", "Christopher"},
                {"Martinez", "Barbara", "Nancy"},
                {"Jackson", "Matthew", "Paul"},
                {"Martin", "Betty", "Emily"},
                {"Lee", "Anthony", "Andrew"},
                {"Perez", "Margaret", "Donna"},
                {"Thompson", "Mark", "Joshua"},
                {"White", "Sandra", "Michelle"},
                {"Harris", "Donald", "Kenneth"},
                {"Sanchez", "Ashley", "Carol"},
                {"Clark", "Steven", "Kevin"},
                {"Ramirez", "Kimberly", "Amanda"}
            };

            Random random = new Random();

            for (int i = 0; i < 20; i++)
            {
                authors.Add(new Author(names[i, 0], names[i, 1], names[i, 2],
                    organisations[random.Next(organisations.Count)]));
            }

            return authors;
        }

        public static List<Article> GenerateArticles(List<Journal> journals, List<Author> authors)
        {
            Random random = new Random();
            List<Article> articles = new List<Article>
            {
                new Article("Quantum Computing: A Beginner's Guide", journals[random.Next(journals.Count)],
                    new DateOnly(random.Next(2000, 2015), random.Next(1, 12), random.Next(1, 25)),
                    authors[random.Next(authors.Count)]),
                new Article("The Neuroscience of Consciousness", journals[random.Next(journals.Count)],
                    new DateOnly(random.Next(2000, 2015), random.Next(1, 12), random.Next(1, 25)),
                    authors[random.Next(authors.Count)]),
                new Article("The Evolution of Flight in Birds", journals[random.Next(journals.Count)],
                    new DateOnly(random.Next(2000, 2015), random.Next(1, 12), random.Next(1, 25)),
                    authors[random.Next(authors.Count)]),
                new Article("The Future of Space Exploration", journals[random.Next(journals.Count)],
                    new DateOnly(random.Next(2000, 2015), random.Next(1, 12), random.Next(1, 25)),
                    authors[random.Next(authors.Count)]),
                new Article("Artificial Intelligence and Ethics", journals[random.Next(journals.Count)],
                    new DateOnly(random.Next(2000, 2015), random.Next(1, 12), random.Next(1, 25)),
                    authors[random.Next(authors.Count)]),
                new Article("The Role of Microbes in Human Health", journals[random.Next(journals.Count)],
                    new DateOnly(random.Next(2000, 2015), random.Next(1, 12), random.Next(1, 25)),
                    authors[random.Next(authors.Count)]),
                new Article("Understanding Dark Matter", journals[random.Next(journals.Count)],
                    new DateOnly(random.Next(2000, 2015), random.Next(1, 12), random.Next(1, 25)),
                    authors[random.Next(authors.Count)]),
                new Article("The Physics of Time Travel", journals[random.Next(journals.Count)],
                    new DateOnly(random.Next(2000, 2015), random.Next(1, 12), random.Next(1, 25)),
                    authors[random.Next(authors.Count)]),
                new Article("The Human Genome Project: A Decade of Discoveries", journals[random.Next(journals.Count)],
                    new DateOnly(random.Next(2000, 2015), random.Next(1, 12), random.Next(1, 25)),
                    authors[random.Next(authors.Count)]),
                new Article("Renewable Energy Sources: Advancements and Challenges",
                    journals[random.Next(journals.Count)],
                    new DateOnly(random.Next(2000, 2015), random.Next(1, 12), random.Next(1, 25)),
                    authors[random.Next(authors.Count)]),
                new Article("Exploring the Deep Sea: New Discoveries and Technologies",
                    journals[random.Next(journals.Count)],
                    new DateOnly(random.Next(2000, 2015), random.Next(1, 12), random.Next(1, 25)),
                    authors[random.Next(authors.Count)]),
                new Article("The Psychology of Decision Making", journals[random.Next(journals.Count)],
                    new DateOnly(random.Next(2000, 2015), random.Next(1, 12), random.Next(1, 25)),
                    authors[random.Next(authors.Count)]),
                new Article("Climate Change: Causes, Impacts, Strategies", journals[random.Next(journals.Count)],
                    new DateOnly(random.Next(2000, 2015), random.Next(1, 12), random.Next(1, 25)),
                    authors[random.Next(authors.Count)]),
                new Article("Genetically Modified Organisms: Benefits and Concerns",
                    journals[random.Next(journals.Count)],
                    new DateOnly(random.Next(2000, 2015), random.Next(1, 12), random.Next(1, 25)),
                    authors[random.Next(authors.Count)]),
                new Article("Advancements in Nanotechnology", journals[random.Next(journals.Count)],
                    new DateOnly(random.Next(2000, 2015), random.Next(1, 12), random.Next(1, 25)),
                    authors[random.Next(authors.Count)]),
                new Article("The Science of Sleep: Mechanisms and Functions", journals[random.Next(journals.Count)],
                    new DateOnly(random.Next(2000, 2015), random.Next(1, 12), random.Next(1, 25)),
                    authors[random.Next(authors.Count)]),
                new Article("Ocean Acidification: Effects on Marine Ecosystems", journals[random.Next(journals.Count)],
                    new DateOnly(random.Next(2000, 2015), random.Next(1, 12), random.Next(1, 25)),
                    authors[random.Next(authors.Count)]),
                new Article("Black Holes: Unveiling the Mysteries of the Universe",
                    journals[random.Next(journals.Count)],
                    new DateOnly(random.Next(2000, 2015), random.Next(1, 12), random.Next(1, 25)),
                    authors[random.Next(authors.Count)]),
                new Article("The History of Human Evolution", journals[random.Next(journals.Count)],
                    new DateOnly(random.Next(2000, 2015), random.Next(1, 12), random.Next(1, 25)),
                    authors[random.Next(authors.Count)]),
                new Article("Understanding Autism: Behavioral Perspectives", journals[random.Next(journals.Count)],
                    new DateOnly(random.Next(2000, 2015), random.Next(1, 12), random.Next(1, 25)),
                    authors[random.Next(authors.Count)]),
                new Article("The Promise of Stem Cell Therapy", journals[random.Next(journals.Count)],
                    new DateOnly(random.Next(2000, 2015), random.Next(1, 12), random.Next(1, 25)),
                    authors[random.Next(authors.Count)]),
                new Article("Quantum Mechanics: The Fundamentals", journals[random.Next(journals.Count)],
                    new DateOnly(random.Next(2000, 2015), random.Next(1, 12), random.Next(1, 25)),
                    authors[random.Next(authors.Count)]),
                new Article("Exploring the Human Microbiome", journals[random.Next(journals.Count)],
                    new DateOnly(random.Next(2000, 2015), random.Next(1, 12), random.Next(1, 25)),
                    authors[random.Next(authors.Count)]),
                new Article("The Origins of the Universe", journals[random.Next(journals.Count)],
                    new DateOnly(random.Next(2000, 2015), random.Next(1, 12), random.Next(1, 25)),
                    authors[random.Next(authors.Count)]),
                new Article("The Science of Addiction: Mechanisms and Treatment", journals[random.Next(journals.Count)],
                    new DateOnly(random.Next(2000, 2015), random.Next(1, 12), random.Next(1, 25)),
                    authors[random.Next(authors.Count)])
            };

            return articles;
        }
    }
}