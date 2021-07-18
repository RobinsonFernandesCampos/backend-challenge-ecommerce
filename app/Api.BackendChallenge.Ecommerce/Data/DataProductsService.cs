using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using System.Threading.Tasks;

namespace Api.BackendChallenge.Ecommerce.Data
{
    public class DataProductsService
    {
        public List<ProductObject> Get()
        {
            string filePath = Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory) + "/Data/Object//products.json";

            using (StreamReader file = File.OpenText(filePath))
            {
                return JsonConvert.DeserializeObject<List<ProductObject>>(file.ReadToEnd());
            }
        }
    }
}
