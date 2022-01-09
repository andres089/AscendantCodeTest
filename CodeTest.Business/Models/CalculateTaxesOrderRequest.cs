using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeTest.Business.Entities
{
    public class CalculateTaxesOrderRequest
    {
        public string from_country { get; set; }
        public string from_zip { get; set; }
        public string from_state { get; set; }

        public string from_city { get; set; }

        public string from_street { get; set; }

        public string to_country { get; set; }

        public string to_zip { get; set; }

        public string to_state { get; set; }

        public string to_city { get; set; }

        public string to_street { get; set; }

        public int amount { get; set; }

        public decimal shipping { get; set;}

        public IEnumerable<nexus_addresses> nexus_addresses { get; set; }
  
        public IEnumerable<line_items> line_Items { get; set; }

    }

    public class nexus_addresses
    {
       public string id { get; set; }
       public string country { get; set; }
        public string zip { get; set; }

        public string state { get; set; }

        public string  city { get; set; }

        public string street { get; set; }
    }

    public class line_items
    {
        public string id { get; set; }
        public int quantity { get; set; }
        public string product_tax_code { get; set; }
        public int unit_price { get; set; }
        public int discount { get; set; }
    }

}

