using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Payment
    {
        public int Id { get; set; }
        public Card Card { get; set; }
        public Boleto Boleto { get; set; }
        public Pix Pix { get; set; }
        public DateTime PaymentDate { get; set; }
    }
}
