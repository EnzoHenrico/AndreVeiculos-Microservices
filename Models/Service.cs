using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Service
    {
        public readonly string Select =
            " select ([id], [Description]) from Service ";

        public readonly string SelectById =
            " select ([id], [Description]) from Service where [id] = @id";

        public readonly string InsertOne =
            " insert into Service values([id], [Description]) ";

        public readonly string UpdateById =
            " update Service set [@Field] = @Value where [id] = @id ";

        public readonly string DeleteById =
            " delete from Service where [id] = @id ";
        
        public int Id { get; set; }
        public string Description { get; set; }
    }
}
