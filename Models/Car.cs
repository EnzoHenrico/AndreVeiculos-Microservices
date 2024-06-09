using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Car
    {
        public readonly string Select =
            " select ([Plate], [Name], [YearModel], [YearProduction], [Color], [Sold]) from Car ";

        public readonly string SelectById =
            " select ([Plate], [Name], [YearModel], [YearProduction], [Color], [Sold]) from Car where [Plate] = @Plate";

        public readonly string InsertOne =
            " insert into Car values([Plate], [Name], [YearModel], [YearProduction], [Color], [Sold]) ";

        public readonly string UpdateById =
            " update Car set [@Field] = @Value where [Plate] = @Plate ";

        public readonly string DeleteById =
            " delete from Car where [Plate] = @Plate ";
        
        [Key]
        public string Plate { get; set; }
        public string Name { get; set; }
        public int YearModel { get; set; }
        public int YearProduction { get; set; }
        public string Color { get; set; }
        public bool Sold { get; set; }
    }
}
