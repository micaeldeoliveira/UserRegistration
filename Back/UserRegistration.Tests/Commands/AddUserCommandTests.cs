using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using UserRegistration.Domain.Commands;

namespace UserRegistration.Tests.Commands
{
    [TestClass]
    public class AddUserCommandTests
    {
        [TestMethod]
        public void Dado_Commando_Valido_Retorna_Comando_Valido()
        {
            var command = new AddUserCommand
            {
                FirstName = "Micael",
                LastName = "de Oliveira",
                Email = "micaeldeoliveira@gmail.com",
                BirthDate = DateTime.Now.AddDays(-1),
                Schooling = Domain.Enums.ESchooling.College
            };

            command.Validate();

            Assert.AreEqual(true, command.IsValid);
            Assert.AreEqual(true, command.Notifications.Count == 0);

        }

        [TestMethod]
        public void Dado_Commando_Com_Atributo_Nao_Preenchido_Retorna_Comando_Invalido()
        {
            var command = new AddUserCommand
            {
                FirstName = "",
                LastName = "",
                Email = "",
                BirthDate = DateTime.Now.AddDays(-1),
                Schooling = Domain.Enums.ESchooling.College
            };

            command.Validate();

            Assert.AreEqual(false, command.IsValid);
            Assert.AreEqual(true, command.Notifications.Count == 3);

        }
    }
}
