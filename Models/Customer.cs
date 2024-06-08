using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Customer : Person
    {
        public Decimal Income { get; set; }
        public string PDFDocument { get; set; }
    }
}
