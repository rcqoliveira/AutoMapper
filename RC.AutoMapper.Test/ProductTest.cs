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
        private Product Product { get; set; }
        private ProductRequest ProductRequest { get; set; }
        private ProductResponse ProductResponse { get; set; }

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
            var product = this.ProductRequest.MapTo(this.Product);

            Assert.AreEqual(product.Id, this.Product.Id);
            Assert.AreEqual(product.Price, this.Product.Price);
            Assert.AreEqual(product.Validity, this.Product.Validity);
            Assert.AreEqual(product.ProductName, this.Product.ProductName);
            Assert.AreEqual(product.Suppliers.Count(), this.Product.Suppliers.Count());
        }

        [Test]
        public void ValidateDataFromDomainsToResponse()
        {
            var productResponse = this.Product.MapTo(this.ProductResponse);

            Assert.AreEqual(productResponse.Id, this.Product.Id);
            Assert.AreEqual(productResponse.Price, this.Product.Price);
            Assert.AreEqual(productResponse.Validity, this.Product.Validity);
            Assert.AreEqual(productResponse.ProductName, this.Product.ProductName);
            Assert.AreEqual(productResponse.Suppliers.Count(), this.Product.Suppliers.Count());

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

            this.Product = new Product
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
