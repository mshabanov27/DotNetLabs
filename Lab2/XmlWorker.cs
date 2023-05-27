using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;

namespace Lab2
{
    public static class XmlWorker
    {
        public static void WriteXmlFile(List<Article> articles)
        {
            var settings = new XmlWriterSettings {Indent = true};

            using (XmlWriter writer = XmlWriter.Create("articles.xml", settings))
            {
                writer.WriteStartElement("articles");
                _writeArticles(writer, articles);
                writer.WriteEndElement();
                
                writer.Flush();
            }
        }
        
        public static bool ValidateArticles(string schemaName, XDocument doc)
        {
            XmlSchemaSet schemas = new XmlSchemaSet();
            schemas.Add("", "articlesSchema.xsd");
            
            bool errors = false;
            doc.Validate(schemas, (o, e) => errors = true);
            return errors;
        }

        public static void PrintXmlArcticles(XmlDocument doc)
        {
            foreach (XmlNode node in doc.DocumentElement)
            {
                string name = node["name"].InnerText;
                string authors = _concatAuthors(node["authors"]);
                string journal = node["journal"]["name"].InnerText;
                string publicationDate = node["publicationDate"].InnerText;
                Console.WriteLine($"Name: {name}; ".PadRight(70) +
                                  $"Authors: {authors}".PadRight(30) +
                                  $"Journal: {journal}; ".PadRight(45) +
                                  $"Date: {publicationDate};");
            }
            Console.WriteLine();
        }
        
        private static void _writeArticles(XmlWriter writer, List<Article> articles)
        {
            foreach (var article in articles)
            {
                writer.WriteStartElement("article");
                writer.WriteElementString("name", article.Name);

                writer.WriteStartElement("authors");
                _writeAuthor(writer, article);
                    
                writer.WriteEndElement();

                _writeJournal(writer, article);

                writer.WriteElementString("publicationDate", article.PublicationDate.ToString());

                writer.WriteEndElement();
            }
        }

        private static void _writeAuthor(XmlWriter writer, Article article)
        {
            foreach (var author in article.Authors)
            {
                writer.WriteStartElement("author");

                writer.WriteElementString("surname", author.Surname);

                writer.WriteElementString("name", author.Name);
                writer.WriteElementString("secondName", author.SecondName);

                writer.WriteStartElement("organisation");
                writer.WriteElementString("name", author.Work.Name);
                writer.WriteElementString("employeesNumber", author.Work.EmployeesNumber.ToString());
                writer.WriteEndElement();

                writer.WriteEndElement();
            }
        }
        
        
        private static void _writeJournal(XmlWriter writer, Article article)
        {
            writer.WriteStartElement("journal");
            writer.WriteElementString("name", article.Journal.Name);
            writer.WriteElementString("issuePeriodDays", article.Journal.IssuePeriodDays.ToString());
            writer.WriteElementString("issueDate", article.Journal.IssueDate.ToString());
            writer.WriteElementString("circulation", article.Journal.Circulation.ToString());
            writer.WriteEndElement();
        }

        private static string _concatAuthors(XmlNode parentNode)
        {
            string authors = "";
            foreach (XmlNode node in parentNode)
            {
                authors += $"{node["name"].InnerText} {node["surname"].InnerText}, ";
            }

            return authors;
        }
    }
}