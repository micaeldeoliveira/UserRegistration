using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using UserRegistration.Domain.Entities;
using UserRegistration.Domain.Enums;

namespace UserRegistration.Tests.Entities
{
    [TestClass]
    public class UserTests
    {
        [TestMethod]
        public void Dado_Usuario_Valido_Retorna_Usuario_Valido()
        {
            var user = new User(
              "Micael", "de Oliveira",
              "micaeldeoliveira@gmail.com", DateTime.Now.AddDays(-1),
              ESchooling.College);

            Assert.AreEqual(true, user.IsValid);
            Assert.AreEqual(true, user.Notifications.Count == 0);

        }

        [TestMethod]
        public void Dado_Email_Invalido_Retorna_Usuario_Invalido()
        {
            var user = new User(
              "Micael", "de Oliveira",
              "micael", new DateTime(),
              ESchooling.College);

            Assert.AreEqual(false, user.IsValid);
            Assert.AreEqual(true, user.Notifications.Count > 0);

        }

        [TestMethod]
        public void Dado_Data_de_Nascimento_Maior_Que_Hoje_Retorna_Usuario_Invalido()
        {
            var user = new User(
              "Micael", "de Oliveira",
              "micaeldeoliveira@gmail.com", DateTime.Now.AddDays(1),
              ESchooling.College);

            Assert.AreEqual(false, user.IsValid);
            Assert.AreEqual(true, user.Notifications.Count > 0);

        }

        [TestMethod]
        public void Dado_Escolaridade_Invalida_Retorna_Usuario_Invalido()
        {
            var user = new User(
              "Micael", "de Oliveira",
              "micaeldeoliveira@gmail.com", DateTime.Now.Date,
              ESchooling.Unknown);

            Assert.AreEqual(false, user.IsValid);
            Assert.AreEqual(true, user.Notifications.Count > 0);

        }

    }
}
