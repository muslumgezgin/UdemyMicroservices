﻿using System;
using FreeCourse.Web.Models.Orders;

namespace FreeCourse.Web.Models.FakePayments
{
	public class PaymentInfoInput
	{
        public string CardName { get; set; }
        public string CardNumber { get; set; }
        public string Expiration { get; set; }
        public string CVC { get; set; }
        public decimal TotalPrice { get; set; }
        public OrderCreateInput Order { get; set; }

    }
}

