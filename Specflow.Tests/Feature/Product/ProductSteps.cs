
using System;
using System.Net;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using DataModels.Models;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Specflow.Tests
{
    [Binding]
    public class ProductSteps : BaseTest
    {
        private string ProductEndPoint { get; set; }
        public ProductSteps()
        {
            ProductEndPoint = $"{ApiUri}api/product";
        }
        [When(@"product required attributes provided")]
        public void WhenProductRequiredAttributesProvided(Table dto)
        {
            try
            {
                var product = dto.CreateInstance<Product>();
                var data = JsonData(product);
                var result = Task.Run(async () => await Client.PostAsync(ProductEndPoint, data)).Result;
                Assert.IsTrue(result != null && result.StatusCode == HttpStatusCode.OK, "Add Product Integration Test Completed");
            }
            catch (Exception ex)
            {
                Assert.IsTrue(false, ex.Message);
            }
        }

        [When(@"No product supplied All product list should return")]
        public void WhenNoProductSuppliedAllProductListShouldReturn(Table dto)
        {
            var result = Task.Run(async () => await Client.GetAsync(ProductEndPoint)).Result;
            Assert.IsTrue(result != null && result.StatusCode == HttpStatusCode.OK, "Get All Product Integration Test Completed");
            var products = ObjectData<List<Product>>(result.Content.ReadAsStringAsync().Result);
            Assert.IsTrue(dto.RowCount == products.Count, "Input and Out product count matched");
        }


        [Given(@"I have supplied (.*) as product Id")]
        public void GivenIHaveSuppliedAsProductId(int productId)
        {
            var result = Task.Run(async () => await Client.GetAsync($"{ProductEndPoint}/{productId}")).Result;
            Assert.IsTrue(result != null && result.StatusCode == HttpStatusCode.OK, "Get Product Integration Test Completed");
        }

        [Then(@"product details should be")]
        public void ThenProductDetailsShouldBe(Table dto)
        {
            var product = dto.CreateInstance<Product>();
            var result = Task.Run(async () => await Client.GetAsync($"{ProductEndPoint}/{product.Id}")).Result;
            Assert.IsTrue(result != null && result.StatusCode == HttpStatusCode.OK, "Product Details Integration Test Completed");
            var productToComparte = ObjectData<Product>(result.Content.ReadAsStringAsync().Result);
            Assert.IsTrue(dto.IsEquivalentToInstance(productToComparte));
        }
    }
}

