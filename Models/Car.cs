using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Car
    {
        [Key]
        public string Plate { get; set; }
        public string Name { get; set; }
        public int YearModel { get; set; }
        public int YearProduction { get; set; }
        public string Color { get; set; }
        public bool Sold { get; set; }
    }
}
