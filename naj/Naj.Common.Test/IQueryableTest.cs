using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Collections.Generic;

namespace Naj.Common.Test
{
    [TestClass]
    public class IQueryableTest
    {
        private TestContext testContextInstance;
        public TestContext TestContext
        {
            get { return testContextInstance; }
            set { testContextInstance = value; }
        }

        IQueryable<Customer> customers;

        [TestInitialize]
        public void Initialize()
        {
            customers = new List<Customer>()
            {
                new Customer {Id=Guid.NewGuid(),FirstName="Mahmoud",LastName="Shalsh",Age=23 },
                new Customer {Id=Guid.NewGuid(),FirstName="Ahmed",LastName="Tarek",Age=36 },
                new Customer {Id=Guid.NewGuid(),FirstName="Mostafa",LastName="Ali",Age=41 }
            }.AsQueryable<Customer>();
        }

        [TestMethod]
        public void Contains()
        {
            // Arrange
            List<Customer> expected = new List<Customer>() { new Customer { Id = Guid.NewGuid(), FirstName = "Ahmed", LastName = "Tarek", Age = 36 } };

            // Act
            List<Customer> actual = customers.Search("tar").ToList();

            // Analysis
            foreach (var c in actual)
                TestContext.WriteLine(c.ToString());

            // Assert
            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
