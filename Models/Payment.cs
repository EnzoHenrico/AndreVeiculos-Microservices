using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Payment
    {
        public readonly string Select =
            " select ([id], [CardNumber], [BoletoId], [PixId], [PaymentDate]) from Payment ";

        public readonly string SelectById =
            " select ([id], [CardNumber], [BoletoId], [PixId], [PaymentDate]) from Payment where [id] = @id";

        public readonly string InsertOne =
            " insert into Payment values([id], [CardNumber], [BoletoId], [PixId], [PaymentDate]) ";

        public readonly string UpdateById =
            " update Payment set [@Field] = @Value where [id] = @id ";

        public readonly string DeleteById =
            " delete from Payment where [id] = @id ";
        public int Id { get; set; }
        public Card Card { get; set; }
        public Boleto Boleto { get; set; }
        public Pix Pix { get; set; }
        public DateTime PaymentDate { get; set; }
    }
}
