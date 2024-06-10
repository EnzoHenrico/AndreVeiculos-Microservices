using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Boleto
    {
        public readonly string Select =
            " select ([Id], [Number], [DueDate]) from Boleto ";

        public readonly string SelectById =
            " select ([Id], [Number], [DueDate]) from Boleto where [Id] = @Id";

        public readonly string InsertOne =
            " insert into Boleto values([Id], [Number], [DueDate]) ";

        public readonly string UpdateById =
            " update Boleto set [Id] = @Id, [Number] = @Number, [DueDate] = @DueDate where [Id] = @Id ";

        public readonly string DeleteById =
            " delete from Boleto where [Id] = @Id ";
        
        public int Id { get; set; }
        public int Number { get; set; }
        public DateOnly DueDate { get; set; }
    }
}
