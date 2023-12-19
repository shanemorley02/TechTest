using TechTest.Shared.Models.AddressBook;

namespace TechTest.Repository.Data.AddressBook
{
    public interface IAddressBookRepository
    {
        Task<List<Address>> GetAllAddresses();
    }
}
