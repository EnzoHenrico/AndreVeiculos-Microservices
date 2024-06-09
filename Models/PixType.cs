using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class PixType
    {
        public readonly string Select =
            " select ([id], [Name]) from PixType ";

        public readonly string SelectById =
            " select ([id], [Name]) from PixType where [id] = @id";

        public readonly string InsertOne =
            " insert into PixType values([id], [Name]) ";

        public readonly string UpdateById =
            " update PixType set [@Field] = @Value where [id] = @id ";

        public readonly string DeleteById =
            " delete from PixType where [id] = @id ";
        
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
