using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Product    {
        public int id { get; set; }
        [Required]
        public string productname { get; set; }
        public int QtyInStock { get; set; }
        public string description { get; set; }
    }
}