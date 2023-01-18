using System;


namespace API.Models
{
    public class ProductDTO
    {
        public DateTime CreatedAt { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Brand { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int ID { get; set; }
    }
}