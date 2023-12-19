using Moq;
using TechTest.Repository.Data.AddressBook;
using TechTest.Shared.Interface;
using TechTest.Shared.Models.AddressBook;

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
            var writer = new Mock<IWriter>();
            reader.Setup(x => x.ReadFile(_filePath)).Returns("[{ \"id\": \"0\", \"first_name\": \"David\",\"last_name\": \"Platt\", \"phone\": \"01913478234\", \"email\": \"david.platt@corrie.co.uk\" }]");

            var repository = new AddressBookRepository(reader.Object, writer.Object);

            // Act
            var addresses = repository.GetAllAddresses().Result;

            // Assert
            Assert.That(addresses, Is.Not.Null);
            Assert.That(addresses, Has.Count.EqualTo(1));
            Assert.That(addresses.SingleOrDefault().Id, Is.EqualTo(0));
        }
        [Test]
        public void AddAddress_ShouldAddAddress()
        {
            // Arrange
            var reader = new Mock<IReader>();
            var writer = new Mock<IWriter>();
            reader.Setup(x => x.ReadFile(_filePath)).Returns("[{ \"id\": \"0\", \"first_name\": \"David\",\"last_name\": \"Platt\", \"phone\": \"01913478234\", \"email\": \"david.platt@corrie.co.uk\" }]");

            var repository = new AddressBookRepository(reader.Object, writer.Object);

            var address = new Address
            {
                Id = 10,
                FirstName = "Shane",
                LastName = "Morley",
                Phone = "0123456789",
                Email = "shane@test.com"
            };

            // Act
            repository.AddAddress(address);

            // Assert
            writer.Verify(x => x.WriteFile(It.IsAny<string>(), It.IsAny<string>()), Times.Once);
        }

        [Test]
        public void UpdateAddress_ShouldUpdateAddress()
        {
            // Arrange
            var reader = new Mock<IReader>();
            var writer = new Mock<IWriter>();
            reader.Setup(x => x.ReadFile(_filePath)).Returns("[{ \"id\": \"0\", \"first_name\": \"David\",\"last_name\": \"Platt\", \"phone\": \"01913478234\", \"email\": \"david.platt@corrie.co.uk\" }]");

            var repository = new AddressBookRepository(reader.Object, writer.Object);

            // Act
            var address = new Address
            {
                Id = 0,
                FirstName = "David",
                LastName = "Platt",
                Phone = "01913478234",
                Email = "david.plattTest@corrie.co.uk"
            };

            repository.UpdateAddress(address);

            // Assert
            writer.Verify(x => x.WriteFile(It.IsAny<string>(), It.IsAny<string>()), Times.Exactly(1));
        }

        [Test]
        public void DeleteAddress_ShouldDeleteAddress()
        {
            // Arrange
            var reader = new Mock<IReader>();
            var writer = new Mock<IWriter>();
            reader.Setup(x => x.ReadFile(_filePath)).Returns("[{ \"id\": \"0\", \"first_name\": \"David\",\"last_name\": \"Platt\", \"phone\": \"01913478234\", \"email\": \"david.platt@corrie.co.uk\" }]");

            var repository = new AddressBookRepository(reader.Object, writer.Object);

            var address = new Address
            {
                Id = 0,
                FirstName = "David",
                LastName = "Platt",
                Phone = "01913478234",
                Email = "david.platt@corrie.co.uk"
            };

            // Act
            repository.DeleteAddress(address);

            // Assert
            writer.Verify(x => x.WriteFile(It.IsAny<string>(), It.IsAny<string>()), Times.Exactly(1));
        }
    }
}