using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Position
    {
        public readonly string Select =
            " select ([id], [Description]) from Position ";

        public readonly string SelectById =
            " select ([id], [Description]) from Position where [id] = @id";

        public readonly string InsertOne =
            " insert into Position values([id], [Description]) ";

        public readonly string UpdateById =
            " update Position set [Description] = @Description where [id] = @id ";

        public readonly string DeleteById =
            " delete from Position where [id] = @id ";
        
        public int Id { get; set; }
        public string Description { get; set; }
    }
}
