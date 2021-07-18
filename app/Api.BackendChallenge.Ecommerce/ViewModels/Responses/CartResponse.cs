using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.BackendChallenge.Ecommerce.ViewModels.Responses
{
    /// <summary>
    /// View Model Cart
    /// </summary>
    public class CartResponse
    {
        public CartResponse()
        {
            this.products = new List<ProductResponse>();
        }

        public float total_amount { get; set; }
        public float total_amount_with_discount { get; set; }
        public float total_discount { get; set; }
        public List<ProductResponse> products { get; set; }
    }
}
