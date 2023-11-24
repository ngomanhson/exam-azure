using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace exam_azure.model
{
	public class CreateOrder
	{

        [Required]
        [MinLength(6, ErrorMessage = "Enter at least 6 characters")]
        [MaxLength(20, ErrorMessage = "Enter up to 20 characters")]
        public string ItemCode { get; set; }

        [Required(ErrorMessage = "Please enter name")]
        [MinLength(3, ErrorMessage = "Enter at least 3 characters")]
        [MaxLength(255, ErrorMessage = "Enter up to 255 characters")]
        public string ItemName { get; set; }

        [Required(ErrorMessage = "Please enter qty")]
        public int ItemQty { get; set; }

        [Required(ErrorMessage = "Please enter order delivery")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime OrderDelivery { get; set; }

        [Required(ErrorMessage = "Please enter order address")]
        public string OrderAddress { get; set; }

        [Required(ErrorMessage = "Please enter order phone")]
        [MinLength(10, ErrorMessage = "Enter at least 10 characters")]
        [MaxLength(20, ErrorMessage = "Enter up to 20 characters")]
        public string PhoneNumber { get; set; }
        // NgoManhSon
    }
}

