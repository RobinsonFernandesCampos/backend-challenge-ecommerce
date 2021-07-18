using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.BackendChallenge.Ecommerce.Data
{
    public class ProductObject
    {
        public Int32 id { get; set; }
        public String title { get; set; }
        public String description { get; set; }
        public float amount { get; set; }
        public Boolean is_gift { get; set; }

    }
}
