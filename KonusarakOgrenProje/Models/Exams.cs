using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KonusarakOgrenProje.Models
{
    public class Exams
    {
        [System.ComponentModel.DataAnnotations.Key]
        public int ExamId { get; set; }
        public string ExamName { get; set; }
        public string Description { get; set; }
        public DateTime? CreateDate { get; set; }
    }
}
