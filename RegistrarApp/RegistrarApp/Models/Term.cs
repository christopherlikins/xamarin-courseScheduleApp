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
        public Term (int termId, string termName, DateTime termStart, DateTime termEnd)
        {
            TermID = termId;
            TermName = termName;
            TermStart = termStart;
            TermEnd = termEnd;
        }
        public Term ()
        {

        }
    }
}
