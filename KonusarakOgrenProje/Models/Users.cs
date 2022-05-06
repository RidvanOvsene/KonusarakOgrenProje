using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KonusarakOgrenProje.Models
{
    public class Users
    {
        [System.ComponentModel.DataAnnotations.Key]
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

    }
}
