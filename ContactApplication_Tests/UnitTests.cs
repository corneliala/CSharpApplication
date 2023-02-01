using ContactApplication.Models;
using ContactApplication.Services;

namespace ContactApplication.Tests
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void Is_Contact_Added_To_List()
        {
            //arrange
            MenuManager menuManager = new MenuManager();
            Contact contact = new Contact();



            //act
            menuManager.contacts.Add(contact);

            //assert
            Assert.AreEqual(1, menuManager.contacts.Count);
        }
    }
}