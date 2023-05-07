using System;
using System.Collections.Generic;
using System.Text;

namespace Millenium
{
    internal class ExamResult
    {
        public string ClassId {get;set;}
        public string StudentId { get; set; }
        public Decimal Grade { get; set; }
        public DateTime ExamDate { get; set; }
    }
}
