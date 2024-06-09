using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Pix
    {
        public readonly string Select =
            " select ([id], [TypeId], [PixKey]) from Pix ";

        public readonly string SelectById =
            " select ([id], [TypeId], [PixKey]) from Pix where [id] = @id";

        public readonly string InsertOne =
            " insert into Pix values([id], [TypeId], [PixKey]) ";

        public readonly string UpdateById =
            " update Pix set [@Field] = @Value where [id] = @id ";

        public readonly string DeleteById =
            " delete from Pix where [id] = @id ";
        
        public int Id { get; set; }
        public PixType Type { get; set; }
        public string PixKey { get; set; }
    }
}
