using System;

namespace exam_azure.DTOs
{
	public class OrderDTO
	{
        public int Id { get; set; }

        public string ItemCode { get; set; }

        public string ItemName { get; set; }

        public int ItemQty { get; set; }

        public DateTime OrderDelivery { get; set; }

        public string OrderAddress { get; set; }

        public string PhoneNumber { get; set; }
        // NgoManhSon
    }
}

