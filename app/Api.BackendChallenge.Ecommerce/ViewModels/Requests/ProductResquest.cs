using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.BackendChallenge.Ecommerce.ViewModels.Requests
{
    public class ProductsRequest
    {
        public List<ProductRequest> products { get; set; }
    }

    public class ProductRequest
    {
        public Int32 id { get; set; }
        public float quantity { get; set; }
    }
}
