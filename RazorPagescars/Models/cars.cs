using System.ComponentModel.DataAnnotations;

namespace RazorPagescars.Models
{
    public class cars
    {
        public int ID { get; set; }
        public string Name { get; set; } = string.Empty;

        [DataType(DataType.Date)]
        public DateTime BuyingDate { get; set; }
        public string Type { get; set; } = string.Empty;
        public decimal Price { get; set; }
    }
}