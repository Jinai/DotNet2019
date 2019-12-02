using Microsoft.VisualStudio.TestTools.UnitTesting;
using SMS.BusinessLayer.Domain;
using SMS.Shared;
using SMS.Shared.Enums;
using SMS.Shared.Exceptions;
using System;

namespace SMS.BusinessLayer.Tests
{
    [TestClass]
    public class IngredientTests
    {
        [TestMethod]
        public void Test_ToString_WithoutAllergen()
        {
            var ts1 = new TranslatedString("Ham", "Jambon", "Ham");
            var ts2 = new TranslatedString("Cheese", "Fromage", "Kaas");

            var ing1 = new Ingredient { Name = ts1 };
            var ing2 = new Ingredient { Name = ts2 };

            Assert.AreEqual("Ham", ing1.ToString(Language.English));
            Assert.AreEqual("Jambon", ing1.ToString(Language.French));
            Assert.AreEqual("Ham", ing1.ToString(Language.Dutch));

            Assert.AreEqual("Cheese", ing2.ToString(Language.English));
            Assert.AreEqual("Fromage", ing2.ToString(Language.French));
            Assert.AreEqual("Kaas", ing2.ToString(Language.Dutch));
        }

        [TestMethod]
        public void Test_ToString_WithAllergen()
        {
            var ts1 = new TranslatedString("Peanut", "Cacahuète", "Pinda");
            var ts2 = new TranslatedString("Egg", "Oeuf", "Ei");

            var ing1 = new Ingredient { Name = ts1, IsAllergen = true };
            var ing2 = new Ingredient { Name = ts2, IsAllergen = true };

            Assert.AreEqual("Peanut*", ing1.ToString(Language.English));
            Assert.AreEqual("Cacahuète*", ing1.ToString(Language.French));
            Assert.AreEqual("Pinda*", ing1.ToString(Language.Dutch));

            Assert.AreEqual("Egg*", ing2.ToString(Language.English));
            Assert.AreEqual("Oeuf*", ing2.ToString(Language.French));
            Assert.AreEqual("Ei*", ing2.ToString(Language.Dutch));
        }

        [TestMethod]
        public void Test_CheckValidity_ThrowsException_WithEmptyConstructor()
        {
            var ing = new Ingredient();
            Assert.ThrowsException<InvalidIngredientException>(() => ing.CheckValidity());
        }

        [TestMethod]
        public void Test_CheckValidity_ThrowsException_WhenNameIsInvalid()
        {
            var ing = new Ingredient { Name = null };
            Assert.ThrowsException<InvalidIngredientException>(() => ing.CheckValidity());
            Assert.ThrowsException<ArgumentException>(() => new Ingredient { Name = new TranslatedString("", "", "") });
        }

        [TestMethod]
        public void Test_CheckValidity_ThrowsException_WhenIdIsInvalid()
        {
            var ing = new Ingredient { Id = -1, Name = new TranslatedString("Ham", "Jambon", "Ham") };
            Assert.ThrowsException<DomainException>(() => ing.CheckValidity());
        }

        [TestMethod]
        public void Test_CheckValidity_NoException_WhenIngredientIsValid()
        {
            var ing = new Ingredient { Id = 1, Name = new TranslatedString("Ham", "Jambon", "Ham") };
            Assert.IsNotNull(ing);
            ing.CheckValidity();
        }
    }
}
