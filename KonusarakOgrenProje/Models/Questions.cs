using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KonusarakOgrenProje.Models
{
    public class Questions
    {
        [System.ComponentModel.DataAnnotations.Key]
        public int QuestionId { get; set; }
        public int? ExamId { get; set; }
        public string Question { get; set; }
        public string ChoiceA { get; set; }
        public string ChoiceB { get; set; }
        public string ChoiceC { get; set; }
        public string ChoiceD { get; set; }
        public string Reply { get; set; }
        public string Answer { get; set; }
    }
}
