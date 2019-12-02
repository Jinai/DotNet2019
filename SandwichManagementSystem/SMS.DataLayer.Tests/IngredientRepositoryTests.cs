using Microsoft.VisualStudio.TestTools.UnitTesting;
using SMS.Shared;
using SMS.Shared.Interfaces;
using SMS.Shared.TransferObjects;
using System.Linq;

namespace SMS.DataLayer.Tests
{
    [TestClass]
    public class IngredientRepositoryTests
    {
        public static IUnitOfWork unitOfWork;

        [ClassInitialize]
        public static void ClassInitialize(TestContext testContext)
        {
            unitOfWork = new UnitOfWork(null);
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            unitOfWork.Dispose();
        }

        [TestMethod]
        public void Test_Insert()
        {
            var ing1 = new IngredientTO()
            {
                Name = new TranslatedString("Peanut butter", "Beurre de cacahuète", "Pindakaas"),
                IsAllergen = true,
            };
            var ing2 = new IngredientTO()
            {
                Name = new TranslatedString("Jelly", "Confiture", "Jam"),
                IsAllergen = false,
            };

            Assert.AreEqual(0, unitOfWork.IngredientRepository.GetAll().Count());
            unitOfWork.IngredientRepository.Insert(ing1);
            unitOfWork.Save();
            Assert.AreEqual(1, unitOfWork.IngredientRepository.GetAll().Count());
            unitOfWork.IngredientRepository.Insert(ing2);
            unitOfWork.Save();
            Assert.AreEqual(2, unitOfWork.IngredientRepository.GetAll().Count());
        }
    }
}
