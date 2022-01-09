using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CodeTest.Business.Services;
using CodeTest.Business.Entities;
using Microsoft.AspNetCore.Authorization;

namespace CodeTest.Controllers
{
    [Authorize]
    [ApiController]
    public class TaxCalculationController : ControllerBase
    {
        private readonly TokenFactory _tokenFactory;
        private readonly Service _service;

        public TaxCalculationController(TokenFactory tokenFactory, Service service)
        {
            _tokenFactory = tokenFactory;
            _service = service;
        }

        [HttpGet("GetTaxRatesLocation")]
        public async Task<IActionResult> GetTaxRatesLocation(string zip)
        {
            TaxRateLocationResponse response = new TaxRateLocationResponse();           

            response =  await _service.GetTaxRatesLocation(zip);

            if (response == null)
            {
                response.Message = "Data no found.";
                return Ok(response);
            }

            return Ok(response);

        }

        [HttpPost("CalculateTaxesOrder")]
        public async Task<IActionResult> CalculateTaxesOrder(CalculateTaxesOrderRequest request)
        {
            CalculateTaxesOrderResponse response= new CalculateTaxesOrderResponse();
            response = await _service.CalculateTaxesOrder(request);

            if (response == null)
            {
                response.Message = "Data no found.";
                return Ok(response);
            }

            return Ok(response);

        }        

    }
}
