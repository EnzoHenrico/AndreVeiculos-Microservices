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
        public readonly string Select =
            " select ([CardNumber], [SecurityCold], [DueDate], [CardName]) from Card ";

        public readonly string SelectById =
            " select ([CardNumber], [SecurityCold], [DueDate], [CardName]) from Card where [CardNumber] = @CardNumber";

        public readonly string InsertOne =
            " insert into Card values([CardNumber], [SecurityCold], [DueDate], [CardName]) ";

        public readonly string UpdateById =
            " update Card set [@Field] = @Value where [CardNumber] = @CardNumber ";

        public readonly string DeleteById =
            " delete from Card where [CardNumber] = @CardNumber ";

        [Key]
        public string CardNumber { get; set; }
        public string SecurityCold { get; set; }
        public string DueDate { get; set; }
        public string CardName { get; set; }
    }
}
