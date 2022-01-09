using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OT.Models
{
    public class questionsModel
    {
        public int id { get; set; }
        public string Question { get; set; }
        public string Ans1 { get; set; }
        public string Ans2 { get; set; }
        public string Ans3 { get; set; }

        public string Ans4 { get; set; }
        public string CorrectAns { get; set; }
    }
}
