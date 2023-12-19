using Microsoft.AspNetCore.Mvc;
using TechTest.Repository.Data.AddressBook;
using TechTest.Shared.Models.AddressBook;

namespace TechTest.API
{
    public static class AddressBookApi
    {
        public static void ConfigureApi(this WebApplication app)
        {
            app.MapGet("/AddressBook", GetAllAddresses);
            app.MapPost("/AddressBook/GetAddress", GetAddress);
            app.MapPost("/AddressBook", AddAddress);
            app.MapPut("/AddressBook", UpdateAddress);
            app.MapDelete("/AddressBook", DeleteAddress);
        }

        private static async Task<IResult> GetAllAddresses(IAddressBookRepository addressBookRepository)
        {
            try
            {
                return Results.Ok(await addressBookRepository.GetAllAddresses());
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        private static async Task<IResult> GetAddress(IAddressBookRepository addressBookRepository, [FromBody] Address address)
        {
            try
            {
                var results = await addressBookRepository.GetAddress(address.Id);
                if (results == null)
                {
                    return Results.NotFound();
                }

                return Results.Ok(results);
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        private static async Task<IResult> AddAddress(IAddressBookRepository addressBookRepository, [FromBody] Address address)
        {
            try
            {
                await addressBookRepository.AddAddress(address);
                return Results.Ok();
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        private static async Task<IResult> UpdateAddress(IAddressBookRepository addressBookRepository, [FromBody] Address address)
        {
            try
            {
                await addressBookRepository.UpdateAddress(address);
                return Results.Ok();
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }
        private static async Task<IResult> DeleteAddress(IAddressBookRepository addressBookRepository, [FromBody] Address address)
        {
            try
            {
                await addressBookRepository.DeleteAddress(address);
                return Results.Ok();
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }
    }
}
