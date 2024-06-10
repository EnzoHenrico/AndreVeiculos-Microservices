using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Purchase
    {
        public readonly string Select =
            " select ([id], [CarPlate], [Price], [PurchaseDate]) from Purchase ";

        public readonly string SelectById =
            " select ([id], [CarPlate], [Price], [PurchaseDate]) from Purchase where [id] = @id";

        public readonly string InsertOne =
            " insert into Purchase values([id], [CarPlate], [Price], [PurchaseDate]) ";

        public readonly string UpdateById =
            " update Purchase set [CarPlate] = @CarPlate, [Price] = @Price, [PurchaseDate] = @PurchaseDate where [id] = @id ";

        public readonly string DeleteById =
            " delete from Purchase where [id] = @id ";
        
        public int Id { get; set; }
        public Car Car { get; set; }
        public Decimal Price { get; set; }
        public DateTime PurchaseDate { get; set; }
    }
}