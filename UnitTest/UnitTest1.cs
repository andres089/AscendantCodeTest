using CodeTest.Business.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {

        private readonly IConfiguration _config;

       [TestMethod]
        public void ValidateUser()
        {
            CodeTest.Program.Main(new string[0]);
            CodeTest.Business.Services.Service  token = new CodeTest.Business.Services.Service(_config);
            CodeTest.Business.Entities.UserRequest user = new CodeTest.Business.Entities.UserRequest();
            user.Name = "Ascendant";
            user.Pasword = "Ascendant";

            var resultado = token.UserValidate(user);

            Assert.IsTrue(resultado);

        }


        [TestMethod]
        public void ValidateGetTaxRatesLocation()
        {
            CodeTest.Program.Main(new string[0]);
            CodeTest.Business.Services.Service token = new CodeTest.Business.Services.Service(_config);

            var resultado =  token.GetTaxRatesLocation("90404");

            Assert.IsTrue(string.IsNullOrWhiteSpace(resultado.Result.Message));

        }

        [TestMethod]
        public void ValidateCalculateTaxesOrdern()
        {
            CodeTest.Program.Main(new string[0]);
            CodeTest.Business.Services.Service service = new CodeTest.Business.Services.Service(_config);

            CalculateTaxesOrderRequest calculateTaxesOrderRequest = new CalculateTaxesOrderRequest();

            calculateTaxesOrderRequest.to_country = "US";
            calculateTaxesOrderRequest.to_zip = "90002";
            calculateTaxesOrderRequest.to_state = "CA";
            calculateTaxesOrderRequest.amount = 15;
            calculateTaxesOrderRequest.shipping = decimal.Parse("1.5");

            var resultado = service.CalculateTaxesOrder(calculateTaxesOrderRequest);

            Assert.IsTrue(string.IsNullOrWhiteSpace(resultado.Result.Message));

        }

    }
}
