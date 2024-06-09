using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class CarService
    {
        public readonly string Select =
            " select ([Id], [CarPlate], [ServiceId]) from CarService ";

        public readonly string SelectById =
            " select ([Id], [CarPlate], [ServiceId]) from CarService where [Id] = @Id";

        public readonly string InsertOne =
            " insert into CarService values([Id], [CarPlate], [ServiceId]) ";

        public readonly string UpdateById =
            " update CarService set [@Field] = @Value where [Id] = @Id ";

        public readonly string DeleteById =
            " delete from CarService where [Id] = @Id ";
        
        [Key]
        public int Id { get; set; }
        public Car Car { get; set; }
        public Service Service { get; set; }
    }
}
