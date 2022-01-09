using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeTest.Business.Entities
{
    public class CalculateTaxesOrderResponse
    {
        public string Message { get; set; }

        public tax tax { get; set; }

    }

    public class tax
    {
        public decimal amount_to_collect { get; set; }

        public bool freight_taxable { get; set; }

        public bool has_nexus { get; set; }

        public jurisdictions jurisdictions { get; set; }

        public decimal order_total_amount { get; set; }

        public decimal rate { get; set; }

        public decimal shipping { get; set; }

        public string tax_source { get; set; }

        public decimal taxable_amount { get; set; }


    }

    public class jurisdictions
    {
        public string city { get; set; }
        public string country { get; set; }

        public string county { get; set; }

        public string state { get; set; }

    }

}

