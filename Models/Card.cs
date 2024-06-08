using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Card
    {
        [Key]
        public string CardNumber { get; set; }
        public string SecurityCold { get; set; }
        public string DueDate { get; set; }
        public string CardName { get; set; }
    }
}
