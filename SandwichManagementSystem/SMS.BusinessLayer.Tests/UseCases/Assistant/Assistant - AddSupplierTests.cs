using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SMS.BusinessLayer.UseCases.Assistant;
using SMS.Shared.Exceptions;
using SMS.Shared.Interfaces;
using SMS.Shared.TransferObjects;
using System;

namespace SMS.BusinessLayer.Tests.UseCases.AssistantTests
{
    [TestClass]
    public class Assistant_AddSupplierTests
    {
        [TestMethod]
        public void Test_AddSupplier_ThrowsException_WhenSupplierIsNull()
        {
            // Arrange
            SupplierTO badSupplier = null;

            var mockSupplierRepo = new Mock<ISupplierRepository>();
            mockSupplierRepo.Setup(x => x.Insert(It.IsAny<SupplierTO>()));

            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(x => x.SupplierRepository).Returns(mockSupplierRepo.Object);

            var assistant = new Assistant(new Mock<IUnitOfWork>().Object);

            // Assert
            Assert.ThrowsException<ArgumentNullException>(() => assistant.AddSupplier(badSupplier));
            mockSupplierRepo.Verify(x => x.Insert(It.IsAny<SupplierTO>()), Times.Never);
        }

        [TestMethod]
        public void Test_AddSupplier_ThrowsException_WhenSupplierIdIsNotZero()
        {
            // Arrange
            var badSupplier = new SupplierTO { Id = 10 };

            var mockSupplierRepo = new Mock<ISupplierRepository>();
            mockSupplierRepo.Setup(x => x.Insert(It.IsAny<SupplierTO>()));

            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(x => x.SupplierRepository).Returns(mockSupplierRepo.Object);

            var assistant = new Assistant(new Mock<IUnitOfWork>().Object);

            // Assert
            Assert.ThrowsException<InvalidSupplierException>(() => assistant.AddSupplier(badSupplier));
            mockSupplierRepo.Verify(x => x.Insert(It.IsAny<SupplierTO>()), Times.Never);
        }

        [TestMethod]
        public void Test_AddSupplier_ThrowsException_WhenSupplierNameIsInvalid()
        {
            // Arrange
            var badSupplier1 = new SupplierTO { Name = null, ContactName = "ContactName", Email = "Email" };
            var badSupplier2 = new SupplierTO { Name = "", ContactName = "ContactName", Email = "Email" };
            var badSupplier3 = new SupplierTO { Name = "  ", ContactName = "ContactName", Email = "Email" };
            var badSupplier4 = new SupplierTO { Name = "\t", ContactName = "ContactName", Email = "Email" };
            var badSupplier5 = new SupplierTO { Name = "\n  \t ", ContactName = "ContactName", Email = "Email" };

            var mockSupplierRepo = new Mock<ISupplierRepository>();
            mockSupplierRepo.Setup(x => x.Insert(It.IsAny<SupplierTO>()));

            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(x => x.SupplierRepository).Returns(mockSupplierRepo.Object);

            var assistant = new Assistant(new Mock<IUnitOfWork>().Object);

            // Assert
            Assert.ThrowsException<InvalidSupplierException>(() => assistant.AddSupplier(badSupplier1));
            Assert.ThrowsException<InvalidSupplierException>(() => assistant.AddSupplier(badSupplier2));
            Assert.ThrowsException<InvalidSupplierException>(() => assistant.AddSupplier(badSupplier3));
            Assert.ThrowsException<InvalidSupplierException>(() => assistant.AddSupplier(badSupplier4));
            Assert.ThrowsException<InvalidSupplierException>(() => assistant.AddSupplier(badSupplier5));
            mockSupplierRepo.Verify(x => x.Insert(It.IsAny<SupplierTO>()), Times.Never);
        }

        [TestMethod]
        public void Test_AddSupplier_ThrowsException_WhenSupplierContactNameIsInvalid()
        {
            // Arrange
            var badSupplier1 = new SupplierTO { Name = "Name", ContactName = null, Email = "Email" };
            var badSupplier2 = new SupplierTO { Name = "Name", ContactName = "", Email = "Email" };
            var badSupplier3 = new SupplierTO { Name = "Name", ContactName = "  ", Email = "Email" };
            var badSupplier4 = new SupplierTO { Name = "Name", ContactName = "\t", Email = "Email" };
            var badSupplier5 = new SupplierTO { Name = "Name", ContactName = "\n  \t ", Email = "Email" };

            var mockSupplierRepo = new Mock<ISupplierRepository>();
            mockSupplierRepo.Setup(x => x.Insert(It.IsAny<SupplierTO>()));

            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(x => x.SupplierRepository).Returns(mockSupplierRepo.Object);

            var assistant = new Assistant(new Mock<IUnitOfWork>().Object);

            // Assert
            Assert.ThrowsException<InvalidSupplierException>(() => assistant.AddSupplier(badSupplier1));
            Assert.ThrowsException<InvalidSupplierException>(() => assistant.AddSupplier(badSupplier2));
            Assert.ThrowsException<InvalidSupplierException>(() => assistant.AddSupplier(badSupplier3));
            Assert.ThrowsException<InvalidSupplierException>(() => assistant.AddSupplier(badSupplier4));
            Assert.ThrowsException<InvalidSupplierException>(() => assistant.AddSupplier(badSupplier5));
            mockSupplierRepo.Verify(x => x.Insert(It.IsAny<SupplierTO>()), Times.Never);
        }

        [TestMethod]
        public void Test_AddSupplier_ThrowsException_WhenSupplierEmailIsInvalid()
        {
            // Arrange
            var badSupplier1 = new SupplierTO { Name = "Name", ContactName = "ContactName", Email = null };
            var badSupplier2 = new SupplierTO { Name = "Name", ContactName = "ContactName", Email = "" };
            var badSupplier3 = new SupplierTO { Name = "Name", ContactName = "ContactName", Email = "  " };
            var badSupplier4 = new SupplierTO { Name = "Name", ContactName = "ContactName", Email = "\t" };
            var badSupplier5 = new SupplierTO { Name = "Name", ContactName = "ContactName", Email = "\n  \t " };

            var mockSupplierRepo = new Mock<ISupplierRepository>();
            mockSupplierRepo.Setup(x => x.Insert(It.IsAny<SupplierTO>()));

            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(x => x.SupplierRepository).Returns(mockSupplierRepo.Object);

            var assistant = new Assistant(new Mock<IUnitOfWork>().Object);

            // Assert
            Assert.ThrowsException<InvalidSupplierException>(() => assistant.AddSupplier(badSupplier1));
            Assert.ThrowsException<InvalidSupplierException>(() => assistant.AddSupplier(badSupplier2));
            Assert.ThrowsException<InvalidSupplierException>(() => assistant.AddSupplier(badSupplier3));
            Assert.ThrowsException<InvalidSupplierException>(() => assistant.AddSupplier(badSupplier4));
            Assert.ThrowsException<InvalidSupplierException>(() => assistant.AddSupplier(badSupplier5));
            mockSupplierRepo.Verify(x => x.Insert(It.IsAny<SupplierTO>()), Times.Never);
        }

        [TestMethod]
        public void Test_AddSupplier_ReturnsTrueAndRepoIsCalledOnce_WhenSupplierIsValid()
        {
            // Arrange
            var supplier = new SupplierTO { Name = "Name", ContactName = "ContactName", Email = "Email" };

            var mockSupplierRepo = new Mock<ISupplierRepository>();
            mockSupplierRepo.Setup(x => x.Insert(It.IsAny<SupplierTO>()));

            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(x => x.SupplierRepository).Returns(mockSupplierRepo.Object);

            var assistant = new Assistant(mockUnitOfWork.Object);

            // Act
            var result = assistant.AddSupplier(supplier);

            // Assert
            Assert.IsTrue(result);
            mockSupplierRepo.Verify(x => x.Insert(It.IsAny<SupplierTO>()), Times.Once);
        }

        [TestMethod]
        public void Test_AddSupplier_ReturnsTrueAndSetsDefault_WhenSupplierIsValidAndIsDefault()
        {
            // Arrange
            var supplier = new SupplierTO { Name = "Name", ContactName = "ContactName", Email = "Email", IsDefault = true };

            var mockSupplierRepo = new Mock<ISupplierRepository>();
            mockSupplierRepo.Setup(x => x.Insert(It.IsAny<SupplierTO>()));
            mockSupplierRepo.Setup(x => x.SetDefaultSupplier(It.IsAny<SupplierTO>()));

            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(x => x.SupplierRepository).Returns(mockSupplierRepo.Object);

            var assistant = new Assistant(mockUnitOfWork.Object);

            // Act
            var result = assistant.AddSupplier(supplier);

            // Assert
            Assert.IsTrue(result);
            mockSupplierRepo.Verify(x => x.Insert(It.IsAny<SupplierTO>()), Times.Once);
            mockSupplierRepo.Verify(x => x.SetDefaultSupplier(It.IsAny<SupplierTO>()), Times.Once);
        }
    }
}
