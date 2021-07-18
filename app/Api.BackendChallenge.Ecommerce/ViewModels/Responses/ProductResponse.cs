using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.BackendChallenge.Ecommerce.ViewModels.Responses
{
    public class ProductResponse
    {
        public Int32 id { get; set; }
        public float quantity { get; set; }
        public float unit_amount { get; set; }
        public float total_amount { get; set; }
        public float discount { get; set; }
        public Boolean is_gift { get; set; }
    }
}
