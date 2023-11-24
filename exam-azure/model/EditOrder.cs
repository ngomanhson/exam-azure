using System;
using System.ComponentModel.DataAnnotations;

namespace exam_azure.model
{
	public class EditOrder
	{
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter order delivery")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime OrderDelivery { get; set; }

        [Required(ErrorMessage = "Please enter order address")]
        public string OrderAddress { get; set; }
        // NgoManhSon
    }
}

