#region Usings

using Api.BackendChallenge.Ecommerce.Data;
using Api.BackendChallenge.Ecommerce.gRPCService;
using Api.BackendChallenge.Ecommerce.Services.BlackFriday;
using Api.BackendChallenge.Ecommerce.ViewModels.Requests;
using Api.BackendChallenge.Ecommerce.ViewModels.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

#endregion

namespace Api.BackendChallenge.Ecommerce.Controllers
{
    [ApiController]
    [Route("api/backendChallenge/eCommerce")]
    public class ECommerceController : ControllerBase
    {
        private readonly ILogger<ECommerceController> _logger;
        private List<ProductObject> productsRegister;
        private IConfiguration configuration;

        public ECommerceController(ILogger<ECommerceController> logger, IConfiguration configuration)
        {
            _logger = logger;
            this.configuration = configuration;

            productsRegister = new DataProductsService().Get();
        }

        /// <summary>
        /// Inclusão de produtos e seus respectivos descontos ao carrinho
        /// </summary>
        /// <param name="productsRequest">Parametro deve respeitar a estrutura de exemplo: 
        /// {
        ///     "products": [
        ///         {
        ///             "id": 1,
        ///             "quantity": 1 // Quantidade a ser comprada do produto
        ///         }
        ///     ]
        /// }
        ///</param>
        /// <returns></returns>
        [HttpPost]
        [Route("carrinho")]
        public async Task<JsonResult> Add([FromBody] Object productsRequest)
        {
            CartResponse cartResponse = new CartResponse();

            try
            {

                #region Laço para montagem do carrinho e seus respectivos descontos
                
                foreach (var productRequest in JsonConvert.DeserializeObject<ProductsRequest>(productsRequest.ToString()).products)
                {
                    ProductResponse productResponse = new ProductResponse();

                    // Busca produto na lista de produtos em memória
                    ProductObject productRegister = productsRegister.Where(p => p.id == productRequest.id).FirstOrDefault();

                    // Busca desconto do produto
                    float discount = new DiscountService(configuration).getDiscountByIdProduct(productRequest.id);
                    
                    // Calcula totais do carrinho
                    cartResponse.total_amount += productRegister.amount * productRequest.quantity;

                    // Somente aplica desconto concedidos acima de 0
                    if (discount != 0)
                    {
                        cartResponse.total_amount_with_discount += productRegister.amount * productRequest.quantity * (discount / 100);
                        cartResponse.total_discount += discount;
                    }

                    // Atribuições do produto
                    productResponse.id = productRequest.id;
                    productResponse.unit_amount = productRegister.amount;
                    productResponse.discount = discount != 0 ? discount : 0;
                    productResponse.quantity = productRequest.quantity;
                    productResponse.total_amount = productRegister.amount * productRequest.quantity;

                    // Adiciona produto ao carrinho
                    cartResponse.products.Add(productResponse);
                }

                #endregion

                #region Se for o dia de black friday adiciona um produto de brinde no carrinho

                if (new BlackFridayService(configuration).IsDayBlackFriday())
                {
                    ProductObject productGift =  productsRegister.Where(p => p.is_gift == true).FirstOrDefault();

                    cartResponse.products.Add(new ProductResponse()
                    {
                        id = productGift.id,
                        discount = 0,
                        is_gift = productGift.is_gift,
                        quantity = 1,
                        unit_amount = productGift.amount,
                        total_amount = productGift.amount
                    });
                }
                #endregion 

                return new JsonResult(cartResponse);
            }
            catch (Exception exc)
            {
                throw;
            }
        }
    }
}
