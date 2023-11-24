using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace exam_azure.Entities
{
    [Table("OrderTbl")]
	public class Order
	{
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string ItemCode { get; set; }

        [Required]
        [StringLength(255)]
        public string ItemName { get; set; }

        [Required]
        public int ItemQty { get; set; }

        [Required]
        public DateTime OrderDelivery { get; set; }

        [Required]
        public string OrderAddress { get; set; }

        [Required]
        public string PhoneNumber { get; set; }
        // NgoManhSon
    }
}

