using Newtonsoft.Json;
using TechTest.Shared.Interface;
using TechTest.Shared.Models.AddressBook;

namespace TechTest.Repository.Data.AddressBook
{
    public class AddressBookRepository : IAddressBookRepository
    {
        private readonly string _filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data\\Json", "AddressBook.json");
        private readonly IReader _reader;
        private readonly IWriter _writer;
        public AddressBookRepository(IReader reader, IWriter writer)
        {
            _reader = reader;
            _writer = writer;
        }

        public Task AddAddress(Address address)
        {
            var results = GetAllAddresses().Result.ToList();
            results.Add(address);
            string json = JsonConvert.SerializeObject(results, Formatting.Indented);
            _writer.WriteFile(_filePath, json);

            return Task.CompletedTask;
        }

        public Task DeleteAddress(Address address)
        {
            var results = GetAllAddresses().Result.ToList();
            results.RemoveAll(X => X.Id == address.Id);
            string json = JsonConvert.SerializeObject(results, Formatting.Indented);
            _writer.WriteFile(_filePath, json);

            return Task.CompletedTask;
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

        public async Task<Address?> GetAddress(int id)
        {
            return GetAllAddresses().Result.FirstOrDefault(x => x.Id == id);
        }

        public Task UpdateAddress(Address address)
        {
            var results = GetAllAddresses().Result.ToList();

            int index = results.FindIndex(e => e.Id == address.Id);
            if (index != -1)
            {
                results[index] = address;
                string json = JsonConvert.SerializeObject(results, Formatting.Indented);
                _writer.WriteFile(_filePath, json);
            }

            return Task.CompletedTask;
        }
    }
}
