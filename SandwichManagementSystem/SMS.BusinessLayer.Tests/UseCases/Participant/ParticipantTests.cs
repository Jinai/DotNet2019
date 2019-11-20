using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SMS.BusinessLayer.Domain;
using SMS.BusinessLayer.UseCases;
using SMS.DataLayer;
using SMS.Shared;
using System.Collections.Generic;
using System.Linq;

namespace SMS.BusinessLayer.Tests.UseCases
{
    [TestClass]
    public class ParticipantTests
    {
        public static List<Sandwich> GetTestsListOfSandwich()
        {
            Ingredient Tomate = new Ingredient(new TranslatedString("Tomato", "Tomate", "Tomaat"), false);
            Ingredient Brie = new Ingredient(new TranslatedString("Brie", "Brie", "Brie"), true);
            Ingredient Fromage = new Ingredient(new TranslatedString("Cheese", "Fromage", "Kaas"), true);
            Ingredient Noix = new Ingredient(new TranslatedString("Nuts", "Noix", "Noten"), true);
            Ingredient Beurre = new Ingredient(new TranslatedString("Butter", "Beurre", "Boter"), false);
            Ingredient Jambon = new Ingredient(new TranslatedString("Ham", "Jambon", "Ham"), false);
            Ingredient Roquette = new Ingredient(new TranslatedString("Arugula", "Roquette", "Rucola"), false);
            Ingredient Salade = new Ingredient(new TranslatedString("Salad", "Salade", "Salade"), false);
            Ingredient Pesto = new Ingredient(new TranslatedString("Pesto", "Pesto", "Pesto"), false);
            Ingredient Oeuf = new Ingredient(new TranslatedString("Eggs", "Oeufs", "Eien"), true);
            Ingredient Miel = new Ingredient(new TranslatedString("Honey", "Miel", "Honing"), false);

            Sandwich Club = new Sandwich(new TranslatedString("Club", "Club", "Club"), null);
            Sandwich BrieNoix = new Sandwich(new TranslatedString("Brie", "Brie", "Brie"), null);
            Sandwich PestoVerde = new Sandwich(new TranslatedString("Pesto", "Pesto", "Pesto"), null);

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

            var lst = new List<Sandwich>(); ;

            lst.Add(BrieNoix);
            lst.Add(Club);
            lst.Add(PestoVerde);

            return lst;
        }

        [TestMethod]
        public void Test_AfficherMenu()
        {
            var fakeSandwichRepo = new Mock<IRepository<Sandwich, int>>();
            var fakeIngredientRepo = new Mock<IRepository<Ingredient, int>>();

            fakeSandwichRepo.Setup(x => x.GetAll()).Returns(GetTestsListOfSandwich());

            var participant = new Participant(fakeSandwichRepo.Object, fakeIngredientRepo.Object);

            var listMenu = participant.AfficherMenu("Test", Language.English);

            Assert.AreEqual(3, listMenu.Count());
        }
    }
}
