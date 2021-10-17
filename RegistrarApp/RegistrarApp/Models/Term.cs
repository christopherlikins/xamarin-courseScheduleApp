using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace RegistrarApp.Models
{
    public class Term
    {
        [PrimaryKey, AutoIncrement]
        public int TermID { get; set; }
        [Indexed]
        public string TermName { get; set; }
        public DateTime TermStart { get; set; }
        public DateTime TermEnd { get; set; }
        public bool TermStartToday { get; set; }
        public bool TermEndToday { get; set; }
        public Term (int termId, string termName, DateTime termStart, DateTime termEnd, bool termStartToday, bool termEndToday)
        {
            TermID = termId;
            TermName = termName;
            TermStart = termStart;
            TermEnd = termEnd;
            TermStartToday = termStartToday;
            TermEndToday = termEndToday;

        }
        public Term ()
        {

        }
    }
}
