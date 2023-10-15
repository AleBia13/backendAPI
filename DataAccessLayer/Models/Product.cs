using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public int ProductQuantity { get; set; }
        public long ProductGUID { get; set; }
        public string ProductImage { get; set; }

    }
}
