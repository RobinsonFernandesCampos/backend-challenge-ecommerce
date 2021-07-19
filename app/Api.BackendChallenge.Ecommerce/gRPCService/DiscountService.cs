using Grpc.Net.Client;
using Discount;
using System;
using static Discount.Discount;
using Microsoft.Extensions.Configuration;

namespace Api.BackendChallenge.Ecommerce.gRPCService
{
    public class DiscountService
    {
        private IConfiguration configuration;

        public DiscountService(IConfiguration configuration)
        {
            AppContext.SetSwitch("System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true);
            this.configuration = configuration;
        }

        /// <summary>
        /// Busca desconto para o produto
        /// </summary>
        /// <param name="idProduct">Id do produto para busca do desconto</param>
        /// <returns></returns>
        public float getDiscountByIdProduct(Int32 productId)
        {
            try
            {
                GrpcChannel channel = GrpcChannel.ForAddress(new Uri(configuration[Constantes.URL_GRPC_DISCOUNT]));

                DiscountClient client = new DiscountClient(channel);

                return client.GetDiscount(new GetDiscountRequest() { ProductID = productId }).Percentage;
            }
            catch (Exception exc)
            {
                return 0;
            }
        }
    }
}
