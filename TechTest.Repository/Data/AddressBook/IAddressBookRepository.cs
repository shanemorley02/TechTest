using TechTest.Shared.Models.AddressBook;

namespace TechTest.Repository.Data.AddressBook
{
    public interface IAddressBookRepository
    {
        Task<List<Address>> GetAllAddresses();
        Task AddAddress(Address address);
        Task DeleteAddress(Address address);
        Task UpdateAddress(Address address);
        Task<Address?> GetAddress(int id);
    }
}
