using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CodeTest.Business.ExternalApis
{
    public class ApiTaxJar :BaseApiHttp
    {

        public ApiTaxJar(IConfiguration config) : base()
        {
            Client.BaseAddress = new Uri(config.GetValue<string>("Keys: UrlTaxJar"));

        }

        public ApiTaxJar(IConfiguration config, int ConsultType) : base()
        {
            string key;

            if (ConsultType == 1)
            {
                key = "UrlTaxJar";
            }
            else
            {
                key = "UrlTaxJar";
            }
            Client.BaseAddress = new Uri(config.GetValue<string>(string.Concat("Keys:", key)));

        }

    }
}
