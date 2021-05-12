using NUnit.Framework;
using RC.AutoMapper.Configuration;
using RC.AutoMapper.Domains;
using RC.AutoMapper.Request;
using RC.AutoMapper.Response;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RC.AutoMapper.Test
{
    public class ProductTest
    {
        private Product ProductDomains { get; set; }
        private ProductRequest ProductRequest { get; set; }

        [SetUp]
        public void Setup()
        {
            this.CreateDataForRequest();
            this.CreateDataForDomains();
            AutoMapperConfiguration.Initialize();
        }

        [Test]
        public void ValidateDataFromRequestToDomains()
        {
            var product = this.ProductRequest.MapTo<ProductRequest, Product>();

            Assert.AreEqual(product.Id, this.ProductRequest.Id);
            Assert.AreEqual(product.Price, this.ProductRequest.Price);
            Assert.AreEqual(product.Validity, this.ProductRequest.Validity);
            Assert.AreEqual(product.ProductName, this.ProductRequest.ProductName);
            Assert.AreEqual(product.Suppliers.Count(), this.ProductRequest.Suppliers.Count());
        }

        [Test]
        public void ValidateDataFromDomainsToResponse()
        {
            var productResponse = this.ProductDomains.MapTo<Product, ProductResponse>();

            Assert.AreEqual(productResponse.Id, this.ProductDomains.Id);
            Assert.AreEqual(productResponse.Price, this.ProductDomains.Price);
            Assert.AreEqual(productResponse.Validity, this.ProductDomains.Validity);
            Assert.AreEqual(productResponse.ProductName, this.ProductDomains.ProductName);
            Assert.AreEqual(productResponse.Suppliers.Count(), this.ProductDomains.Suppliers.Count());

        }

        private void CreateDataForRequest()
        {
            var listSuplierRequest = new List<SupplierRequest>
            {
                new SupplierRequest
                {
                    Id = 1,
                    FantasyName = "Dell", SupplierName = "Dell technology"
                },
                  new SupplierRequest
                {
                    Id = 1,
                    FantasyName = "Microsoft", SupplierName = "Dell technology"
                }
            };

            this.ProductRequest = new ProductRequest
            {
                Id = 1,
                Price = 5.40,
                ProductName = "Mouse",
                Validity = DateTime.Now,
                Suppliers = listSuplierRequest
            };
        }

        private void CreateDataForDomains()
        {
            var listSuplier = new List<Supplier>
            {
                new Supplier
                {
                    Id = 1,
                    FantasyName = "Dell", SupplierName = "Dell technology"
                }
            };

            this.ProductDomains = new Product
            {
                Id = 2,
                Price = 6.40,
                ProductName = "keyboard",
                Validity = DateTime.Now,
                Suppliers = listSuplier
            };
        }
    }
}
