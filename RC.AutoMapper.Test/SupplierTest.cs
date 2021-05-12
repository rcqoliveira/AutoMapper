using NUnit.Framework;
using RC.AutoMapper.Configuration;
using RC.AutoMapper.Domains;
using RC.AutoMapper.Request;
using RC.AutoMapper.Response;

namespace RC.AutoMapper.Test
{
    public class SupplierTest
    {
        private Supplier SupplierDomains { get; set; }
        private SupplierRequest SupplierRequest { get; set; }

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
            var Supplier = this.SupplierRequest.MapTo<SupplierRequest, Supplier>();

            Assert.AreEqual(Supplier.Id, this.SupplierRequest.Id);
            Assert.AreEqual(Supplier.FantasyName, this.SupplierRequest.FantasyName);
            Assert.AreEqual(Supplier.SupplierName, this.SupplierRequest.SupplierName);
        }

        [Test]
        public void ValidateDataFromDomainsToResponse()
        {
            var supplierResponse = this.SupplierDomains.MapTo<Supplier, SupplierResponse>() ;

            Assert.AreEqual(supplierResponse.Id, this.SupplierDomains.Id);
            Assert.AreEqual(supplierResponse.FantasyName, this.SupplierDomains.FantasyName);
            Assert.AreEqual(supplierResponse.SupplierName, this.SupplierDomains.SupplierName);

        }

        private void CreateDataForRequest()
        {

            this.SupplierRequest = new SupplierRequest
            {
                Id = 1,
                FantasyName = "Dell",
                SupplierName = "Dell technology"
            };
        }

        private void CreateDataForDomains()
        {
            this.SupplierDomains = new Supplier
            {
                Id = 2,
                FantasyName = "Microsoft",
                SupplierName = "Microsoft technology"
            };
        }
    }
}
