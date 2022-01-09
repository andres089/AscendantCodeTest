using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CodeTest.Business.Entities;
using CodeTest.Business.ExternalApis;
using Microsoft.Extensions.Configuration;

namespace CodeTest.Business.Services
{
    public class Service
    {
        private ApiTaxJar apiTaxJar;
        private readonly IConfiguration _config;

        public Service(IConfiguration config)
        {                    
            _config = config;
        }

        public bool UserValidate(UserRequest user)
        {
            string userName = new string(_config.GetValue<string>("User:userName"));
            string userPasword = new string(_config.GetValue<string>("User:userPasword"));

            if (user.Name == userName && user.Pasword == userPasword)
            {
                return true;
            }else
            {
                return false;
            }           
        }

        public async Task<TaxRateLocationResponse> GetTaxRatesLocation(string zip)
        {
            int consultType = 1;
            apiTaxJar = new ApiTaxJar(_config, consultType);

            TaxRateLocationResponse response = new TaxRateLocationResponse();

            if (string.IsNullOrWhiteSpace(zip))
            {
                response.Message = "zip  is requerid.";
                return response;
            }
            else {

                response = await apiTaxJar.Get<TaxRateLocationResponse>($"rates?zip={zip}");
            }

            return response;                       
        }

        public async Task<CalculateTaxesOrderResponse> CalculateTaxesOrder(CalculateTaxesOrderRequest request)
        {

            CalculateTaxesOrderResponse response = new CalculateTaxesOrderResponse();
            int consultType = 1;
            apiTaxJar = new ApiTaxJar(_config, consultType);

            if (request == null)
            {                
                response.Message = "Data is requerid";
                return response;
            }

            response = await apiTaxJar.Post<CalculateTaxesOrderResponse, CalculateTaxesOrderRequest>("taxes", request);

            return response;
                      

        }
             
    }
}
