using Moq;
using TechTest.Repository.Data.AddressBook;
using TechTest.Shared.Interface;

namespace TechTest.Tests
{
    [TestFixture]
    public class AddressBookRepositoryTests
    {
        private readonly string _filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data\\Json", "AddressBook.json");
        [Test]
        public void GetAllAddresses_ShouldReturnAddresses()
        {
            // Arrange
            var reader = new Mock<IReader>();
            reader.Setup(x => x.ReadFile(_filePath)).Returns("[{ \"id\": \"0\", \"first_name\": \"David\",\"last_name\": \"Platt\", \"phone\": \"01913478234\", \"email\": \"david.platt@corrie.co.uk\" }]");

            var repository = new AddressBookRepository(reader.Object);

            // Act
            var addresses = repository.GetAllAddresses().Result;

            // Assert
            Assert.That(addresses, Is.Not.Null);
            Assert.That(addresses, Has.Count.EqualTo(1));
            Assert.That(addresses.SingleOrDefault().Id, Is.EqualTo(0));
        }
    }
}