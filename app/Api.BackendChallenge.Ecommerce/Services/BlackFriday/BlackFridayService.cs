using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace Api.BackendChallenge.Ecommerce.Services.BlackFriday
{
    public class BlackFridayService
    {
        private IConfiguration configuration;

        public BlackFridayService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        /// <summary>
        /// Verifica se a data corrente é o dia do Black Friday
        /// </summary>
        /// <returns></returns>
        public Boolean IsDayBlackFriday()
        {
            DateTime blackFriDayFormat = Convert.ToDateTime(DateTime.Now.Year.ToString() + "-" + configuration[Constantes.BLACK_FRIDAY_DAY]);

            return blackFriDayFormat.ToString("yyyy-MM-dd") == DateTime.Now.ToString("yyyy-MM-dd") ? true : false;
        }
    }
}
