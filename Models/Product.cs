using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CsvWebParser.Models
{
    // Model for the database tables
    [Table("tblProduct")]   // Specifies DB table that a class is mapped to
    public class Product
    {
        [Key]   // Specifies the Column AsIdn to be Primary Key
        [MaxLength(20)]
        public string AsIdn { get; set; }
        [MaxLength(100)]
        public string Title { get; set; }
        public decimal Price { get; set; }
        public double NetMargin { get; set; }
    }
}