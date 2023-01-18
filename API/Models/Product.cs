using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Web;

namespace API.Models
{
    public class Product
    {
        public DateTime CreatedAt { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public string brand { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int Id { get; set; }
    }
}