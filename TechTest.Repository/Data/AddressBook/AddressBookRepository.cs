using Newtonsoft.Json;
using TechTest.Shared.Interface;
using TechTest.Shared.Models.AddressBook;

namespace TechTest.Repository.Data.AddressBook
{
    public class AddressBookRepository : IAddressBookRepository
    {
        private readonly string _filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data\\Json", "AddressBook.json");
        private readonly IReader _reader;
        public AddressBookRepository(IReader reader)
        {
            _reader = reader;
        }

        public Task<List<Address>> GetAllAddresses()
        {
            return Task.Run(() =>
            {
                string json = _reader.ReadFile(_filePath);
                var result = JsonConvert.DeserializeObject<List<Address>>(json);

                return result;
            });
        }
    }
}
