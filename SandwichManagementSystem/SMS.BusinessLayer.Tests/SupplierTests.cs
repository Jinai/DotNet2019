using Microsoft.VisualStudio.TestTools.UnitTesting;
using SMS.BusinessLayer.Domain;
using SMS.Shared;
using SMS.Shared.Enums;
using SMS.Shared.Exceptions;

namespace SMS.BusinessLayer.Tests
{
    [TestClass]
    public class SupplierTests
    {
        [TestMethod]
        public void Test_ToString()
        {
            var sup = new Supplier
            {
                Name = "Supplier 1",
                ContactName = "S1",
                Email = "supplier1@gmail.com",
                LanguageChoice = Language.English
            };
            Assert.AreEqual("Supplier 1 (supplier1@gmail.com) - S1", sup.ToString());
        }

        [TestMethod]
        public void Test_CheckValidity_ThrowsException_WithEmptyConstructor()
        {
            var sup = new Supplier();
            Assert.ThrowsException<InvalidSupplierException>(() => sup.CheckValidity());
        }

        [TestMethod]
        public void Test_CheckValidity_ThrowsException_WhenPropertiesAreNull()
        {
            var sup1 = new Supplier { Name = null, ContactName = null, Email = null };
            var sup2 = new Supplier { Name = "Name", ContactName = "ContactName", Email = null };
            var sup3 = new Supplier { Name = "Name", ContactName = null, Email = "Email" };
            var sup4 = new Supplier { Name = null, ContactName = "ContactName", Email = "Email" };
            Assert.ThrowsException<InvalidSupplierException>(() => sup1.CheckValidity());
        }

        [TestMethod]
        public void Test_CheckValidity_ThrowsException_WhenNameIsInvalid()
        {
            var sup1 = new Supplier { Name = null, ContactName = "ContactName", Email = "Email" };
            var sup2 = new Supplier { Name = "", ContactName = "ContactName", Email = "Email" };
            var sup3 = new Supplier { Name = "  ", ContactName = "ContactName", Email = "Email" };
            var sup4 = new Supplier { Name = "\t", ContactName = "ContactName", Email = "Email" };
            var sup5 = new Supplier { Name = "\n  \t ", ContactName = "ContactName", Email = "Email" };
            Assert.ThrowsException<InvalidSupplierException>(() => sup1.CheckValidity());
            Assert.ThrowsException<InvalidSupplierException>(() => sup2.CheckValidity());
            Assert.ThrowsException<InvalidSupplierException>(() => sup3.CheckValidity());
            Assert.ThrowsException<InvalidSupplierException>(() => sup4.CheckValidity());
            Assert.ThrowsException<InvalidSupplierException>(() => sup5.CheckValidity());
        }

        [TestMethod]
        public void Test_CheckValidity_ThrowsException_WhenContactNameIsInvalid()
        {
            var sup1 = new Supplier { Name = "Name", ContactName = null, Email = "Email" };
            var sup2 = new Supplier { Name = "Name", ContactName = "", Email = "Email" };
            var sup3 = new Supplier { Name = "Name", ContactName = "  ", Email = "Email" };
            var sup4 = new Supplier { Name = "Name", ContactName = "\t", Email = "Email" };
            var sup5 = new Supplier { Name = "Name", ContactName = "\n  \t ", Email = "Email" };
            Assert.ThrowsException<InvalidSupplierException>(() => sup1.CheckValidity());
            Assert.ThrowsException<InvalidSupplierException>(() => sup2.CheckValidity());
            Assert.ThrowsException<InvalidSupplierException>(() => sup3.CheckValidity());
            Assert.ThrowsException<InvalidSupplierException>(() => sup4.CheckValidity());
            Assert.ThrowsException<InvalidSupplierException>(() => sup5.CheckValidity());
        }

        [TestMethod]
        public void Test_CheckValidity_ThrowsException_WhenEmailIsInvalid()
        {
            var sup1 = new Supplier { Name = "Name", ContactName = "ContactName", Email = null };
            var sup2 = new Supplier { Name = "Name", ContactName = "ContactName", Email = "" };
            var sup3 = new Supplier { Name = "Name", ContactName = "ContactName", Email = "  " };
            var sup4 = new Supplier { Name = "Name", ContactName = "ContactName", Email = "\t" };
            var sup5 = new Supplier { Name = "Name", ContactName = "ContactName", Email = "\n  \t " };
            Assert.ThrowsException<InvalidSupplierException>(() => sup1.CheckValidity());
            Assert.ThrowsException<InvalidSupplierException>(() => sup2.CheckValidity());
            Assert.ThrowsException<InvalidSupplierException>(() => sup3.CheckValidity());
            Assert.ThrowsException<InvalidSupplierException>(() => sup4.CheckValidity());
            Assert.ThrowsException<InvalidSupplierException>(() => sup5.CheckValidity());
        }
    }
}
