using System;

namespace Lab1
{
    public class Journal
    {
        public string Name { get; set; }
        public int IssuePeriodDays { get; set; }
        public DateOnly IssueDate { get; set; }
        public int Circulation { get; set; }

        public Journal(string name, int issuePeriodDays, DateOnly issueDate, int circulation)
        {
            Name = name;
            IssuePeriodDays = issuePeriodDays;
            IssueDate = issueDate;
            Circulation = circulation;
        }

        public override string ToString()
        {
            return $"Title: {Name}; Issue Period: every {IssuePeriodDays} days; Issue Date: {IssueDate}; Circulation: {Circulation}";
        }
    }
}