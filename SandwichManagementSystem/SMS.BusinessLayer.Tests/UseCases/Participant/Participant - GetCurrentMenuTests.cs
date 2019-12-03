using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SMS.BusinessLayer.UseCases;
using SMS.Shared;
using SMS.Shared.Enums;
using SMS.Shared.Interfaces;
using SMS.Shared.TransferObjects;
using System.Collections.Generic;
using System.Linq;

namespace SMS.BusinessLayer.Tests.UseCases.ParticipantTests
{
    [TestClass]
    public class Participant_GetCurrentMenuTests
    {
        public static List<MealTO> GetTestListOfMeals()
        {
            var Tomate = new IngredientTO { Id = 1, Name = new TranslatedString("Tomato", "Tomate", "Tomaat"), IsAllergen = false };
            var Brie = new IngredientTO { Id = 2, Name = new TranslatedString("Brie", "Brie", "Brie"), IsAllergen = true };
            var Fromage = new IngredientTO { Id = 3, Name = new TranslatedString("Cheese", "Fromage", "Kaas"), IsAllergen = true };
            var Noix = new IngredientTO { Id = 4, Name = new TranslatedString("Nuts", "Noix", "Noten"), IsAllergen = true };
            var Beurre = new IngredientTO { Id = 5, Name = new TranslatedString("Butter", "Beurre", "Boter"), IsAllergen = false };
            var Jambon = new IngredientTO { Id = 6, Name = new TranslatedString("Ham", "Jambon", "Ham"), IsAllergen = false };
            var Roquette = new IngredientTO { Id = 7, Name = new TranslatedString("Arugula", "Roquette", "Rucola"), IsAllergen = false };
            var Salade = new IngredientTO { Id = 8, Name = new TranslatedString("Salad", "Salade", "Salade"), IsAllergen = false };
            var Pesto = new IngredientTO { Id = 9, Name = new TranslatedString("Pesto", "Pesto", "Pesto"), IsAllergen = false };
            var Oeuf = new IngredientTO { Id = 10, Name = new TranslatedString("Eggs", "Oeufs", "Eien"), IsAllergen = true };
            var Miel = new IngredientTO { Id = 11, Name = new TranslatedString("Honey", "Miel", "Honing"), IsAllergen = false };

            MealTO Club = new MealTO { Id = 1, MealType = MealType.Sandwich, Name = new TranslatedString("ClubEN", "ClubFR", "ClubNL"), Supplier = new SupplierTO { Id = 33, Name = "Supplier1" }, Ingredients = new List<IngredientTO>() };
            MealTO BrieNoix = new MealTO { Id = 2, MealType = MealType.Sandwich, Name = new TranslatedString("BrieEN", "BrieFR", "BrieNL"), Supplier = new SupplierTO { Id = 33, Name = "Supplier1" }, Ingredients = new List<IngredientTO>() };
            MealTO PestoVerde = new MealTO { Id = 3, MealType = MealType.Sandwich, Name = new TranslatedString("PestoEN", "PestoFR", "PestoNL"), Supplier = new SupplierTO { Id = 33, Name = "Supplier1" }, Ingredients = new List<IngredientTO>() };

            BrieNoix.Ingredients.Add(Brie);
            BrieNoix.Ingredients.Add(Miel);
            BrieNoix.Ingredients.Add(Noix);

            PestoVerde.Ingredients.Add(Pesto);
            PestoVerde.Ingredients.Add(Roquette);
            PestoVerde.Ingredients.Add(Oeuf);

            Club.Ingredients.Add(Jambon);
            Club.Ingredients.Add(Beurre);
            Club.Ingredients.Add(Salade);
            Club.Ingredients.Add(Fromage);
            Club.Ingredients.Add(Tomate);

            var lst = new List<MealTO>(); ;

            lst.Add(BrieNoix);
            lst.Add(Club);
            lst.Add(PestoVerde);

            return lst;
        }

        [TestMethod]
        public void Test_GetCurrentMenu_HasCorrectCountOfMeals()
        {
            // Arrange
            var defaultSupplier = new SupplierTO { Id = 1, Name = "Fake supplier" };
            var mockMealRepo = new Mock<IMealRepository>();
            var mockSupplierRepo = new Mock<ISupplierRepository>();
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockMealRepo.Setup(x => x.GetMealsBySupplier(It.IsAny<SupplierTO>())).Returns(GetTestListOfMeals());
            mockSupplierRepo.Setup(x => x.GetDefaultSupplier()).Returns(defaultSupplier);
            mockUnitOfWork.Setup(x => x.MealRepository).Returns(mockMealRepo.Object);
            mockUnitOfWork.Setup(x => x.SupplierRepository).Returns(mockSupplierRepo.Object);

            // Act
            var participant = new Participant(mockUnitOfWork.Object);
            var menu = participant.GetCurrentMenu();

            // Assert
            Assert.AreEqual(3, menu.Count());
            mockMealRepo.Verify(x => x.GetMealsBySupplier(It.IsAny<SupplierTO>()), Times.Once);
            mockSupplierRepo.Verify(x => x.GetDefaultSupplier(), Times.Once);
        }
    }
}
